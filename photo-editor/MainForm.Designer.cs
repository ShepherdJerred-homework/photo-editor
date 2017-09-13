namespace photo_editor {
    partial class photoEditorMainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.mainFormMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.locateOnDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectRootFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.detailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.smallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.largeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.directoriesTreeView = new System.Windows.Forms.TreeView();
			this.picturesListView = new System.Windows.Forms.ListView();
			this.mainFormMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainFormMenuStrip
			// 
			this.mainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.mainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainFormMenuStrip.Name = "mainFormMenuStrip";
			this.mainFormMenuStrip.Size = new System.Drawing.Size(793, 24);
			this.mainFormMenuStrip.TabIndex = 0;
			this.mainFormMenuStrip.Text = "MainFormMenuStrip";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locateOnDiskToolStripMenuItem,
            this.selectRootFolderToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// locateOnDiskToolStripMenuItem
			// 
			this.locateOnDiskToolStripMenuItem.Name = "locateOnDiskToolStripMenuItem";
			this.locateOnDiskToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.locateOnDiskToolStripMenuItem.Text = "&Locate on Disk";
			this.locateOnDiskToolStripMenuItem.Click += new System.EventHandler(this.locateOnDiskToolStripMenuItem_Click);
			// 
			// selectRootFolderToolStripMenuItem
			// 
			this.selectRootFolderToolStripMenuItem.Name = "selectRootFolderToolStripMenuItem";
			this.selectRootFolderToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.selectRootFolderToolStripMenuItem.Text = "&Select Root Folder";
			this.selectRootFolderToolStripMenuItem.Click += new System.EventHandler(this.selectRootFolderToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailToolStripMenuItem,
            this.smallToolStripMenuItem,
            this.largeToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// detailToolStripMenuItem
			// 
			this.detailToolStripMenuItem.Name = "detailToolStripMenuItem";
			this.detailToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.detailToolStripMenuItem.Text = "&Detail";
			this.detailToolStripMenuItem.Click += new System.EventHandler(this.detailToolStripMenuItem_Click);
			// 
			// smallToolStripMenuItem
			// 
			this.smallToolStripMenuItem.Name = "smallToolStripMenuItem";
			this.smallToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.smallToolStripMenuItem.Text = "&Small";
			this.smallToolStripMenuItem.Click += new System.EventHandler(this.smallToolStripMenuItem_Click);
			// 
			// largeToolStripMenuItem
			// 
			this.largeToolStripMenuItem.Name = "largeToolStripMenuItem";
			this.largeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.largeToolStripMenuItem.Text = "&Large";
			this.largeToolStripMenuItem.Click += new System.EventHandler(this.largeToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.aboutToolStripMenuItem.Text = "&About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// directoriesTreeView
			// 
			this.directoriesTreeView.Location = new System.Drawing.Point(12, 27);
			this.directoriesTreeView.Name = "directoriesTreeView";
			this.directoriesTreeView.Size = new System.Drawing.Size(200, 422);
			this.directoriesTreeView.TabIndex = 1;
			// 
			// picturesListView
			// 
			this.picturesListView.Location = new System.Drawing.Point(218, 27);
			this.picturesListView.Name = "picturesListView";
			this.picturesListView.Size = new System.Drawing.Size(563, 422);
			this.picturesListView.TabIndex = 2;
			this.picturesListView.UseCompatibleStateImageBehavior = false;
			// 
			// photoEditorMainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(793, 461);
			this.Controls.Add(this.picturesListView);
			this.Controls.Add(this.directoriesTreeView);
			this.Controls.Add(this.mainFormMenuStrip);
			this.MainMenuStrip = this.mainFormMenuStrip;
			this.Name = "photoEditorMainForm";
			this.Text = "Photo Editor";
			this.mainFormMenuStrip.ResumeLayout(false);
			this.mainFormMenuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.MenuStrip mainFormMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem locateOnDiskToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectRootFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem detailToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem smallToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem largeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.TreeView directoriesTreeView;
		private System.Windows.Forms.ListView picturesListView;
	}
}

