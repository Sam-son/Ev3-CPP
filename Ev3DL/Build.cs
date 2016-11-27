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

        //TODO: Make this less stupid.
        private const string includes = "\"C:\\Program Files (x86)\\Ev3DL\\lmsapi\\ev3_button.c\" " +
            "\"C:\\Program Files (x86)\\Ev3DL\\lmsapi\\ev3_command.c\" " +
            "\"C:\\Program Files (x86)\\Ev3DL\\lmsapi\\ev3_lcd.c\" " +
            "\"C:\\Program Files (x86)\\Ev3DL\\lmsapi\\ev3_output.c\" " +
            "\"C:\\Program Files (x86)\\Ev3DL\\lmsapi\\ev3_sound.c\" " +
            "\"C:\\Program Files (x86)\\Ev3DL\\lmsapi\\ev3_timer.c\" "+
			"\"C:\\Program Files (x86)\\Ev3DL\\lmsapi\\serial_read.c\" ";
        private void btnBuild_Click(object sender, EventArgs e)
        {
            var substrstart= tbFile.Text.LastIndexOf("\\")+1;
            var oname = tbFile.Text.Substring(substrstart,tbFile.Text.LastIndexOf(".")-substrstart); 
            System.Diagnostics.Process BuildProcess = new System.Diagnostics.Process();
            string docpath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +"\\";
            DialogResult r = folderBrowserDialog1.ShowDialog(this);
            if (r == DialogResult.OK)
                docpath = folderBrowserDialog1.SelectedPath+"\\";
            oname = docpath + oname;
            BuildProcess.StartInfo.FileName = @"C:\CSLITE\bin\arm-none-linux-gnueabi-gcc.exe";
            string args = string.Format("-I \"C:\\Program Files (x86)\\Ev3DL\\lmsapi\" -static -o \"{0}\" {1} \"{2}\"",oname,includes,tbFile.Text);
            BuildProcess.StartInfo.Arguments = args;
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
            tbBuildOutput.AppendText("Done Building.\n");
        }
        void BuildOutputHandler(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() => { tbBuildOutput.AppendText((e.Data!= null) ? e.Data + "\n" : string.Empty);}));
        }
    }
}
