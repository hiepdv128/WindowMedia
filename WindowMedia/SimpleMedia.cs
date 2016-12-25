using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private Dictionary<string, string> CurrentVideoPlayList { get; set; }
        private List<string> HistoryMusicPlayed { get; set; }
        private List<string> HistoryVideoPlayed { get; set; }
        private string tabTag;
        private string[] ExtentionSupports = {".mp3", ".mp4", ".avi", ".mwn", ".3gp", ".mkv"};

        private ResourceTransporter resourceTransporter;
        private string username = "test";
        private string fileDownload;

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
            HistoryMusicPlayed = new List<string>();
            HistoryVideoPlayed = new List<string>();

        }

        public void setUser(string username)
        {
            this.username = username;
            lblName.Text = this.username;
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
                    .Where(filePath => File.Exists(filePath))
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
                openFileDialog.Filter = @"Video|*.mp4;*.avi;*.mkv;*.mwn";
                openFileDialog.FileName = "Video";
                openFileDialog.ShowDialog();

                Dictionary<string, string> newFiles = openFileDialog.FileNames
                    .ToList()
                    .Where(filePath => File.Exists(filePath))
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
            if (lbxMusics.SelectedItem == null)
            {
                return;
            }

            if (!tabTag.Equals(TAG.MUSIC))
            {
                windowMedia.currentPlaylist.clear();
            }

            tabTag = TAG.MUSIC;
            this.PlayMedia(CurrentMusicPlayList[lbxMusics.SelectedItem.ToString()]);

            insertHistory(HistoryMusicPlayed, lbxMusics.SelectedItem.ToString());
            lbxMusics.ClearSelected();
        }

        private void lbxVideo_DoubleClick(object sender, EventArgs e)
        {
            if (lbxVideo.SelectedItem == null)
            {
                return;
            }

            if (!tabTag.Equals(TAG.VIDEO))
            {
                windowMedia.currentPlaylist.clear();
            }

            tabTag = TAG.VIDEO;

            this.PlayMedia(CurrentVideoPlayList[lbxVideo.SelectedItem.ToString()]);

            insertHistory(HistoryVideoPlayed, lbxVideo.SelectedItem.ToString());
            lbxVideo.ClearSelected();
        }

        private void PlayMedia(string path)
        {
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

                foreach (string musicsSelectedItem in lbxMusics.SelectedItems)
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
                foreach (string musicSelectedItem in lbxMusics.SelectedItems.OfType<String>().ToList())
                {
                    lbxMusics.Items.Remove(musicSelectedItem);
                    lbxMusicFavorites.Items.Remove(musicSelectedItem);
                    CurrentMusicPlayList.Remove(musicSelectedItem);
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
                        windowMedia.mediaCollection.add(CurrentVideoPlayList[lbxVideo.SelectedItem.ToString()]);
                    windowMedia.Ctlcontrols.playItem(mediaInserted);
                    return;
                }

                foreach (var videoSelectedItem in lbxVideo.SelectedItems)
                {
                    windowMedia.currentPlaylist.appendItem(
                        windowMedia.mediaCollection.add(CurrentVideoPlayList[videoSelectedItem.ToString()]));
                    windowMedia.Ctlcontrols.play();
                }
            }
        }

        private void addFavoriteMenu_Click(object sender, EventArgs e)
        {
            if (lbxVideo.SelectedItems.Count > 0)

                foreach (string videoSelectedItem in lbxVideo.SelectedItems)
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
                    lbxVideoFavorite.Items.Remove(videoSelectedItem);
                    CurrentVideoPlayList.Remove(videoSelectedItem);
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

        private void btnPlayOnline_Click(object sender, EventArgs e)
        {
            String baseUrl = txtLink.Text.Trim();

            if (!baseUrl.Contains("mp3.zing.vn") && !ExtentionSupports.Contains(Path.GetExtension(baseUrl)))
            {
                MessageBox.Show("Url nhập không hợp lệ, vui lòng tìm url khác");
                return;
            }


            lbxPlayOnlineHistory.Items.Remove(baseUrl);
            lbxPlayOnlineHistory.Items.Insert(0, baseUrl);

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
                Unirest.get("http://api.mp3.zing.vn/api/mobile/song/getsonginfo?requestdata={%22id%22:%22" + musicId +
                            "%22}")
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
            MessageBox.Show("Download Complete!");

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
            String targetUrl = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "/" + fileName + ".mp3";

            progressDownload.Show();

            WebClient webclient = new WebClient();
            webclient.DownloadFileCompleted += Completed;
            webclient.DownloadProgressChanged += ProgressChanged;
            webclient.DownloadFileAsync(new Uri(downloadUrl), targetUrl);

            lbxDownLoad.Items.Add(targetUrl);
        }

        private void downloadFromUnknowSource(string url)
        {
            string targetUrl = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos) + "/" +
                               Path.GetFileName(url);
            WebClient webclient = new WebClient();
            webclient.DownloadFileCompleted += Completed;
            webclient.DownloadProgressChanged += ProgressChanged;
            webclient.DownloadFileAsync(new Uri(url), targetUrl);

            lbxDownLoad.Items.Add(targetUrl);
        }

        private void SimpleMedia_FormClosed(object sender, FormClosedEventArgs e)
        {
            string deletePlaylistQuery = String.Format("DELETE FROM PlaylistItems WHERE username='{0}'", username);
            string deleteResourceQuery = String.Format("DELETE FROM Resources WHERE username='{0}'", username);

            new SqlCommand(deletePlaylistQuery, resourceTransporter.GetConnection()).ExecuteScalar();
            new SqlCommand(deleteResourceQuery, resourceTransporter.GetConnection()).ExecuteScalar();

            this.savePlayListMusic();
            this.saveFavoriteMusic();
            this.savePlayListVideo();
            this.saveFavoriteVideo();
            this.saveHistoryDownloaded();
        }

        private void savePlayListMusic()
        {
            DataTable resourceMusics = new DataTable();
            DataColumn nameColumn = new DataColumn("Name", typeof(String));
            nameColumn.Unique = true;
            resourceMusics.Columns.Add(nameColumn);
            resourceMusics.Columns.Add(new DataColumn("Url", typeof(String)));
            resourceMusics.Columns.Add(new DataColumn("Type", typeof(String)));
            resourceMusics.Columns.Add(new DataColumn("Username", typeof(String)));

            foreach (KeyValuePair<string, string> kv in CurrentMusicPlayList)
            {
                DataRow newRow = resourceMusics.NewRow();
                newRow["name"] = kv.Key;
                newRow["url"] = kv.Value;
                newRow["type"] = "Music";
                newRow["username"] = username;

                resourceMusics.Rows.Add(newRow);
            }

            SqlBulkCopy bulkInsert = new SqlBulkCopy(resourceTransporter.GetConnection());
            bulkInsert.DestinationTableName = "Resources";
            try
            {
                bulkInsert.WriteToServer(resourceMusics);
                bulkInsert.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        private void savePlayListVideo()
        {
            DataTable resourceVideos = new DataTable();

            DataColumn nameColumn = new DataColumn("Name", typeof(String));
            nameColumn.Unique = true;
            resourceVideos.Columns.Add(nameColumn);
            resourceVideos.Columns.Add(new DataColumn("Url", typeof(String)));
            resourceVideos.Columns.Add(new DataColumn("Type", typeof(String)));
            resourceVideos.Columns.Add(new DataColumn("Username", typeof(String)));

            foreach (KeyValuePair<string, string> kv in CurrentVideoPlayList)
            {
                DataRow newRow = resourceVideos.NewRow();
                newRow["name"] = kv.Key;
                newRow["url"] = kv.Value;
                newRow["type"] = "Video";
                newRow["username"] = username;

                resourceVideos.Rows.Add(newRow);
            }

            SqlBulkCopy bulkInsert = new SqlBulkCopy(resourceTransporter.GetConnection());
            bulkInsert.DestinationTableName = "Resources";
            try
            {
                bulkInsert.WriteToServer(resourceVideos);
                bulkInsert.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        private void saveFavoriteMusic()
        {
            DataTable tbFavoriteMusics = new DataTable();

            tbFavoriteMusics.Columns.Add(new DataColumn("id", typeof(int)));
            tbFavoriteMusics.Columns.Add(new DataColumn("ResourceName", typeof(String)));
            tbFavoriteMusics.Columns.Add(new DataColumn("PlayList", typeof(String)));
            tbFavoriteMusics.Columns.Add(new DataColumn("UserName", typeof(String)));

            foreach (string favoriteMusic in lbxMusicFavorites.Items)
            {
                DataRow newRow = tbFavoriteMusics.NewRow();
                newRow["id"] = DBNull.Value;
                newRow["ResourceName"] = favoriteMusic;
                newRow["Playlist"] = "Music";
                newRow["UserName"] = username;

                tbFavoriteMusics.Rows.Add(newRow);
            }

            SqlBulkCopy bulkInsert = new SqlBulkCopy(resourceTransporter.GetConnection().ConnectionString);
            bulkInsert.DestinationTableName = "PlayListItems";
            try
            {
                bulkInsert.WriteToServer(tbFavoriteMusics);
                bulkInsert.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }

        private void saveFavoriteVideo()
        {
            DataTable tbFavoriteVideo = new DataTable();

            tbFavoriteVideo.Columns.Add(new DataColumn("id", typeof(int)));
            tbFavoriteVideo.Columns.Add(new DataColumn("ResourceName", typeof(String)));
            tbFavoriteVideo.Columns.Add(new DataColumn("PlayList", typeof(String)));
            tbFavoriteVideo.Columns.Add(new DataColumn("UserName", typeof(String)));

            foreach (string favoriteMusic in lbxVideoFavorite.Items)
            {
                DataRow newRow = tbFavoriteVideo.NewRow();
                newRow["id"] = DBNull.Value;
                newRow["ResourceName"] = favoriteMusic;
                newRow["Playlist"] = "Video";
                newRow["UserName"] = username;

                tbFavoriteVideo.Rows.Add(newRow);
            }

            SqlBulkCopy bulkInsert = new SqlBulkCopy(resourceTransporter.GetConnection().ConnectionString);
            bulkInsert.DestinationTableName = "PlayListItems";
            try
            {
                bulkInsert.WriteToServer(tbFavoriteVideo);
                bulkInsert.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }


        private void saveHistoryDownloaded()
        {
            DataTable tbHistory = new DataTable();

            tbHistory.Columns.Add(new DataColumn("Name", typeof(String)));
            tbHistory.Columns.Add(new DataColumn("Url", typeof(String)));
            tbHistory.Columns.Add(new DataColumn("Type", typeof(String)));
            tbHistory.Columns.Add(new DataColumn("Username", typeof(String)));

            foreach (string itemDownloaded in lbxDownLoad.Items)
            {
                DataRow newRow = tbHistory.NewRow();
                newRow["Name"] = Path.GetFileName(itemDownloaded);
                newRow["Url"] = itemDownloaded;
                newRow["Type"] = "Download";
                newRow["UserName"] = username;

                tbHistory.Rows.Add(newRow);
            }

            SqlBulkCopy bulkInsert = new SqlBulkCopy(resourceTransporter.GetConnection().ConnectionString);
            bulkInsert.DestinationTableName = "Resources";
            try
            {
                bulkInsert.WriteToServer(tbHistory);
                bulkInsert.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }

        private void saveHistoryPlayed()
        {
            DataTable tbHistory = new DataTable();

            tbHistory.Columns.Add(new DataColumn("Name", typeof(String)));
            tbHistory.Columns.Add(new DataColumn("Url", typeof(String)));
            tbHistory.Columns.Add(new DataColumn("Type", typeof(String)));
            tbHistory.Columns.Add(new DataColumn("Username", typeof(String)));

            foreach (string playedOnline in lbxPlayOnlineHistory.Items)
            {
                DataRow newRow = tbHistory.NewRow();
                newRow["Name"] = Path.GetFileName(playedOnline);
                newRow["Url"] = playedOnline;
                newRow["Type"] = "PlayedOnline";
                newRow["UserName"] = username;

                tbHistory.Rows.Add(newRow);
            }

            SqlBulkCopy bulkInsert = new SqlBulkCopy(resourceTransporter.GetConnection().ConnectionString);
            bulkInsert.DestinationTableName = "Resources";
            try
            {
                bulkInsert.WriteToServer(tbHistory);
                bulkInsert.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }

        private void lbxPlayOnlineHistory_DoubleClick(object sender, EventArgs e)
        {
            if (lbxPlayOnlineHistory.SelectedItem == null)
            {
                return;
            }

            txtLink.Text = lbxPlayOnlineHistory.SelectedItem.ToString();
            lbxPlayOnlineHistory.ClearSelected();
        }

        private void lbxDownLoad_DoubleClick(object sender, EventArgs e)
        {
            if (lbxDownLoad.SelectedItem == null)
            {
                return;
            }

            windowMedia.currentPlaylist.clear();
            windowMedia.URL = lbxDownLoad.SelectedItem.ToString();
            windowMedia.Ctlcontrols.play();
        }

        private void SimpleMedia_Load(object sender, EventArgs e)
        {
            CurrentMusicPlayList = resourceTransporter.readFromResources("Music", username);
            CurrentVideoPlayList = resourceTransporter.readFromResources("Video", username);
            Dictionary<string, string> downloadItems = resourceTransporter.readFromResources("Download", username);
            Dictionary<string, string> playedOnline = resourceTransporter.readFromResources("PlayedOnline", username);

            lbxMusics.Items.AddRange(CurrentMusicPlayList.Keys.ToArray());
            lbxVideo.Items.AddRange(CurrentVideoPlayList.Keys.ToArray());

            lbxMusicFavorites.Items.AddRange(resourceTransporter.readFromPlayListItem("Music", username).ToArray());
            lbxVideoFavorite.Items.AddRange(resourceTransporter.readFromPlayListItem("Video", username).ToArray());

            lbxDownLoad.Items.AddRange(downloadItems.Values.ToArray());
            lbxPlayOnlineHistory.Items.AddRange(playedOnline.Values.ToArray());
        }
    }
}