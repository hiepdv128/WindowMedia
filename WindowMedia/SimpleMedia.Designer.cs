namespace WindowMedia
{
    partial class SimpleMedia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleMedia));
            this.windowMedia = new AxWMPLib.AxWindowsMediaPlayer();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadMusic = new System.Windows.Forms.Button();
            this.txtLinkZingMp3 = new System.Windows.Forms.TextBox();
            this.btnPlayZingMp3 = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.currentPlayMusicMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playMusicMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToMusicFavoriteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeMusicMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFolderMusicMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMusic = new System.Windows.Forms.TabPage();
            this.lbxMusics = new System.Windows.Forms.ListBox();
            this.lbxMusicFavorites = new System.Windows.Forms.ListBox();
            this.favoriteMusicMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToCurrentMusicMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favoriteMusicRemoveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFolderMusicFavoriteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabVideo = new System.Windows.Forms.TabPage();
            this.lbxVideoFavorite = new System.Windows.Forms.ListBox();
            this.favoriteVideoMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCurrentPlayMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFavoriteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.showFolderFavoriteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.lbxVideo = new System.Windows.Forms.ListBox();
            this.currentPlayVideoMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playVideoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addFavoriteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.removeItemVideoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.showFolderMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tabZingMp3 = new System.Windows.Forms.TabPage();
            this.progressDownload = new System.Windows.Forms.ProgressBar();
            this.linkDownloadZingMp3 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbxDownLoad = new System.Windows.Forms.ListBox();
            this.lbxZingMp3History = new System.Windows.Forms.ListBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.historyPlayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.windowMedia)).BeginInit();
            this.tabControl.SuspendLayout();
            this.currentPlayMusicMenu.SuspendLayout();
            this.tabMusic.SuspendLayout();
            this.favoriteMusicMenu.SuspendLayout();
            this.tabVideo.SuspendLayout();
            this.favoriteVideoMenu.SuspendLayout();
            this.currentPlayVideoMenu.SuspendLayout();
            this.tabZingMp3.SuspendLayout();
            this.historyPlayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // windowMedia
            // 
            this.windowMedia.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowMedia.Enabled = true;
            this.windowMedia.Location = new System.Drawing.Point(0, 0);
            this.windowMedia.Name = "windowMedia";
            this.windowMedia.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("windowMedia.OcxState")));
            this.windowMedia.Size = new System.Drawing.Size(910, 646);
            this.windowMedia.TabIndex = 6;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Video|*.mp4|Music|*.mp3";
            this.openFileDialog.Multiselect = true;
            // 
            // btnLoadMusic
            // 
            this.btnLoadMusic.Location = new System.Drawing.Point(770, 531);
            this.btnLoadMusic.Name = "btnLoadMusic";
            this.btnLoadMusic.Size = new System.Drawing.Size(75, 23);
            this.btnLoadMusic.TabIndex = 8;
            this.btnLoadMusic.Text = "Chọn file";
            this.btnLoadMusic.UseVisualStyleBackColor = true;
            // 
            // txtLinkZingMp3
            // 
            this.txtLinkZingMp3.Location = new System.Drawing.Point(3, 6);
            this.txtLinkZingMp3.Name = "txtLinkZingMp3";
            this.txtLinkZingMp3.Size = new System.Drawing.Size(241, 20);
            this.txtLinkZingMp3.TabIndex = 0;
            // 
            // btnPlayZingMp3
            // 
            this.btnPlayZingMp3.Location = new System.Drawing.Point(250, 4);
            this.btnPlayZingMp3.Name = "btnPlayZingMp3";
            this.btnPlayZingMp3.Size = new System.Drawing.Size(43, 23);
            this.btnPlayZingMp3.TabIndex = 9;
            this.btnPlayZingMp3.Text = "Play";
            this.btnPlayZingMp3.UseVisualStyleBackColor = true;
            this.btnPlayZingMp3.Click += new System.EventHandler(this.btnPlayZingMp3_Click);
            // 
            // tabControl
            // 
            this.tabControl.ContextMenuStrip = this.currentPlayMusicMenu;
            this.tabControl.Controls.Add(this.tabMusic);
            this.tabControl.Controls.Add(this.tabVideo);
            this.tabControl.Controls.Add(this.tabZingMp3);
            this.tabControl.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControl.Location = new System.Drawing.Point(912, 51);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(305, 595);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 10;
            // 
            // currentPlayMusicMenu
            // 
            this.currentPlayMusicMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playMusicMenuItem,
            this.addToMusicFavoriteMenuItem,
            this.removeMusicMenuItem,
            this.showFolderMusicMenuItem});
            this.currentPlayMusicMenu.Name = "contextMenu";
            this.currentPlayMusicMenu.Size = new System.Drawing.Size(165, 92);
            // 
            // playMusicMenuItem
            // 
            this.playMusicMenuItem.Name = "playMusicMenuItem";
            this.playMusicMenuItem.Size = new System.Drawing.Size(164, 22);
            this.playMusicMenuItem.Text = "Play";
            this.playMusicMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // addToMusicFavoriteMenuItem
            // 
            this.addToMusicFavoriteMenuItem.Name = "addToMusicFavoriteMenuItem";
            this.addToMusicFavoriteMenuItem.Size = new System.Drawing.Size(164, 22);
            this.addToMusicFavoriteMenuItem.Text = "Add to favorite";
            this.addToMusicFavoriteMenuItem.Click += new System.EventHandler(this.addToFavoriteToolStripMenuItem_Click);
            // 
            // removeMusicMenuItem
            // 
            this.removeMusicMenuItem.Name = "removeMusicMenuItem";
            this.removeMusicMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeMusicMenuItem.Text = "Remove from list";
            this.removeMusicMenuItem.Click += new System.EventHandler(this.removeFromListToolStripMenuItem_Click);
            // 
            // showFolderMusicMenuItem
            // 
            this.showFolderMusicMenuItem.Name = "showFolderMusicMenuItem";
            this.showFolderMusicMenuItem.Size = new System.Drawing.Size(164, 22);
            this.showFolderMusicMenuItem.Text = "Go to folder";
            this.showFolderMusicMenuItem.Click += new System.EventHandler(this.goToFolderToolStripMenuItem_Click);
            // 
            // tabMusic
            // 
            this.tabMusic.Controls.Add(this.lbxMusics);
            this.tabMusic.Controls.Add(this.lbxMusicFavorites);
            this.tabMusic.Location = new System.Drawing.Point(4, 34);
            this.tabMusic.Name = "tabMusic";
            this.tabMusic.Padding = new System.Windows.Forms.Padding(3);
            this.tabMusic.Size = new System.Drawing.Size(297, 557);
            this.tabMusic.TabIndex = 0;
            this.tabMusic.Text = "Music";
            this.tabMusic.UseVisualStyleBackColor = true;
            // 
            // lbxMusics
            // 
            this.lbxMusics.AllowDrop = true;
            this.lbxMusics.ContextMenuStrip = this.currentPlayMusicMenu;
            this.lbxMusics.FormattingEnabled = true;
            this.lbxMusics.Location = new System.Drawing.Point(5, 6);
            this.lbxMusics.Name = "lbxMusics";
            this.lbxMusics.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxMusics.Size = new System.Drawing.Size(289, 277);
            this.lbxMusics.TabIndex = 0;
            this.lbxMusics.DoubleClick += new System.EventHandler(this.lbxMusics_DoubleClick);
            this.lbxMusics.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbxMusics_MouseDown);
            // 
            // lbxMusicFavorites
            // 
            this.lbxMusicFavorites.ContextMenuStrip = this.favoriteMusicMenu;
            this.lbxMusicFavorites.FormattingEnabled = true;
            this.lbxMusicFavorites.Location = new System.Drawing.Point(6, 328);
            this.lbxMusicFavorites.Name = "lbxMusicFavorites";
            this.lbxMusicFavorites.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxMusicFavorites.Size = new System.Drawing.Size(289, 277);
            this.lbxMusicFavorites.TabIndex = 0;
            // 
            // favoriteMusicMenu
            // 
            this.favoriteMusicMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToCurrentMusicMenuItem,
            this.favoriteMusicRemoveMenuItem,
            this.showFolderMusicFavoriteMenuItem});
            this.favoriteMusicMenu.Name = "favoriteContextMenu";
            this.favoriteMusicMenu.Size = new System.Drawing.Size(195, 70);
            // 
            // addToCurrentMusicMenuItem
            // 
            this.addToCurrentMusicMenuItem.Name = "addToCurrentMusicMenuItem";
            this.addToCurrentMusicMenuItem.Size = new System.Drawing.Size(194, 22);
            this.addToCurrentMusicMenuItem.Text = "Add to current play list";
            this.addToCurrentMusicMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem1_Click);
            // 
            // favoriteMusicRemoveMenuItem
            // 
            this.favoriteMusicRemoveMenuItem.Name = "favoriteMusicRemoveMenuItem";
            this.favoriteMusicRemoveMenuItem.Size = new System.Drawing.Size(194, 22);
            this.favoriteMusicRemoveMenuItem.Text = "Remove from list";
            this.favoriteMusicRemoveMenuItem.Click += new System.EventHandler(this.favoriteMusicRemoveMenuItem_Click);
            // 
            // showFolderMusicFavoriteMenuItem
            // 
            this.showFolderMusicFavoriteMenuItem.Name = "showFolderMusicFavoriteMenuItem";
            this.showFolderMusicFavoriteMenuItem.Size = new System.Drawing.Size(194, 22);
            this.showFolderMusicFavoriteMenuItem.Text = "Go to folder";
            this.showFolderMusicFavoriteMenuItem.Click += new System.EventHandler(this.showFolderMusicFavoriteMenuItem_Click);
            // 
            // tabVideo
            // 
            this.tabVideo.Controls.Add(this.lbxVideoFavorite);
            this.tabVideo.Controls.Add(this.lbxVideo);
            this.tabVideo.Location = new System.Drawing.Point(4, 34);
            this.tabVideo.Name = "tabVideo";
            this.tabVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabVideo.Size = new System.Drawing.Size(297, 557);
            this.tabVideo.TabIndex = 1;
            this.tabVideo.Text = "Video";
            this.tabVideo.UseVisualStyleBackColor = true;
            // 
            // lbxVideoFavorite
            // 
            this.lbxVideoFavorite.ContextMenuStrip = this.favoriteVideoMenu;
            this.lbxVideoFavorite.FormattingEnabled = true;
            this.lbxVideoFavorite.Location = new System.Drawing.Point(6, 328);
            this.lbxVideoFavorite.Name = "lbxVideoFavorite";
            this.lbxVideoFavorite.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxVideoFavorite.Size = new System.Drawing.Size(289, 277);
            this.lbxVideoFavorite.TabIndex = 1;
            // 
            // favoriteVideoMenu
            // 
            this.favoriteVideoMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCurrentPlayMenu,
            this.removeFavoriteMenu,
            this.showFolderFavoriteMenu});
            this.favoriteVideoMenu.Name = "favoriteContextMenu";
            this.favoriteVideoMenu.Size = new System.Drawing.Size(195, 70);
            // 
            // addCurrentPlayMenu
            // 
            this.addCurrentPlayMenu.Name = "addCurrentPlayMenu";
            this.addCurrentPlayMenu.Size = new System.Drawing.Size(194, 22);
            this.addCurrentPlayMenu.Text = "Add to current play list";
            this.addCurrentPlayMenu.Click += new System.EventHandler(this.addCurrentPlayMenu_Click);
            // 
            // removeFavoriteMenu
            // 
            this.removeFavoriteMenu.Name = "removeFavoriteMenu";
            this.removeFavoriteMenu.Size = new System.Drawing.Size(194, 22);
            this.removeFavoriteMenu.Text = "Remove from list";
            this.removeFavoriteMenu.Click += new System.EventHandler(this.removeFavoriteMenu_Click);
            // 
            // showFolderFavoriteMenu
            // 
            this.showFolderFavoriteMenu.Name = "showFolderFavoriteMenu";
            this.showFolderFavoriteMenu.Size = new System.Drawing.Size(194, 22);
            this.showFolderFavoriteMenu.Text = "Go to folder";
            this.showFolderFavoriteMenu.Click += new System.EventHandler(this.showFolderFavoriteMenu_Click);
            // 
            // lbxVideo
            // 
            this.lbxVideo.ContextMenuStrip = this.currentPlayVideoMenu;
            this.lbxVideo.FormattingEnabled = true;
            this.lbxVideo.Location = new System.Drawing.Point(6, 4);
            this.lbxVideo.Name = "lbxVideo";
            this.lbxVideo.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxVideo.Size = new System.Drawing.Size(289, 277);
            this.lbxVideo.TabIndex = 2;
            this.lbxVideo.DoubleClick += new System.EventHandler(this.lbxVideo_DoubleClick);
            // 
            // currentPlayVideoMenu
            // 
            this.currentPlayVideoMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playVideoMenu,
            this.addFavoriteMenu,
            this.removeItemVideoMenu,
            this.showFolderMenu});
            this.currentPlayVideoMenu.Name = "contextMenu";
            this.currentPlayVideoMenu.Size = new System.Drawing.Size(165, 92);
            // 
            // playVideoMenu
            // 
            this.playVideoMenu.Name = "playVideoMenu";
            this.playVideoMenu.Size = new System.Drawing.Size(164, 22);
            this.playVideoMenu.Text = "Play";
            this.playVideoMenu.Click += new System.EventHandler(this.playVideoMenu_Click);
            // 
            // addFavoriteMenu
            // 
            this.addFavoriteMenu.Name = "addFavoriteMenu";
            this.addFavoriteMenu.Size = new System.Drawing.Size(164, 22);
            this.addFavoriteMenu.Text = "Add to favorite";
            this.addFavoriteMenu.Click += new System.EventHandler(this.addFavoriteMenu_Click);
            // 
            // removeItemVideoMenu
            // 
            this.removeItemVideoMenu.Name = "removeItemVideoMenu";
            this.removeItemVideoMenu.Size = new System.Drawing.Size(164, 22);
            this.removeItemVideoMenu.Text = "Remove from list";
            this.removeItemVideoMenu.Click += new System.EventHandler(this.removeItemVideoMenu_Click);
            // 
            // showFolderMenu
            // 
            this.showFolderMenu.Name = "showFolderMenu";
            this.showFolderMenu.Size = new System.Drawing.Size(164, 22);
            this.showFolderMenu.Text = "Go to folder";
            this.showFolderMenu.Click += new System.EventHandler(this.showFolderMenu_Click);
            // 
            // tabZingMp3
            // 
            this.tabZingMp3.AllowDrop = true;
            this.tabZingMp3.Controls.Add(this.progressDownload);
            this.tabZingMp3.Controls.Add(this.linkDownloadZingMp3);
            this.tabZingMp3.Controls.Add(this.label2);
            this.tabZingMp3.Controls.Add(this.label1);
            this.tabZingMp3.Controls.Add(this.lbxDownLoad);
            this.tabZingMp3.Controls.Add(this.lbxZingMp3History);
            this.tabZingMp3.Controls.Add(this.txtLinkZingMp3);
            this.tabZingMp3.Controls.Add(this.btnPlayZingMp3);
            this.tabZingMp3.Location = new System.Drawing.Point(4, 34);
            this.tabZingMp3.Name = "tabZingMp3";
            this.tabZingMp3.Padding = new System.Windows.Forms.Padding(3);
            this.tabZingMp3.Size = new System.Drawing.Size(297, 557);
            this.tabZingMp3.TabIndex = 2;
            this.tabZingMp3.Text = "ZingMp3";
            this.tabZingMp3.UseVisualStyleBackColor = true;
            // 
            // progressDownload
            // 
            this.progressDownload.BackColor = System.Drawing.SystemColors.Control;
            this.progressDownload.Location = new System.Drawing.Point(10, 46);
            this.progressDownload.Name = "progressDownload";
            this.progressDownload.Size = new System.Drawing.Size(269, 10);
            this.progressDownload.TabIndex = 13;
            // 
            // linkDownloadZingMp3
            // 
            this.linkDownloadZingMp3.AutoSize = true;
            this.linkDownloadZingMp3.Location = new System.Drawing.Point(80, 29);
            this.linkDownloadZingMp3.Name = "linkDownloadZingMp3";
            this.linkDownloadZingMp3.Size = new System.Drawing.Size(139, 13);
            this.linkDownloadZingMp3.TabIndex = 12;
            this.linkDownloadZingMp3.TabStop = true;
            this.linkDownloadZingMp3.Text = "Like this, you can download";
            this.linkDownloadZingMp3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDownloadZingMp3_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "History play";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Download";
            // 
            // lbxDownLoad
            // 
            this.lbxDownLoad.FormattingEnabled = true;
            this.lbxDownLoad.Location = new System.Drawing.Point(10, 324);
            this.lbxDownLoad.Name = "lbxDownLoad";
            this.lbxDownLoad.Size = new System.Drawing.Size(284, 225);
            this.lbxDownLoad.TabIndex = 10;
            // 
            // lbxZingMp3History
            // 
            this.lbxZingMp3History.FormattingEnabled = true;
            this.lbxZingMp3History.Location = new System.Drawing.Point(9, 77);
            this.lbxZingMp3History.Name = "lbxZingMp3History";
            this.lbxZingMp3History.Size = new System.Drawing.Size(284, 225);
            this.lbxZingMp3History.TabIndex = 10;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(1109, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 12;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(933, 17);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(35, 13);
            this.lblUsername.TabIndex = 13;
            this.lblUsername.Text = "label1";
            // 
            // historyPlayMenu
            // 
            this.historyPlayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10});
            this.historyPlayMenu.Name = "favoriteContextMenu";
            this.historyPlayMenu.Size = new System.Drawing.Size(195, 70);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem8.Text = "Add to current play list";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem9.Text = "Remove from list";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem10.Text = "Go to folder";
            // 
            // SimpleMedia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 646);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.windowMedia);
            this.Controls.Add(this.btnLoadMusic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SimpleMedia";
            this.Text = "SimpleMedia";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SimpleMedia_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.windowMedia)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.currentPlayMusicMenu.ResumeLayout(false);
            this.tabMusic.ResumeLayout(false);
            this.favoriteMusicMenu.ResumeLayout(false);
            this.tabVideo.ResumeLayout(false);
            this.favoriteVideoMenu.ResumeLayout(false);
            this.currentPlayVideoMenu.ResumeLayout(false);
            this.tabZingMp3.ResumeLayout(false);
            this.tabZingMp3.PerformLayout();
            this.historyPlayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer windowMedia;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnLoadMusic;
        private System.Windows.Forms.TextBox txtLinkZingMp3;
        private System.Windows.Forms.Button btnPlayZingMp3;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMusic;
        private System.Windows.Forms.TabPage tabVideo;
        private System.Windows.Forms.TabPage tabZingMp3;
        private System.Windows.Forms.ListBox lbxMusicFavorites;
        private System.Windows.Forms.ListBox lbxVideoFavorite;
        private System.Windows.Forms.ListBox lbxVideo;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.ContextMenuStrip currentPlayMusicMenu;
        private System.Windows.Forms.ListBox lbxMusics;
        private System.Windows.Forms.ToolStripMenuItem playMusicMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToMusicFavoriteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeMusicMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showFolderMusicMenuItem;
        private System.Windows.Forms.ContextMenuStrip favoriteMusicMenu;
        private System.Windows.Forms.ToolStripMenuItem addToCurrentMusicMenuItem;
        private System.Windows.Forms.ToolStripMenuItem favoriteMusicRemoveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showFolderMusicFavoriteMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbxDownLoad;
        private System.Windows.Forms.ListBox lbxZingMp3History;
        private System.Windows.Forms.ContextMenuStrip currentPlayVideoMenu;
        private System.Windows.Forms.ToolStripMenuItem playVideoMenu;
        private System.Windows.Forms.ToolStripMenuItem addFavoriteMenu;
        private System.Windows.Forms.ToolStripMenuItem removeItemVideoMenu;
        private System.Windows.Forms.ToolStripMenuItem showFolderMenu;
        private System.Windows.Forms.ContextMenuStrip favoriteVideoMenu;
        private System.Windows.Forms.ToolStripMenuItem addCurrentPlayMenu;
        private System.Windows.Forms.ToolStripMenuItem removeFavoriteMenu;
        private System.Windows.Forms.ToolStripMenuItem showFolderFavoriteMenu;
        private System.Windows.Forms.LinkLabel linkDownloadZingMp3;
        private System.Windows.Forms.ContextMenuStrip historyPlayMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressDownload;
    }
}