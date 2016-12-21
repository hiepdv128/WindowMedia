using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowMedia
{
    public partial class SimpleMedia : Form
    {
        private Dictionary<string, string> CurrentMusicPlayList { get; set; }
        private Dictionary<string, string> FavoriteMusics { get; set; }
        private Dictionary<string, string> CurrentVideoPlayList { get; set; }
        private Dictionary<string, string> FavoriteVideos { get; set; }
        private List<string> HistoryMusicPlayed { get; set; }
        private List<string> HistoryVideoPlayed { get; set; }

        public SimpleMedia()
        {
            InitializeComponent();

            CurrentMusicPlayList = new Dictionary<string, string>();
            CurrentVideoPlayList = new Dictionary<string, string>();
            FavoriteMusics = new Dictionary<string, string>();
            FavoriteVideos = new Dictionary<string, string>();
            HistoryMusicPlayed = new List<string>();
            HistoryVideoPlayed = new List<string>();
        }

        private void lbMusics_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                lbxMusics.SelectedIndex = lbxMusics.IndexFromPoint(e.Location);
                if (lbxMusics.SelectedIndex != -1)
                {
                    currentPlayMusicMenu.Show();
                }
            }
        }


        private void SimpleMedia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.O && e.Control)
            {
                openFileDialog.ShowDialog();
            }

            if (e.KeyCode == Keys.F && e.Control == true)
                e.Handled = true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabMusic)
            {
                openFileDialog.Filter = @"Music|*.mp3";
                openFileDialog.FileName = "music";
                openFileDialog.ShowDialog();

                Dictionary<string, string> newFiles = openFileDialog.FileNames
                    .ToList()
                    .ToDictionary(Path.GetFileName, filePath => filePath);

                foreach (var kv in newFiles)
                {
                    if (CurrentMusicPlayList.ContainsKey(kv.Key))
                    {
                        continue;
                    }
                    CurrentMusicPlayList.Add(kv.Key, kv.Value);
                    windowMedia.currentPlaylist.appendItem(windowMedia.mediaCollection.add(kv.Value));
                }

                lbxMusics.Items.Clear();
                lbxMusics.Items.AddRange(Enumerable.ToArray(CurrentMusicPlayList.Keys));
                return;
            }

            if (tabControl.SelectedTab == tabVideo)
            {
                openFileDialog.Filter = @"Video|*.mp4";
                openFileDialog.FileName = "Video";
                openFileDialog.ShowDialog();

                Dictionary<string, string> newFiles = openFileDialog.FileNames
                    .ToList()
                    .ToDictionary(Path.GetFileName, filePath => filePath);

                foreach (var kv in newFiles)
                {
                    if (CurrentVideoPlayList.ContainsKey(kv.Key))
                    {
                        continue;
                    }
                    CurrentVideoPlayList.Add(kv.Key, kv.Value);
                }
                lbxVideo.Items.Clear();
                lbxVideo.Items.AddRange(Enumerable.ToArray(CurrentVideoPlayList.Keys));
            }
        }

        private void lbxMusics_DoubleClick(object sender, EventArgs e)
        {
            if (lbxMusics.SelectedItem != null)
            {
                this.PlayMedia(CurrentMusicPlayList[lbxMusics.SelectedItem.ToString()]);

                insertHistory(HistoryMusicPlayed, lbxMusics.SelectedItem.ToString());
                lbxMusics.ClearSelected();
            }
        }

        private void lbxVideo_DoubleClick(object sender, EventArgs e)
        {
            if (lbxVideo.SelectedItem != null)
            {
                this.PlayMedia(CurrentVideoPlayList[lbxVideo.SelectedItem.ToString()]);

                insertHistory(HistoryVideoPlayed, lbxVideo.SelectedItem.ToString());
                lbxVideo.ClearSelected();
            }
        }

        private void PlayMedia(string path)
        {
            windowMedia.playlistCollection.remove(windowMedia.currentPlaylist);
            windowMedia.URL = path;
            windowMedia.Ctlcontrols.play();
        }

        private void insertHistory(List<String> historySet, string value)
        {
            if (historySet.Contains(value))
            {
                historySet.Remove(value);
            }
            historySet.Insert(0, value);
        }

        private void lbxMusics_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbxMusics.SelectedItem == null)
            {
                lbxMusics.ClearSelected();
                currentPlayMusicMenu.Hide();
                return;
            }

            if (e.Button == MouseButtons.Right)
            {
                currentPlayMusicMenu.Show();
            }
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbxMusics.SelectedItems.Count > 0)

                foreach (var musicsSelectedItem in lbxMusics.SelectedItems)
                {
                    windowMedia.currentPlaylist.appendItem(
                        windowMedia.mediaCollection.add(CurrentMusicPlayList[lbxMusics.SelectedItem.ToString()]));
                }
            lbxMusics.ClearSelected();
        }

        private void addToFavoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbxMusics.SelectedItems.Count > 0)

                foreach (var musicsSelectedItem in lbxMusics.SelectedItems)
                {
                    if (lbxMusicFavorites.Items.Contains(musicsSelectedItem.ToString()))
                    {
                        continue;
                    }

                    lbxMusicFavorites.Items.Add(musicsSelectedItem);
                }
            lbxMusics.ClearSelected();
        }

        private void removeFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbxMusics.SelectedItems.Count > 0)
            {
                foreach (string musicsSelectedItem in lbxMusics.SelectedItems.OfType<String>().ToList())
                {
                    lbxMusics.Items.Remove(musicsSelectedItem);
                    CurrentMusicPlayList.Remove(musicsSelectedItem);
                }
                lbxMusics.ClearSelected();
            }
        }

        private void goToFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbxMusics.SelectedItem != null)
            {
                string directory = Path.GetDirectoryName(CurrentMusicPlayList[lbxMusics.SelectedItem.ToString()]);
                Process.Start("explorer.exe", directory);
                lbxMusics.ClearSelected();
            }
        }

        private void playToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lbxMusicFavorites.SelectedItems.Count > 0)
            {
                foreach (var selectedItem in lbxMusicFavorites.SelectedItems)
                {
                    if (lbxMusics.Items.Contains(selectedItem))
                    {
                        continue;
                    }
                    lbxMusics.Items.Add(selectedItem.ToString());
                }
                lbxMusicFavorites.ClearSelected();
            }
        }

        private void favoriteMusicRemoveMenuItem_Click(object sender, EventArgs e)
        {
            if (lbxMusicFavorites.SelectedItems.Count > 0)
            {
                foreach (var selectedItem in lbxMusicFavorites.SelectedItems.OfType<String>().ToList())
                {
                    lbxMusicFavorites.Items.Remove(selectedItem);
                }
                lbxMusicFavorites.ClearSelected();
            }
        }

        private void showFolderMusicFavoriteMenuItem_Click(object sender, EventArgs e)
        {
            if (lbxMusicFavorites.SelectedItem != null)
            {
                string directory = Path.GetDirectoryName(CurrentMusicPlayList[lbxMusicFavorites.SelectedItem.ToString()]);
                Process.Start("explorer.exe", directory);
                lbxMusicFavorites.ClearSelected();
            }
        }
    }
}