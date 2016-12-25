using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using unirest_net.http;
using System.Net;

namespace WindowMedia
{
    public partial class Test : Form
    {
        private String[] extentions = {".mp3", "mp4", ".avi", ".mwn", ".3gp"};

        public Test()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string extension = Path.GetExtension("http://www.phimmoi.net/download/148263425973dffb13/UGhpbU1vaV8Jv22PfyLT%21vZHuEUPSmkQDZGltAAHbCCOnoUsYBKmgy2q~plKrlpMiD4bQIL~plK1tjGgMA0ZcBJiP07exJ%21vZH1lUt34jV~plK1ovXEUttpvNXWk2XU8MCKdw%21vZHW7ysiYUlkorFnbkn97gTpqi06xxP9kFj%21vZHufXMGkVBYLbGOaVhtfifqZ6M10Zqwfbe1FfCjcXpBLUjz3SdfQGWBXiOuwu8wez.%2AOn6fIfSseQwCNpS8124xhU2OLSXPGO3kfKpFy7cAFO%21vZHKvtEPGJp.%2AOnqACy5wpj5ghwvif1YWkj5y7OA%21vZHCUx4vusIfDTgu6Zeh00.%2AOnsJQl2edAw8XTkaZjfmEN88hzDnbHEPfZdS39Ci2v3mwSbBrebolcmNc05X7CWEvvu7QguiKdySQpoDpNHwWokjfzTsIx%21vZHltOdSTdEw2BbbwQ4wQKUoYdMVdyYpQ62Npq0i1SuwBJ%21vZHZaPAKKbCTaZIWBHafPjD%21vZHeqG9qTcCUD3nJ~plKg9EtC~plK4TMQW4bJSK.%2AOnJv1o.%2AOnT4Z.%2AOn2dHIwlEj5KH749~plKpl.%2AOnnL83WYmK9ei5FT5vrWIbYUWj0xy3KZHSDA6ZdgolqKVjrzg5B8EkfyMIBZATeSDyn5lkBZTFhqrj7jrhJTFjSybIKm4_982cef8e1482634259%40v1.3/PhimMoi.Net---Chien.Binh.Ngoai.Hanh.Tinh-Max.Steel-2016-Vietsub-1080p");
            if (!extentions.Contains(extension.ToLower()))
            {
                MessageBox.Show("false");
            }
            MessageBox.Show("true");


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
            webclient.DownloadFileAsync(new Uri(downloadUrl), Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "/" +fileName + ".mp3");
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
