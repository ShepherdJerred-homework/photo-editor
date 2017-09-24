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
		private TransformProgressForm transformProgressForm;

		public EditForm(FileInfo fileInfo)
		{
			Image image = getImageFromFileInfo(fileInfo);

			photoEditor = new PhotoEditor((Bitmap)image, fileInfo.FullName);
			photoEditor.OnePercentOfEditCompleted += updateTransformProgressBar;

			InitializeComponent();
			pictureBox.Image = image;
		}

		private async void alterPhoto_Click(object sender, EventArgs e)
		{
			disableForm();
			transformProgressForm = new TransformProgressForm();
			transformProgressForm.ImageEditCancelled += cancelImageEdit;
			transformProgressForm.Show();

			await Task.Run(() =>
			{
				alterPhoto(sender);

				Invoke((Action)delegate ()
				{
					transformProgressForm.Close();
					enableForm();
					updateImage();
				});
			});
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

		private void updateTransformProgressBar(int totalPercentageCompleted)
		{
			Invoke((Action)delegate () { transformProgressForm.ProgressBarValue = totalPercentageCompleted; });
		}

		private void cancelImageEdit()
		{
			photoEditor.cancelImageEdit();
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

		private void saveButton_Click(object sender, EventArgs e)
		{
			photoEditor.saveImage();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private Image getImageFromFileInfo(FileInfo fileInfo)
		{
			byte[] bytes = System.IO.File.ReadAllBytes(fileInfo.FullName);
			MemoryStream memoryStream = new MemoryStream(bytes);
			return Image.FromStream(memoryStream);
		}
	}
}
