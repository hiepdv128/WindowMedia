using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowMedia
{
    public partial class SimpleMedia : Form
    {
        public SimpleMedia()
        {
            InitializeComponent();
        }

        private void btnLoadMusic_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                lbMusics.DataSource = openFileDialog.FileNames;
            }
            
        }

        private void lbMusics_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            windowMedia.URL = lbMusics.SelectedItem.ToString();
            windowMedia.Ctlcontrols.play();
        }

        private void lbMusics_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenu.Show(e.Location);
            }
        }


    }
}
