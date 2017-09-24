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
			this.cancelButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(13, 13);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(636, 352);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// brightnessTrackBar
			// 
			this.brightnessTrackBar.Location = new System.Drawing.Point(13, 19);
			this.brightnessTrackBar.Maximum = 100;
			this.brightnessTrackBar.Name = "brightnessTrackBar";
			this.brightnessTrackBar.Size = new System.Drawing.Size(104, 45);
			this.brightnessTrackBar.TabIndex = 2;
			this.brightnessTrackBar.Value = 50;
			this.brightnessTrackBar.MouseCaptureChanged += new System.EventHandler(this.alterPhoto_Click);
			// 
			// colorButton
			// 
			this.colorButton.Location = new System.Drawing.Point(280, 19);
			this.colorButton.Name = "colorButton";
			this.colorButton.Size = new System.Drawing.Size(75, 23);
			this.colorButton.TabIndex = 3;
			this.colorButton.Text = "Color...";
			this.colorButton.UseVisualStyleBackColor = true;
			this.colorButton.Click += new System.EventHandler(this.alterPhoto_Click);
			// 
			// invertButton
			// 
			this.invertButton.Location = new System.Drawing.Point(555, 19);
			this.invertButton.Name = "invertButton";
			this.invertButton.Size = new System.Drawing.Size(75, 23);
			this.invertButton.TabIndex = 4;
			this.invertButton.Text = "Invert";
			this.invertButton.UseVisualStyleBackColor = true;
			this.invertButton.Click += new System.EventHandler(this.alterPhoto_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.brightnessTrackBar);
			this.groupBox1.Controls.Add(this.invertButton);
			this.groupBox1.Controls.Add(this.colorButton);
			this.groupBox1.Location = new System.Drawing.Point(13, 371);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(636, 82);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(575, 472);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 6;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(494, 472);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 7;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			// 
			// EditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(662, 505);
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
    }
}