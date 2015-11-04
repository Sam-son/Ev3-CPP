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
            openFileDialog1.ShowDialog(this);
        }
        private void openFileDialog1_FileOk(object sender , CancelEventArgs e)
        {
            var v = sender as OpenFileDialog;
            tbFile.Text = v.FileName;
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process BuildProcess = new System.Diagnostics.Process();
            BuildProcess.StartInfo.FileName = @"C:\CSLITE\bin\arm-none-linux-gnueabi-g++.exe";
            BuildProcess.StartInfo.Arguments = "--version";
            BuildProcess.StartInfo.CreateNoWindow = true;
            BuildProcess.StartInfo.UseShellExecute = false;
            BuildProcess.StartInfo.RedirectStandardOutput = true;
            BuildProcess.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(BuildOutputHandler);
            BuildProcess.Start();
            BuildProcess.BeginOutputReadLine();
            BuildProcess.WaitForExit();
        }
        void BuildOutputHandler(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() => { tbBuildOutput.AppendText(e.Data ?? string.Empty); }));
        }
    }
}
