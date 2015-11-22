using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ev3DL
{
    public partial class Ev3DL : Form
    {
        private Lego.Ev3.Core.Brick brick;
        public Ev3DL()
        {
            InitializeComponent();
            rWF.Visible = false; //WiFi is not allowed for the moment.
            DisableBT();
            btnRename.Visible = false; //Don't show rename button if we're not connected.
            DisableSend();
        }

        private void DisableSend()
        {
            labelUpload.Visible = false;
            tbFile.Visible = false;
            btnSendFile.Visible = false;
            btnBrowse.Visible = false;
            btnBuild.Visible = false;
            btnDisconnect.Visible = false;
        }
        private void EnableSend()
        {
            labelUpload.Visible = true;
            tbFile.Visible = true;
            btnSendFile.Visible = true;
            btnBrowse.Visible = true;
            btnBuild.Visible = true;
            btnDisconnect.Visible = true;
        }
        private void DisableBT()
        {
            comboBox1.Enabled = false;
            comboBox1.Visible = false;
            btnRefreshCOM.Enabled = false;
            btnRefreshCOM.Visible = false;
        }
        private void EnableBT()
        {
            comboBox1.Enabled = true;
            comboBox1.Visible = true;
            popCOM();
            btnRefreshCOM.Enabled = true;
            btnRefreshCOM.Visible = true;
        }
        private void popCOM()
        {
            comboBox1.Items.Clear();
            var names = System.IO.Ports.SerialPort.GetPortNames();
            if (names.Length == 0)
            {
                MessageBox.Show(this,"No Attached COM Devices.");
                comboBox1.Items.Add("");
            }
            else
            {
                Array.Sort(names);
                comboBox1.Items.AddRange(names);
            }
            comboBox1.SelectedIndex = 0;
        }
        private void rBT_CheckedChanged(object sender, EventArgs e)
        {
            if (rBT.Checked)
            {
                EnableBT();
            }
            else
            {
                DisableBT();
            }
        }

        private void btnRefreshCOM_Click(object sender, EventArgs e)
        {
            popCOM();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            Lego.Ev3.Core.ICommunication ct;
            if (rBT.Checked)
            {
                try
                {
                    ct = new Lego.Ev3.Desktop.BluetoothCommunication(comboBox1.SelectedItem as string);
                }
                catch (Exception f)
                {
                    MessageBox.Show(this, f.Message);
                    return;
                }

            }
            else if (rUSB.Checked)
            {
                try
                {
                    ct = new Lego.Ev3.Desktop.UsbCommunication();
                }
                catch(Exception f)
                {
                    MessageBox.Show(this, f.Message);
                    return;
                }
            }
            else return;
            try
            {
                brick = new Lego.Ev3.Core.Brick(ct);
                await brick.ConnectAsync();
            }
            catch (Exception f)
            {
                MessageBox.Show(this, f.Message);
                return;
            }
            string txt = "Connected";//, Name:"; //Name support unwritten at this time. Need to update the Ev3 library to support it.

            Tuple<ushort, ushort>[] tones =
                {
                new Tuple<ushort, ushort>(523,100),
                new Tuple<ushort, ushort>(659,100),
                new Tuple<ushort, ushort>(784,100),
                new Tuple<ushort, ushort>(1046,150)
                };
            PlayTones(tones);
            labelConnectionStatus.Text = txt;
            EnableSend();
        }
        void PlayTones(Tuple<ushort,ushort>[] tones)
        {
            System.Timers.Timer t = new System.Timers.Timer(100);
            int i = 0;
            t.Elapsed += (_s, _e) => { brick.DirectCommand.PlayToneAsync(2, tones[i].Item1, tones[i].Item2);i++; if (i >= tones.Length) t.Enabled = false; };
            t.Enabled = true;
        }
        string selectedfile;
        private void openFileDialog1_FileOk(object sender , CancelEventArgs e)
        {
            var v = sender as OpenFileDialog;
            tbFile.Text = v.FileName;
            selectedfile = v.SafeFileName;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
        }

        private async void btnSendFile_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(tbFile.Text))
            {
                MessageBox.Show(this, "File does not exist!");
                return;
            }
            try
            {
                await brick.SystemCommand.CopyFileAsync(tbFile.Text, "../prjs/" + selectedfile);
                Tuple<ushort, ushort>[] tones = {
                    new Tuple<ushort, ushort>(440,100),
                    new Tuple<ushort, ushort>(880,100),
                };
                PlayTones(tones);
                MessageBox.Show(this, "File Copied!");
            }
            catch (Exception f)
            {
                Tuple<ushort, ushort>[] tones = {
                    new Tuple<ushort, ushort>(880,100),
                    new Tuple<ushort, ushort>(440,100),
                };
                PlayTones(tones);
                MessageBox.Show(this, f.Message);
                return;
            }
            return;
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            var bf = new BuildFrm(tbFile.Text);
            bf.ShowDialog(this);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            brick.Disconnect();
            DisableSend();
            labelConnectionStatus.Text = "Disconnected";
        }
    }
}
