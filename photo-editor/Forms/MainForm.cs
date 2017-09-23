using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using photo_editor.Forms;

// TODO resize views
// TODO fix duplicate images
// TODO expand tree levels on start
// TODO add splitter control
namespace photo_editor {
    public partial class MainForm : Form {
        private DirectoryInfo rootDirectory;
        private DirectoryModel directoryModel;

        public MainForm() {
            rootDirectory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            directoryModel = new DirectoryModel();
            InitializeComponent();

            RefreshTreeView();

            ListView.Columns.Add("Name");
            ListView.Columns.Add("Last Modification");
            ListView.Columns.Add("File Size (MB)");

            // For some reason this method doesn't need to be called??
//            UpdateSelectedDirectory(rootDirectory);
        }

        public void UpdateSelectedDirectory(DirectoryInfo directoryInfo) {
            directoryModel.directory = directoryInfo;
            directoryLabel.Text = directoryInfo.FullName;
            itemCount.Text = directoryModel.getImagesInDirectory().Length + " items";
            RefreshListView();
        }

        // TODO load images async, display them as they are loaded (should be done?)
        public async void RefreshListView() {
            ListView.Items.Clear();

            noImagesMessage.Visible = directoryModel.getImagesInDirectory().Length == 0;

            if (directoryModel.getImagesInDirectory().Length > 0) {
                await Task.Run(() => {
                    FileInfo[] files = directoryModel.getImagesInDirectory();

                    ImageList smallImagesList = new ImageList();
                    smallImagesList.ImageSize = new Size(64, 64);

                    ImageList largeImageList = new ImageList();
                    largeImageList.ImageSize = new Size(128, 128);

                    ListView.Invoke((MethodInvoker) delegate {
                        ListView.SmallImageList = smallImagesList;
                        ListView.LargeImageList = largeImageList;
                    });

                    imageLoadingBar.Invoke((MethodInvoker) delegate {
                        imageLoadingBar.Value = 0;
                        imageLoadingBar.Maximum = directoryModel.getImagesInDirectory().Length;
                    });

                    foreach (var file in files) {
                        imageLoadingBar.Invoke((MethodInvoker) delegate { imageLoadingBar.PerformStep(); });

                        ListView.Invoke((MethodInvoker) delegate {
                            smallImagesList.Images.Add(file.FullName, Image.FromFile(file.FullName));
                            largeImageList.Images.Add(file.FullName, Image.FromFile(file.FullName));
                        });

                        ListViewItem item = new ListViewItem {
                            Name = file.Name,
                            Text = file.Name,
                            ImageKey = file.FullName
                        };

                        item.SubItems.Add(file.LastWriteTime.ToString(CultureInfo.CurrentCulture));
                        item.SubItems.Add((file.Length / 1024F / 1024F).ToString());
                        item.Tag = file;

                        ListView.Invoke((MethodInvoker) delegate { ListView.Items.Add(item); });
                    }
                });
            }
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
            }
            catch (UnauthorizedAccessException) {
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
            TreeNode selectedTreeNode = TreeView.SelectedNode;
            if (selectedTreeNode != null) {
                UpdateSelectedDirectory((DirectoryInfo) selectedTreeNode.Tag);
            }
        }

        private void ListView_ItemActivate(object sender, EventArgs e) {
            EditForm editForm = new EditForm((FileInfo) ListView.SelectedItems[0].Tag);
            editForm.ShowDialog();
        }
    }
}