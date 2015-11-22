namespace Ev3DL
{
    partial class Ev3DL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ev3DL));
            this.panel1 = new System.Windows.Forms.Panel();
            this.rWF = new System.Windows.Forms.RadioButton();
            this.rBT = new System.Windows.Forms.RadioButton();
            this.rUSB = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnRefreshCOM = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.btnRename = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.labelUpload = new System.Windows.Forms.Label();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnBuild = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rWF);
            this.panel1.Controls.Add(this.rBT);
            this.panel1.Controls.Add(this.rUSB);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(92, 88);
            this.panel1.TabIndex = 0;
            // 
            // rWF
            // 
            this.rWF.AutoSize = true;
            this.rWF.Location = new System.Drawing.Point(3, 57);
            this.rWF.Name = "rWF";
            this.rWF.Size = new System.Drawing.Size(56, 21);
            this.rWF.TabIndex = 2;
            this.rWF.Text = "WiFi";
            this.rWF.UseVisualStyleBackColor = true;
            // 
            // rBT
            // 
            this.rBT.AutoSize = true;
            this.rBT.Location = new System.Drawing.Point(3, 30);
            this.rBT.Name = "rBT";
            this.rBT.Size = new System.Drawing.Size(89, 21);
            this.rBT.TabIndex = 1;
            this.rBT.Text = "Bluetooth";
            this.rBT.UseVisualStyleBackColor = true;
            this.rBT.CheckedChanged += new System.EventHandler(this.rBT_CheckedChanged);
            // 
            // rUSB
            // 
            this.rUSB.AutoSize = true;
            this.rUSB.Checked = true;
            this.rUSB.Location = new System.Drawing.Point(3, 3);
            this.rUSB.Name = "rUSB";
            this.rUSB.Size = new System.Drawing.Size(57, 21);
            this.rUSB.TabIndex = 0;
            this.rUSB.TabStop = true;
            this.rUSB.Text = "USB";
            this.rUSB.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Location = new System.Drawing.Point(110, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // btnRefreshCOM
            // 
            this.btnRefreshCOM.Location = new System.Drawing.Point(256, 41);
            this.btnRefreshCOM.Name = "btnRefreshCOM";
            this.btnRefreshCOM.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshCOM.TabIndex = 2;
            this.btnRefreshCOM.Text = "Refresh";
            this.btnRefreshCOM.UseVisualStyleBackColor = true;
            this.btnRefreshCOM.Click += new System.EventHandler(this.btnRefreshCOM_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(15, 107);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Location = new System.Drawing.Point(97, 112);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(94, 17);
            this.labelConnectionStatus.TabIndex = 4;
            this.labelConnectionStatus.Text = "Disconnected";
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(255, 112);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 5;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // tbFile
            // 
            this.tbFile.Location = new System.Drawing.Point(110, 186);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(234, 22);
            this.tbFile.TabIndex = 6;
            // 
            // labelUpload
            // 
            this.labelUpload.AutoSize = true;
            this.labelUpload.Location = new System.Drawing.Point(15, 166);
            this.labelUpload.Name = "labelUpload";
            this.labelUpload.Size = new System.Drawing.Size(97, 17);
            this.labelUpload.TabIndex = 7;
            this.labelUpload.Text = "File to upload:";
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(18, 215);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(75, 23);
            this.btnSendFile.TabIndex = 8;
            this.btnSendFile.Text = "Send";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(18, 186);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(234, 215);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(109, 23);
            this.btnBuild.TabIndex = 10;
            this.btnBuild.Text = "Build Source...";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(15, 136);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(89, 23);
            this.btnDisconnect.TabIndex = 11;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // Ev3DL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 255);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.labelUpload);
            this.Controls.Add(this.tbFile);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.labelConnectionStatus);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnRefreshCOM);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ev3DL";
            this.Text = "Ev3DL";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rWF;
        private System.Windows.Forms.RadioButton rBT;
        private System.Windows.Forms.RadioButton rUSB;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnRefreshCOM;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Label labelUpload;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Button btnDisconnect;
    }
}

