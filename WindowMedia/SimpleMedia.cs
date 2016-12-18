using System;
using System.Windows.Forms;

namespace WindowMedia
{
    public partial class SimpleMedia : Form
    {
        public SimpleMedia()
        {
            InitializeComponent();
        }

        private void lbMusics_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenu.Show(e.Location);
            }
        }

        private void lbMusics_DoubleClick(object sender, EventArgs e)
        {
            
//            windowMedia.URL = lbMusics.SelectedItem.ToString();
            windowMedia.URL = "http://api.mp3.zing.vn/api/mobile/source/song/LGJGTLGNQNNLQDJTVDGTDGLG";

            windowMedia.Ctlcontrols.play();
        }

        private void SimpleMedia_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.O && e.Control)
            {
                openNewFile.ShowDialog();
            }

            if (e.KeyCode == Keys.F && e.Control == true)
                e.Handled = true;

        }


    }
}
