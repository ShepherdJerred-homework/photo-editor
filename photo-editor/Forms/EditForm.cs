using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using photo_editor.Forms;

namespace photo_editor {

	public partial class EditForm : Form {

		private PhotoEditor photoEditor;

		public EditForm(FileInfo fileInfo)
		{
			Image image = Image.FromFile(fileInfo.FullName);
			photoEditor = new PhotoEditor((Bitmap)image);

			InitializeComponent();
			pictureBox.Image = image;
		}

		private void launchProgressBar()
		{
			TransformProgressForm transformProgressForm = new TransformProgressForm();
			transformProgressForm.Show();
		}

		private void alterPhoto_Click(object sender, EventArgs e)
		{
			disableForm();

			alterPhoto(sender);

			enableForm();
			updateImage();
		}

		private void alterPhoto(object sender)
		{
			string senderName = ((Control)sender).Name;

			if (senderName == invertButton.Name)
			{
				photoEditor.InvertColors();
			}
			else if (senderName == colorButton.Name)
			{
				ColorDialog colorDialog = new ColorDialog();

				if (colorDialog.ShowDialog() == DialogResult.OK)
				{
					photoEditor.TransformByColor(colorDialog.Color);
				}
			}
			else if (senderName == brightnessTrackBar.Name)
			{
				photoEditor.ChangeBrightness(brightnessTrackBar.Value);
			}
			else
			{
				throw new ArgumentException("EditForm.AlterPhoto() could not be performed with the sender - " + sender.ToString());
			}
		}

		private void disableForm()
		{
			foreach(Control control in Controls)
			{
				if (control != null)
				{
					control.Enabled = false;
				}
			}
		}

		private void enableForm()
		{
			foreach (Control control in Controls)
			{
				if (control != null)
				{
					control.Enabled = true;
				}
			}
		}

		private void updateImage()
		{
			pictureBox.Image = photoEditor.TransformedBitmap;
		}
	}
}
