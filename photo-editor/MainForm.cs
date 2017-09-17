using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace photo_editor {

	public partial class photoEditorMainForm : Form {

	    private DirectoryModel directoryModel;

		public photoEditorMainForm() {
            directoryModel = new DirectoryModel();
			InitializeComponent();
            RefreshListView();

		    mainListView.Columns.Add("Name");
		    mainListView.Columns.Add("Last Modification");
		    mainListView.Columns.Add("File Size (MB)");
        }

	    public void RefreshListView() {
	        FileInfo[] files = directoryModel.getImagesInDirectory();

	        ImageList smallImagesList = new ImageList();
	        smallImagesList.ImageSize = new Size(64, 64);
	        mainListView.SmallImageList = smallImagesList;

            ImageList largeImageList = new ImageList();
            largeImageList.ImageSize = new Size(128, 128);
	        mainListView.LargeImageList = largeImageList;

            foreach (var file in files) {
                smallImagesList.Images.Add(file.FullName, Image.FromFile(file.FullName));
                largeImageList.Images.Add(file.FullName, Image.FromFile(file.FullName));

                ListViewItem item = new ListViewItem {
	                Name = file.Name,
                    Text = file.Name,
	                ImageKey = file.FullName
	            };

	            item.SubItems.Add(file.LastWriteTime.ToString(CultureInfo.CurrentCulture));
	            item.SubItems.Add((file.Length / 1024F / 1024F).ToString());
                

	            mainListView.Items.Add(item);
	        }

            Console.WriteLine(mainListView.Items.Count);
	    }

		#region MenuStrip Methods

		private void locateOnDiskToolStripMenuItem_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void selectRootFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void detailToolStripMenuItem_Click(object sender, EventArgs e) {
		    mainListView.View = View.Details;
		}

		private void smallToolStripMenuItem_Click(object sender, EventArgs e) {
		    mainListView.View = View.SmallIcon;
		}

		private void largeToolStripMenuItem_Click(object sender, EventArgs e) {
		    mainListView.View = View.LargeIcon;
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

        #endregion

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e) {
            mainListView.Clear();
            RefreshListView();
        }
    }
}
