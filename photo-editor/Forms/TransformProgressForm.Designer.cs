namespace photo_editor.Forms
{
	partial class TransformProgressForm
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
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.cancelButton = new System.Windows.Forms.Button();
			this.pleaseWaitLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(55, 60);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(200, 23);
			this.progressBar.Step = 1;
			this.progressBar.TabIndex = 0;
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(115, 115);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// pleaseWaitLabel
			// 
			this.pleaseWaitLabel.AutoSize = true;
			this.pleaseWaitLabel.Location = new System.Drawing.Point(115, 30);
			this.pleaseWaitLabel.Name = "pleaseWaitLabel";
			this.pleaseWaitLabel.Size = new System.Drawing.Size(73, 13);
			this.pleaseWaitLabel.TabIndex = 2;
			this.pleaseWaitLabel.Text = "Please Wait...";
			// 
			// TransformProgressForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(309, 161);
			this.Controls.Add(this.pleaseWaitLabel);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.progressBar);
			this.Name = "TransformProgressForm";
			this.Text = "Transforming";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label pleaseWaitLabel;
	}
}