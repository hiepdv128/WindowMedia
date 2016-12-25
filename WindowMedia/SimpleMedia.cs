using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using unirest_net.http;
using WMPLib;

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
        private string tabTag;
        private string[] ExtentionSupports = { ".mp3", ".mp4", ".avi", ".mwn", ".3gp", ".mkv" };

        private ResourceTransporter resourceTransporter;
        private string username = "test";

        private class TAG
        {
            public static string MUSIC = "music";
            public static string VIDEO = "video";
            public static string ONLINE = "online";
        }

        public SimpleMedia()
        {
            InitializeComponent();
            tabTag = TAG.MUSIC;

            resourceTransporter = new ResourceTransporter();

            CurrentMusicPlayList = new Dictionary<string, string>();
            CurrentVideoPlayList = new Dictionary<string, string>();
            FavoriteMusics = new Dictionary<string, string>();
            FavoriteVideos = new Dictionary<string, string>();
            HistoryMusicPlayed = new List<string>();
            HistoryVideoPlayed = new List<string>();

            lblUsername.Text = this.username;
        }

        public void setUsername(string username)
        {
            this.username = username;
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
                }

                lbxMusics.Items.Clear();
                lbxMusics.Items.AddRange(Enumerable.ToArray(CurrentMusicPlayList.Keys));
                lbxMusics.Sorted = true;
                return;
            }

            if (tabControl.SelectedTab == tabVideo)
            {
                openFileDialog.Filter = @"MP4|*.mp4|AVI|*.avi";
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
            if (!tabTag.Equals(TAG.MUSIC))
            {
                windowMedia.currentPlaylist.clear();
            }

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
            windowMedia.settings.setMode("shuffle", true);
            if (lbxMusics.SelectedItems.Count > 0)
            {
                if (lbxMusics.SelectedItems.Count == 1)
                {
                    IWMPMedia mediaInserted =
                        windowMedia.mediaCollection.add(CurrentMusicPlayList[lbxMusics.SelectedItem.ToString()]);
                    windowMedia.Ctlcontrols.playItem(mediaInserted);
                    return;
                }

                foreach (var musicsSelectedItem in lbxMusics.SelectedItems)
                {
                    windowMedia.currentPlaylist.appendItem(
                        windowMedia.mediaCollection.add(CurrentMusicPlayList[musicsSelectedItem.ToString()]));
                    windowMedia.Ctlcontrols.play();
                }
            }
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

        private void playVideoMenu_Click(object sender, EventArgs e)
        {
            windowMedia.settings.setMode("shuffle", true);
            if (lbxVideo.SelectedItems.Count > 0)
            {
                if (lbxVideo.SelectedItems.Count == 1)
                {
                    IWMPMedia mediaInserted =
                        windowMedia.mediaCollection.add(CurrentMusicPlayList[lbxVideo.SelectedItem.ToString()]);
                    windowMedia.Ctlcontrols.playItem(mediaInserted);
                    return;
                }

                foreach (var videoSelectedItem in lbxVideo.SelectedItems)
                {
                    windowMedia.currentPlaylist.appendItem(
                        windowMedia.mediaCollection.add(CurrentMusicPlayList[videoSelectedItem.ToString()]));
                    windowMedia.Ctlcontrols.play();
                }
            }
        }

        private void addFavoriteMenu_Click(object sender, EventArgs e)
        {
            if (lbxVideo.SelectedItems.Count > 0)

                foreach (var videoSelectedItem in lbxVideo.SelectedItems)
                {
                    if (lbxVideoFavorite.Items.Contains(videoSelectedItem.ToString()))
                    {
                        continue;
                    }

                    lbxVideoFavorite.Items.Add(videoSelectedItem);
                }
            lbxVideo.ClearSelected();
        }

        private void removeItemVideoMenu_Click(object sender, EventArgs e)
        {
            if (lbxVideo.SelectedItems.Count > 0)
            {
                foreach (string videoSelectedItem in lbxVideo.SelectedItems.OfType<String>().ToList())
                {
                    lbxVideo.Items.Remove(videoSelectedItem);
                    CurrentMusicPlayList.Remove(videoSelectedItem);
                }
                lbxVideo.ClearSelected();
            }
        }

        private void showFolderMenu_Click(object sender, EventArgs e)
        {
            if (lbxVideo.SelectedItem != null)
            {
                string directory = Path.GetDirectoryName(CurrentMusicPlayList[lbxVideo.SelectedItem.ToString()]);
                Process.Start("explorer.exe", directory);
                lbxVideo.ClearSelected();
            }
        }

        private void addCurrentPlayMenu_Click(object sender, EventArgs e)
        {
            if (lbxVideoFavorite.SelectedItems.Count > 0)
            {
                foreach (var selectedItem in lbxVideoFavorite.SelectedItems)
                {
                    if (lbxVideo.Items.Contains(selectedItem))
                    {
                        continue;
                    }
                    lbxVideo.Items.Add(selectedItem.ToString());
                }
                lbxVideoFavorite.ClearSelected();
            }
        }

        private void removeFavoriteMenu_Click(object sender, EventArgs e)
        {
            if (lbxVideoFavorite.SelectedItems.Count > 0)
            {
                foreach (var selectedItem in lbxVideoFavorite.SelectedItems.OfType<String>().ToList())
                {
                    lbxVideoFavorite.Items.Remove(selectedItem);
                }
                lbxVideoFavorite.ClearSelected();
            }
        }

        private void showFolderFavoriteMenu_Click(object sender, EventArgs e)
        {
            if (lbxVideoFavorite.SelectedItem != null)
            {
                string directory = Path.GetDirectoryName(CurrentMusicPlayList[lbxVideoFavorite.SelectedItem.ToString()]);
                Process.Start("explorer.exe", directory);
                lbxVideoFavorite.ClearSelected();
            }
        }

        private void btnPlayZingMp3_Click(object sender, EventArgs e)
        {
            tabTag = TAG.ONLINE;

            String baseUrl = txtLink.Text.Trim();

            if (!baseUrl.Contains("mp3.zing.vn") && !ExtentionSupports.Contains(Path.GetExtension(baseUrl)))
            {
                MessageBox.Show("Url nhập không hợp lệ, vui lòng tìm url khác");
                return;
            }

            if (baseUrl.Contains("mp3.zing.vn"))
            {
                this.playZingMp3(baseUrl);
                return;
            }

            playUnkhowSource(baseUrl);
        }

        private void playUnkhowSource(String sourceUrl)
        {
            windowMedia.URL = sourceUrl;
            windowMedia.Ctlcontrols.play();
        }

        private void playZingMp3(String zingUrl)
        {
            zingUrl = zingUrl.Replace(".html", "");
            String musicId = zingUrl.Substring(zingUrl.LastIndexOf("/") + 1);

            HttpResponse<String> response =
                Unirest.get("http://api.mp3.zing.vn/api/mobile/song/getsonginfo?requestdata={%22id%22:%22" + musicId + "%22}")
                    .asString();

            JObject jsonResponse = JObject.Parse(response.Body);
            String fileName = jsonResponse.GetValue("title").Value<String>();

            JToken token = jsonResponse.GetValue("source");
            String downloadUrl = JObject.Parse(token.ToString()).GetValue("320").Value<String>();

            windowMedia.URL = downloadUrl;
            windowMedia.Ctlcontrols.play();
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            lbxDownLoad.Items.Clear();
            lbxDownLoad.Items.AddRange(directoryInfo.GetFiles("*.mp3"));

            progressDownload.Value = 0;
            progressDownload.Hide();
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressDownload.Value = e.ProgressPercentage;
        }

        private void linkDownloadZingMp3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String baseUrl = txtLink.Text.Trim();

            if (!baseUrl.Contains("mp3.zing.vn") && !ExtentionSupports.Contains(Path.GetExtension(baseUrl)))
            {
                MessageBox.Show("Url nhập không hợp lệ, vui lòng tìm url khác");
                return;
            }

            if (baseUrl.Contains("mp3.zing.vn"))
            {
                this.downloadFromZingMp3(baseUrl);
                return;
            }

            downloadFromUnknowSource(baseUrl);

        }


        private void downloadFromZingMp3(string url)
        {
            url = url.Replace(".html", "");
            String musicId = url.Substring(url.LastIndexOf("/") + 1);

            HttpResponse<String> response =
                Unirest.get("http://api.mp3.zing.vn/api/mobile/song/getsonginfo?requestdata={%22id%22:%22" + musicId +
                            "%22}")
                    .asString();

            JObject jsonResponse = JObject.Parse(response.Body);
            String fileName = jsonResponse.GetValue("title").Value<String>();

            JToken token = jsonResponse.GetValue("source");
            String downloadUrl = JObject.Parse(token.ToString()).GetValue("320").Value<String>();

            progressDownload.Show();

            WebClient webclient = new WebClient();
            webclient.DownloadFileCompleted += Completed;
            webclient.DownloadProgressChanged += ProgressChanged;
            webclient.DownloadFileAsync(new Uri(downloadUrl),
                Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "/" + fileName + ".mp3");
        }

        private void downloadFromUnknowSource(string url)
        {
            WebClient webclient = new WebClient();
            webclient.DownloadFileCompleted += Completed;
            webclient.DownloadProgressChanged += ProgressChanged;
            webclient.DownloadFileAsync(new Uri(url),
                Environment.GetFolderPath(Environment.SpecialFolder.MyVideos) + "/" + Path.GetFileName(url));

        }
    }
}