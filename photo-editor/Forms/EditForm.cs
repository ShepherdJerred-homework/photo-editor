using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using photo_editor.Forms;

namespace photo_editor
{
	public partial class EditForm : Form
	{
		private double imageAspectRatio;
		private Image image;
		private PhotoEditor photoEditor;
		private TransformProgressForm transformProgressForm;

		public EditForm(FileInfo fileInfo)
		{
			image = getImageFromFileInfo(fileInfo);
			imageAspectRatio = calculateImageAspectRatio(image);

			photoEditor = new PhotoEditor((Bitmap)image, fileInfo.FullName);
			photoEditor.OnePercentOfEditCompleted += updateTransformProgressBar;

			InitializeComponent();

			setPictureBoxImageWithAspectRatio();
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
				InvertColors();
			}
			else if (senderName == colorButton.Name)
			{
				TransformByColor();
			}
			else if (senderName == brightnessTrackBar.Name)
			{
				ChangeBrightness();
			}
			else
			{
				throw new ArgumentException("EditForm.AlterPhoto() could not be performed with the sender - " + sender.ToString());
			}
		}

		private void InvertColors()
		{
			photoEditor.InvertColors();
		}

		private void TransformByColor()
		{
			ColorDialog colorDialog = new ColorDialog();

			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				photoEditor.TransformByColor(colorDialog.Color);
			}
		}

		private void ChangeBrightness()
		{
			int brightnessTrackBarValue = Int32.MinValue;

			brightnessTrackBar.Invoke(new MethodInvoker(delegate { brightnessTrackBarValue = brightnessTrackBar.Value; }));

			if (brightnessTrackBarValue == Int32.MinValue)
			{
				throw new ArgumentException("brightnessTrackBarValue was not properly set.");
			}

			photoEditor.ChangeBrightness(brightnessTrackBarValue);
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

		private void saveAsButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "JPEG (*.jpg)|*.jpg|All files|*.*";

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				photoEditor.saveImageAs(saveFileDialog.FileName);
			}
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

		private double calculateImageAspectRatio(Image image)
		{
			return (double)image.Width / (double)image.Height;
		}

		private void setPictureBoxImageWithAspectRatio(object sender, EventArgs e)
		{
			setPictureBoxImageWithAspectRatio();
		}

		private void setPictureBoxImageWithAspectRatio()
		{
			pictureBox.Width = calculateImageHeightAccordingToAspectRatio();
			centerPictureBox();

			pictureBox.Image = image;
		}

		private int calculateImageHeightAccordingToAspectRatio()
		{
			return (int)(pictureBox.Height * imageAspectRatio);
		}

		private void centerPictureBox()
		{
			pictureBox.Location = new Point((Width - pictureBox.Width) / 2, pictureBox.Location.Y);
		}
	}
}