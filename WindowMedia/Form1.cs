using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using unirest_net.http;

namespace WindowMedia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HttpResponse<String> response = Unirest.get("http://api.mp3.zing.vn/api/mobile/song/getsonginfo?requestdata={%22id%22:%22ZW78U908%22}")
                .asString();

            JObject body = JObject.Parse(response.Body);
            lblResponse.Text = body.GetValue("title").Value<String>();
            
        }
    }
}
