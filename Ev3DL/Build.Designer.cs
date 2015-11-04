namespace Ev3DL
{
    partial class BuildFrm
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
            this.tbBuildOutput = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuild = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // tbBuildOutput
            // 
            this.tbBuildOutput.Location = new System.Drawing.Point(12, 103);
            this.tbBuildOutput.Multiline = true;
            this.tbBuildOutput.Name = "tbBuildOutput";
            this.tbBuildOutput.ReadOnly = true;
            this.tbBuildOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbBuildOutput.Size = new System.Drawing.Size(257, 154);
            this.tbBuildOutput.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(194, 28);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tbFile
            // 
            this.tbFile.Location = new System.Drawing.Point(12, 29);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(176, 22);
            this.tbFile.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Build Output:";
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(194, 57);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(75, 23);
            this.btnBuild.TabIndex = 5;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BuildFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 263);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFile);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbBuildOutput);
            this.Name = "BuildFrm";
            this.ShowIcon = false;
            this.Text = "Build";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbBuildOutput;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}