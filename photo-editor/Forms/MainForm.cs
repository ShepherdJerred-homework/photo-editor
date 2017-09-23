using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using photo_editor.Forms;

// TODO add splitter control
namespace photo_editor {
    public partial class MainForm : Form {
        private DirectoryInfo rootDirectory;
        private DirectoryModel directoryModel;

        public MainForm() {
            rootDirectory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            directoryModel = new DirectoryModel(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            InitializeComponent();
            RefreshTreeView();
            RefreshListView();

            ListView.Columns.Add("Name");
            ListView.Columns.Add("Last Modification");
            ListView.Columns.Add("File Size (MB)");
        }

        public void UpdateSelectedDirectory(DirectoryInfo directoryInfo) {
            directoryModel.directory = directoryInfo;
            RefreshListView();
            directoryLabel.Text = directoryInfo.FullName;
        }

        // TODO load images async, display them as they are loaded
        public void RefreshListView() {
            ListView.Clear();
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
                item.Tag = file;

                ListView.Items.Add(item);
            }

            noImagesMessage.Visible = files.Length == 0;
        }

        public void RefreshTreeView() {
            TreeView.Nodes.Clear();
            ListDirectory(TreeView, rootDirectory.FullName);
        }

        private void ListDirectory(TreeView treeView, string path) {
            DirectoryInfo rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateTreeNode(rootDirectoryInfo));
        }

        // TODO add image icons
        private static TreeNode CreateTreeNode(DirectoryInfo directoryInfo) {
            TreeNode directoryNode = new TreeNode(directoryInfo.Name);
            try {
                foreach (var directory in directoryInfo.GetDirectories()) {
                    directoryNode.Nodes.Add(CreateTreeNode(directory));
                }
            } catch (UnauthorizedAccessException) {
            }
            directoryNode.Tag = directoryInfo;
            return directoryNode;
        }

        #region MenuStrip Methods

        private void locateOnDiskToolStripMenuItem_Click(object sender, EventArgs e) {
            if (ListView.SelectedItems.Count == 1) {
                string filePath = ((FileInfo) ListView.SelectedItems[0].Tag).FullName;
                Process.Start("explorer.exe", @filePath);
            }
            else if (ListView.SelectedItems.Count < 1) {
                MessageBox.Show("Please select a picture to open in explorer", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void selectRootFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult dialogResult = folderBrowser.ShowDialog();
            if (dialogResult == DialogResult.OK) {
                rootDirectory = new DirectoryInfo(folderBrowser.SelectedPath);
                UpdateSelectedDirectory(rootDirectory);
                RefreshTreeView();
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

        private void viewToolStripMenuItem_Click(object sender, EventArgs e) {
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e) {
            // Load the children (optional)
            // Set as active folder
            TreeNode selectedTreeNode = TreeView.SelectedNode;
            if (selectedTreeNode != null) {
                UpdateSelectedDirectory((DirectoryInfo) selectedTreeNode.Tag);
            }
            // Refresh the list view
        }

        private void ListView_ItemActivate(object sender, EventArgs e) {
            // Open EditForm
            // Ensure only one can open at a time
            EditForm editForm = new EditForm();
            editForm.ShowDialog();
        }
    }
}