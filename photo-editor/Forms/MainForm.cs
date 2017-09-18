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
using photo_editor.Forms;

namespace photo_editor {
    public partial class MainForm : Form {
        private DirectoryInfo rootDirectory;
        private DirectoryModel directoryModel;

        public MainForm() {
            rootDirectory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            directoryModel = new DirectoryModel(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            InitializeComponent();
            populateTreeView();
            RefreshListView();

            ListView.Columns.Add("Name");
            ListView.Columns.Add("Last Modification");
            ListView.Columns.Add("File Size (MB)");
        }

        public void RefreshListView() {
            FileInfo[] files = directoryModel.getImagesInDirectory();

            ImageList smallImagesList = new ImageList();
            smallImagesList.ImageSize = new Size(64, 64);
            ListView.SmallImageList = smallImagesList;

            ImageList largeImageList = new ImageList();
            largeImageList.ImageSize = new Size(128, 128);
            ListView.LargeImageList = largeImageList;

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


                ListView.Items.Add(item);
            }

            noImagesMessage.Visible = files.Length == 0;
        }

        public void populateTreeView() {
            ListDirectory(TreeView, rootDirectory.FullName);
        }

        private void ListDirectory(TreeView treeView, string path) {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo) {
            var directoryNode = new TreeNode(directoryInfo.Name);
            try {
                foreach (var directory in directoryInfo.GetDirectories())
                    directoryNode.Nodes.Add(CreateDirectoryNode(directory));
                foreach (var file in directoryInfo.GetFiles())
                    directoryNode.Nodes.Add(new TreeNode(file.Name));
            }
            catch (UnauthorizedAccessException) {
                
            }
            return directoryNode;
        }

        #region MenuStrip Methods

        private void locateOnDiskToolStripMenuItem_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void selectRootFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult dialogResult = folderBrowser.ShowDialog();
            if (dialogResult == DialogResult.OK) {
                rootDirectory = new DirectoryInfo(folderBrowser.SelectedPath);
                directoryModel.directory = rootDirectory;
                populateTreeView();
                RefreshListView();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e) {
            ListView.View = View.Details;
            uncheckOtherMenuItems(detailToolStripMenuItem);
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e) {
            ListView.View = View.SmallIcon;
            uncheckOtherMenuItems(smallToolStripMenuItem);
        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e) {
            ListView.View = View.LargeIcon;
            uncheckOtherMenuItems(largeToolStripMenuItem);
        }

        private void uncheckOtherMenuItems(ToolStripMenuItem activeMenuItem) {
            foreach (ToolStripMenuItem item in activeMenuItem.Owner.Items) {
                if (activeMenuItem != item) {
                    item.Checked = false;
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            new AboutBox().ShowDialog();
        }

        #endregion

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e) {
            ListView.Clear();
            RefreshListView();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e) {
        }
    }
}