﻿using System;
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
        private DirectoryModel directoryModel;

        public MainForm() {
            directoryModel = new DirectoryModel();
            InitializeComponent();
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

        #region MenuStrip Methods

        private void locateOnDiskToolStripMenuItem_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void selectRootFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult dialogResult = folderBrowser.ShowDialog();
            if (dialogResult == DialogResult.OK) {
                directoryModel.directory = new DirectoryInfo(folderBrowser.SelectedPath);
                RefreshListView();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e) {
            ListView.View = View.Details;
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e) {
            ListView.View = View.SmallIcon;
        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e) {
            ListView.View = View.LargeIcon;
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