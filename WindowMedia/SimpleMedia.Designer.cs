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
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.lbxVideo = new System.Windows.Forms.ListBox();
            this.tabZingMp3 = new System.Windows.Forms.TabPage();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.windowMedia)).BeginInit();
            this.tabControl.SuspendLayout();
            this.currentPlayMusicMenu.SuspendLayout();
            this.tabMusic.SuspendLayout();
            this.favoriteMusicMenu.SuspendLayout();
            this.tabVideo.SuspendLayout();
            this.tabZingMp3.SuspendLayout();
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 20);
            this.textBox1.TabIndex = 0;
            // 
            // btnPlayZingMp3
            // 
            this.btnPlayZingMp3.Location = new System.Drawing.Point(250, 4);
            this.btnPlayZingMp3.Name = "btnPlayZingMp3";
            this.btnPlayZingMp3.Size = new System.Drawing.Size(43, 23);
            this.btnPlayZingMp3.TabIndex = 9;
            this.btnPlayZingMp3.Text = "button1";
            this.btnPlayZingMp3.UseVisualStyleBackColor = true;
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
            this.favoriteMusicMenu.Size = new System.Drawing.Size(195, 92);
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
            this.lbxVideoFavorite.FormattingEnabled = true;
            this.lbxVideoFavorite.Location = new System.Drawing.Point(6, 328);
            this.lbxVideoFavorite.Name = "lbxVideoFavorite";
            this.lbxVideoFavorite.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxVideoFavorite.Size = new System.Drawing.Size(289, 277);
            this.lbxVideoFavorite.TabIndex = 1;
            // 
            // lbxVideo
            // 
            this.lbxVideo.FormattingEnabled = true;
            this.lbxVideo.Location = new System.Drawing.Point(6, 4);
            this.lbxVideo.Name = "lbxVideo";
            this.lbxVideo.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxVideo.Size = new System.Drawing.Size(289, 277);
            this.lbxVideo.TabIndex = 2;
            this.lbxVideo.DoubleClick += new System.EventHandler(this.lbxVideo_DoubleClick);
            // 
            // tabZingMp3
            // 
            this.tabZingMp3.AllowDrop = true;
            this.tabZingMp3.Controls.Add(this.textBox1);
            this.tabZingMp3.Controls.Add(this.btnPlayZingMp3);
            this.tabZingMp3.Location = new System.Drawing.Point(4, 34);
            this.tabZingMp3.Name = "tabZingMp3";
            this.tabZingMp3.Padding = new System.Windows.Forms.Padding(3);
            this.tabZingMp3.Size = new System.Drawing.Size(297, 557);
            this.tabZingMp3.TabIndex = 2;
            this.tabZingMp3.Text = "ZingMp3";
            this.tabZingMp3.UseVisualStyleBackColor = true;
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
            this.tabZingMp3.ResumeLayout(false);
            this.tabZingMp3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer windowMedia;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnLoadMusic;
        private System.Windows.Forms.TextBox textBox1;
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
    }
}