namespace motDet
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.recordMotionBox = new System.Windows.Forms.CheckBox();
            this.camSettings = new System.Windows.Forms.Button();
            this.extraThread1 = new System.ComponentModel.BackgroundWorker();
            this.ControlPicLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.infoLabel2 = new System.Windows.Forms.Label();
            this.gridBox = new System.Windows.Forms.PictureBox();
            this.infoLabel3 = new System.Windows.Forms.Label();
            this.backupInfo = new System.Windows.Forms.Label();
            this.fpsTimer = new System.Windows.Forms.Timer(this.components);
            this.fpsLabel = new System.Windows.Forms.Label();
            this.programSettingsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(14, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(532, 443);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // recordMotionBox
            // 
            this.recordMotionBox.AutoSize = true;
            this.recordMotionBox.Location = new System.Drawing.Point(553, 13);
            this.recordMotionBox.Name = "recordMotionBox";
            this.recordMotionBox.Size = new System.Drawing.Size(114, 17);
            this.recordMotionBox.TabIndex = 1;
            this.recordMotionBox.Text = "Record Movement";
            this.recordMotionBox.UseVisualStyleBackColor = true;
            this.recordMotionBox.CheckStateChanged += new System.EventHandler(this.recordMotionBox_CheckStateChanged);
            // 
            // camSettings
            // 
            this.camSettings.Location = new System.Drawing.Point(553, 36);
            this.camSettings.Name = "camSettings";
            this.camSettings.Size = new System.Drawing.Size(114, 31);
            this.camSettings.TabIndex = 2;
            this.camSettings.Text = "Camera Settings";
            this.camSettings.UseVisualStyleBackColor = true;
            this.camSettings.Click += new System.EventHandler(this.camSettings_Click);
            // 
            // extraThread1
            // 
            this.extraThread1.WorkerReportsProgress = true;
            this.extraThread1.WorkerSupportsCancellation = true;
            this.extraThread1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.extraThread1_DoWork);
            this.extraThread1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.extraThread1_RunWorkerCompleted);
            // 
            // ControlPicLabel
            // 
            this.ControlPicLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ControlPicLabel.Location = new System.Drawing.Point(552, 70);
            this.ControlPicLabel.Name = "ControlPicLabel";
            this.ControlPicLabel.Size = new System.Drawing.Size(115, 48);
            this.ControlPicLabel.TabIndex = 3;
            this.ControlPicLabel.Text = "No Control Image!";
            // 
            // infoLabel
            // 
            this.infoLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.infoLabel.Location = new System.Drawing.Point(550, 137);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(115, 48);
            this.infoLabel.TabIndex = 3;
            this.infoLabel.Text = "Not Processing Frames";
            // 
            // infoLabel2
            // 
            this.infoLabel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.infoLabel2.Location = new System.Drawing.Point(550, 198);
            this.infoLabel2.Name = "infoLabel2";
            this.infoLabel2.Size = new System.Drawing.Size(77, 45);
            this.infoLabel2.TabIndex = 3;
            // 
            // gridBox
            // 
            this.gridBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gridBox.Location = new System.Drawing.Point(14, 460);
            this.gridBox.Name = "gridBox";
            this.gridBox.Size = new System.Drawing.Size(650, 147);
            this.gridBox.TabIndex = 4;
            this.gridBox.TabStop = false;
            this.gridBox.Paint += new System.Windows.Forms.PaintEventHandler(this.gridBox_Paint);
            // 
            // infoLabel3
            // 
            this.infoLabel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.infoLabel3.Location = new System.Drawing.Point(550, 321);
            this.infoLabel3.Name = "infoLabel3";
            this.infoLabel3.Size = new System.Drawing.Size(115, 48);
            this.infoLabel3.TabIndex = 3;
            // 
            // backupInfo
            // 
            this.backupInfo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.backupInfo.Location = new System.Drawing.Point(550, 255);
            this.backupInfo.Name = "backupInfo";
            this.backupInfo.Size = new System.Drawing.Size(117, 45);
            this.backupInfo.TabIndex = 3;
            // 
            // fpsTimer
            // 
            this.fpsTimer.Enabled = true;
            this.fpsTimer.Interval = 1000;
            this.fpsTimer.Tick += new System.EventHandler(this.fpsTimer_Tick);
            // 
            // fpsLabel
            // 
            this.fpsLabel.BackColor = System.Drawing.Color.Transparent;
            this.fpsLabel.ForeColor = System.Drawing.Color.Red;
            this.fpsLabel.Location = new System.Drawing.Point(28, 23);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(220, 75);
            this.fpsLabel.TabIndex = 5;
            // 
            // programSettingsButton
            // 
            this.programSettingsButton.Location = new System.Drawing.Point(552, 381);
            this.programSettingsButton.Name = "programSettingsButton";
            this.programSettingsButton.Size = new System.Drawing.Size(112, 33);
            this.programSettingsButton.TabIndex = 6;
            this.programSettingsButton.Text = "Capture Settings";
            this.programSettingsButton.UseVisualStyleBackColor = true;
            this.programSettingsButton.Click += new System.EventHandler(this.programSettingsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 615);
            this.Controls.Add(this.programSettingsButton);
            this.Controls.Add(this.fpsLabel);
            this.Controls.Add(this.gridBox);
            this.Controls.Add(this.backupInfo);
            this.Controls.Add(this.infoLabel2);
            this.Controls.Add(this.infoLabel3);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.ControlPicLabel);
            this.Controls.Add(this.camSettings);
            this.Controls.Add(this.recordMotionBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Motion Detection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox recordMotionBox;
        private System.Windows.Forms.Button camSettings;
        private System.ComponentModel.BackgroundWorker extraThread1;
        private System.Windows.Forms.Label ControlPicLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Label infoLabel2;
        private System.Windows.Forms.PictureBox gridBox;
        private System.Windows.Forms.Label infoLabel3;
        private System.Windows.Forms.Label backupInfo;
        private System.Windows.Forms.Timer fpsTimer;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.Button programSettingsButton;
    }
}

