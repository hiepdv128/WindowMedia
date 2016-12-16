using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unirest_net.http;
using System.Net;

namespace WindowMedia
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String baseUrl = txtLink.Text.Trim();
            baseUrl = baseUrl.Replace(".html", "");
            String musicId = baseUrl.Substring(baseUrl.LastIndexOf("/") + 1);

            HttpResponse<String> response = Unirest.get("http://api.mp3.zing.vn/api/mobile/song/getsonginfo?requestdata={%22id%22:%22" + musicId + "%22}")
                .asString();

            JObject jsonResponse = JObject.Parse(response.Body);
            String fileName = jsonResponse.GetValue("title").Value<String>();

            JToken token = jsonResponse.GetValue("source");
            String downloadUrl = JObject.Parse(token.ToString()).GetValue("320").Value<String>();

            WebClient webclient = new WebClient();
            webclient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webclient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webclient.DownloadFileAsync(new Uri(downloadUrl), Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + fileName + ".mp3");
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed!");
            progressBar.Value = 0;
            txtLink.Text = "";
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

    }
}
