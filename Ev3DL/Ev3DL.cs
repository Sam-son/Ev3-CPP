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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(rBT.Checked)
            {
                Lego.Ev3.Desktop.BluetoothCommunication bt;
                try
                {
                    bt = new Lego.Ev3.Desktop.BluetoothCommunication(comboBox1.SelectedItem as string);
                }
                catch(Exception f)
                {
                    MessageBox.Show(this,f.Message);
                    return;
                }
                try
                {
                    brick = new Lego.Ev3.Core.Brick(bt);
                }
                catch(Exception f)
                {
                    MessageBox.Show(this,f.Message);
                    return;
                }
                string txt = "Connected, Name:";
                labelConnectionStatus.Text = txt;
            }
            else if(rUSB.Checked)
            {

            }
        }
    }
}
