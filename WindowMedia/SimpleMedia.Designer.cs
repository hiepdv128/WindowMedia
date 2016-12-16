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
            this.lbMusics = new System.Windows.Forms.ListBox();
            this.windowMedia = new AxWMPLib.AxWindowsMediaPlayer();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadMusic = new System.Windows.Forms.Button();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.windowMedia)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbMusics
            // 
            this.lbMusics.ContextMenuStrip = this.contextMenu;
            this.lbMusics.FormattingEnabled = true;
            this.lbMusics.Location = new System.Drawing.Point(45, 331);
            this.lbMusics.Name = "lbMusics";
            this.lbMusics.Size = new System.Drawing.Size(546, 95);
            this.lbMusics.TabIndex = 7;
            this.lbMusics.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbMusics_MouseClick);
            // 
            // windowMedia
            // 
            this.windowMedia.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowMedia.Enabled = true;
            this.windowMedia.Location = new System.Drawing.Point(0, 0);
            this.windowMedia.Name = "windowMedia";
            this.windowMedia.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("windowMedia.OcxState")));
            this.windowMedia.Size = new System.Drawing.Size(763, 322);
            this.windowMedia.TabIndex = 6;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Music";
            this.openFileDialog.Filter = "Video|*.mp4|Music|*.mp3";
            this.openFileDialog.Multiselect = true;
            // 
            // btnLoadMusic
            // 
            this.btnLoadMusic.Location = new System.Drawing.Point(607, 345);
            this.btnLoadMusic.Name = "btnLoadMusic";
            this.btnLoadMusic.Size = new System.Drawing.Size(75, 23);
            this.btnLoadMusic.TabIndex = 8;
            this.btnLoadMusic.Text = "Chọn file";
            this.btnLoadMusic.UseVisualStyleBackColor = true;
            this.btnLoadMusic.Click += new System.EventHandler(this.btnLoadMusic_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.favoriteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(117, 70);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.playToolStripMenuItem.Text = "Play";
            // 
            // favoriteToolStripMenuItem
            // 
            this.favoriteToolStripMenuItem.Name = "favoriteToolStripMenuItem";
            this.favoriteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.favoriteToolStripMenuItem.Text = "Favorite";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // SimpleMedia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 499);
            this.Controls.Add(this.lbMusics);
            this.Controls.Add(this.windowMedia);
            this.Controls.Add(this.btnLoadMusic);
            this.Name = "SimpleMedia";
            this.Text = "SimpleMedia";
            ((System.ComponentModel.ISupportInitialize)(this.windowMedia)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbMusics;
        private AxWMPLib.AxWindowsMediaPlayer windowMedia;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnLoadMusic;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem favoriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}