using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ev3DL
{
    public partial class BuildFrm : Form
    {
        public BuildFrm()
        {
            InitializeComponent();
        }
        public BuildFrm(string filename)
        {
            InitializeComponent();
            tbFile.Text = filename;
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult r = openFileDialog1.ShowDialog(this);
            if (r == DialogResult.OK)
                tbFile.Text = openFileDialog1.FileName;
        }

        private const string includes = "lms2012\\ev3_button.c lms2012\\ev3_command.c lms2012\\ev3_lcd.c lms2012\\ev3_output.c lms2012\\ev3_sound.c lms2012\\ev3_timer.c ";
        private void btnBuild_Click(object sender, EventArgs e)
        {
            var substrstart= tbFile.Text.LastIndexOf("\\")+1;
            var oname = tbFile.Text.Substring(substrstart,tbFile.Text.LastIndexOf(".")-substrstart); 
            System.Diagnostics.Process BuildProcess = new System.Diagnostics.Process();
            BuildProcess.StartInfo.FileName = @"C:\CSLITE\bin\arm-none-linux-gnueabi-g++.exe";
            BuildProcess.StartInfo.Arguments = "-o "+oname+".o "+ includes + tbFile.Text;
            BuildProcess.StartInfo.CreateNoWindow = true;
            BuildProcess.StartInfo.UseShellExecute = false;
            BuildProcess.StartInfo.RedirectStandardOutput = true;
            BuildProcess.StartInfo.RedirectStandardError = true;
            BuildProcess.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(BuildOutputHandler);
            BuildProcess.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(BuildOutputHandler);
            BuildProcess.Start();
            BuildProcess.BeginOutputReadLine();
            BuildProcess.BeginErrorReadLine();
            BuildProcess.WaitForExit();
        }
        void BuildOutputHandler(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() => { tbBuildOutput.AppendText(e.Data ?? string.Empty);}));
        }
    }
}
