using System.Windows.Forms;

namespace photo_editor.Forms
{
	public partial class TransformProgressForm : Form
	{
		public delegate void ImageEditCancelledEvent();
		public event ImageEditCancelledEvent ImageEditCancelled;

		public int ProgressBarValue
		{
			get
			{
				return progressBar.Value;
			}
			set
			{
				if (value > 100)
					progressBar.Value = 100;
				else if (value < 0)
					progressBar.Value = 0;
				else
					progressBar.Value = value;
			}
		}

		public TransformProgressForm()
		{
			InitializeComponent();
		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			ImageEditCancelled();
			Close();
		}
	}
}
