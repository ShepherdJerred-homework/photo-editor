namespace photo_editor {
    partial class EditForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.brightnessTrackBar = new System.Windows.Forms.TrackBar();
			this.colorButton = new System.Windows.Forms.Button();
			this.invertButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.brightnessLabel = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.saveAsButton = new System.Windows.Forms.Button();
			this.brightnessDarkLabel = new System.Windows.Forms.Label();
			this.brightnessLightLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox.Location = new System.Drawing.Point(13, 13);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(636, 352);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// brightnessTrackBar
			// 
			this.brightnessTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.brightnessTrackBar.Location = new System.Drawing.Point(13, 20);
			this.brightnessTrackBar.Maximum = 100;
			this.brightnessTrackBar.Name = "brightnessTrackBar";
			this.brightnessTrackBar.Size = new System.Drawing.Size(104, 45);
			this.brightnessTrackBar.TabIndex = 2;
			this.brightnessTrackBar.Value = 50;
			this.brightnessTrackBar.MouseCaptureChanged += new System.EventHandler(this.alterPhoto_Click);
			// 
			// colorButton
			// 
			this.colorButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.colorButton.Location = new System.Drawing.Point(280, 20);
			this.colorButton.Name = "colorButton";
			this.colorButton.Size = new System.Drawing.Size(75, 23);
			this.colorButton.TabIndex = 3;
			this.colorButton.Text = "Color...";
			this.colorButton.UseVisualStyleBackColor = true;
			this.colorButton.Click += new System.EventHandler(this.alterPhoto_Click);
			// 
			// invertButton
			// 
			this.invertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.invertButton.Location = new System.Drawing.Point(555, 20);
			this.invertButton.Name = "invertButton";
			this.invertButton.Size = new System.Drawing.Size(75, 23);
			this.invertButton.TabIndex = 4;
			this.invertButton.Text = "Invert";
			this.invertButton.UseVisualStyleBackColor = true;
			this.invertButton.Click += new System.EventHandler(this.alterPhoto_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.brightnessDarkLabel);
			this.groupBox1.Controls.Add(this.brightnessLightLabel);
			this.groupBox1.Controls.Add(this.brightnessLabel);
			this.groupBox1.Controls.Add(this.brightnessTrackBar);
			this.groupBox1.Controls.Add(this.invertButton);
			this.groupBox1.Controls.Add(this.colorButton);
			this.groupBox1.Location = new System.Drawing.Point(13, 371);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(636, 82);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			// 
			// brightnessLabel
			// 
			this.brightnessLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.brightnessLabel.AutoSize = true;
			this.brightnessLabel.Location = new System.Drawing.Point(36, 52);
			this.brightnessLabel.Name = "brightnessLabel";
			this.brightnessLabel.Size = new System.Drawing.Size(56, 13);
			this.brightnessLabel.TabIndex = 5;
			this.brightnessLabel.Text = "Brightness";
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(575, 472);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 6;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.Location = new System.Drawing.Point(413, 472);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 7;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// saveAsButton
			// 
			this.saveAsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.saveAsButton.Location = new System.Drawing.Point(494, 472);
			this.saveAsButton.Name = "saveAsButton";
			this.saveAsButton.Size = new System.Drawing.Size(75, 23);
			this.saveAsButton.TabIndex = 8;
			this.saveAsButton.Text = "Save As...";
			this.saveAsButton.UseVisualStyleBackColor = true;
			this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
			// 
			// brightnessDarkLabel
			// 
			this.brightnessDarkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.brightnessDarkLabel.AutoSize = true;
			this.brightnessDarkLabel.Location = new System.Drawing.Point(6, 9);
			this.brightnessDarkLabel.Name = "brightnessDarkLabel";
			this.brightnessDarkLabel.Size = new System.Drawing.Size(30, 13);
			this.brightnessDarkLabel.TabIndex = 9;
			this.brightnessDarkLabel.Text = "Dark";
			// 
			// brightnessLightLabel
			// 
			this.brightnessLightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.brightnessLightLabel.AutoSize = true;
			this.brightnessLightLabel.Location = new System.Drawing.Point(94, 9);
			this.brightnessLightLabel.Name = "brightnessLightLabel";
			this.brightnessLightLabel.Size = new System.Drawing.Size(30, 13);
			this.brightnessLightLabel.TabIndex = 10;
			this.brightnessLightLabel.Text = "Light";
			// 
			// EditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(662, 505);
			this.Controls.Add(this.saveAsButton);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.pictureBox);
			this.Name = "EditForm";
			this.Text = "Edit Photo";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TrackBar brightnessTrackBar;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button invertButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button saveAsButton;
		private System.Windows.Forms.Label brightnessLabel;
		private System.Windows.Forms.Label brightnessDarkLabel;
		private System.Windows.Forms.Label brightnessLightLabel;
	}
}