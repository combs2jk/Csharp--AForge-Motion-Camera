namespace motDet
{
    partial class programSettings
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
            this.openingFilterBox = new System.Windows.Forms.CheckBox();
            this.edgesFilterBox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.ySize = new System.Windows.Forms.TextBox();
            this.xSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.infoLabel3 = new System.Windows.Forms.Label();
            this.requiredSizeSubmit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openingFilterBox
            // 
            this.openingFilterBox.AutoSize = true;
            this.openingFilterBox.Location = new System.Drawing.Point(11, 71);
            this.openingFilterBox.Name = "openingFilterBox";
            this.openingFilterBox.Size = new System.Drawing.Size(113, 17);
            this.openingFilterBox.TabIndex = 0;
            this.openingFilterBox.Text = "Use Opening Filter";
            this.openingFilterBox.UseVisualStyleBackColor = true;
            this.openingFilterBox.CheckedChanged += new System.EventHandler(this.openingFilterBox_CheckedChanged);
            // 
            // edgesFilterBox
            // 
            this.edgesFilterBox.AutoSize = true;
            this.edgesFilterBox.Location = new System.Drawing.Point(11, 94);
            this.edgesFilterBox.Name = "edgesFilterBox";
            this.edgesFilterBox.Size = new System.Drawing.Size(103, 17);
            this.edgesFilterBox.TabIndex = 0;
            this.edgesFilterBox.Text = "Use Edges Filter";
            this.edgesFilterBox.UseVisualStyleBackColor = true;
            this.edgesFilterBox.CheckedChanged += new System.EventHandler(this.edgesFilterBox_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(184, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint_1);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // infoLabel1
            // 
            this.infoLabel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.infoLabel1.Location = new System.Drawing.Point(12, 114);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(147, 30);
            this.infoLabel1.TabIndex = 2;
            this.infoLabel1.Text = "MINIMUM size of movement considered interesting:";
            // 
            // ySize
            // 
            this.ySize.Location = new System.Drawing.Point(95, 147);
            this.ySize.Name = "ySize";
            this.ySize.Size = new System.Drawing.Size(44, 20);
            this.ySize.TabIndex = 3;
            // 
            // xSize
            // 
            this.xSize.Location = new System.Drawing.Point(30, 147);
            this.xSize.Name = "xSize";
            this.xSize.Size = new System.Drawing.Size(44, 20);
            this.xSize.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = ",";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // infoLabel3
            // 
            this.infoLabel3.BackColor = System.Drawing.SystemColors.Control;
            this.infoLabel3.Location = new System.Drawing.Point(40, 170);
            this.infoLabel3.Name = "infoLabel3";
            this.infoLabel3.Size = new System.Drawing.Size(99, 27);
            this.infoLabel3.TabIndex = 2;
            this.infoLabel3.Text = "(Width, Height) ";
            // 
            // requiredSizeSubmit
            // 
            this.requiredSizeSubmit.Location = new System.Drawing.Point(43, 186);
            this.requiredSizeSubmit.Name = "requiredSizeSubmit";
            this.requiredSizeSubmit.Size = new System.Drawing.Size(72, 23);
            this.requiredSizeSubmit.TabIndex = 4;
            this.requiredSizeSubmit.Text = "Enter";
            this.requiredSizeSubmit.UseVisualStyleBackColor = true;
            this.requiredSizeSubmit.Click += new System.EventHandler(this.requiredSizeSubmit_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 59);
            this.label2.TabIndex = 2;
            this.label2.Text = "Less filters significantly increase FPS in exchange for motion detection accuracy" +
                ".";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(181, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "WASD keys to change size.";
            // 
            // programSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 240);
            this.Controls.Add(this.requiredSizeSubmit);
            this.Controls.Add(this.xSize);
            this.Controls.Add(this.ySize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.infoLabel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.infoLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.edgesFilterBox);
            this.Controls.Add(this.openingFilterBox);
            this.Name = "programSettings";
            this.Text = "Program Settings";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.programSettings_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox openingFilterBox;
        private System.Windows.Forms.CheckBox edgesFilterBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label infoLabel1;
        private System.Windows.Forms.TextBox ySize;
        private System.Windows.Forms.TextBox xSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label infoLabel3;
        private System.Windows.Forms.Button requiredSizeSubmit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}