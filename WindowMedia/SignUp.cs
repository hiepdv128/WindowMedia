using System;
using System.Windows.Forms;

namespace WindowMedia
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnSingUp_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtPassword.Text) ||
                String.IsNullOrEmpty(txtPasswordAgain.Text) || String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                //Set to null
            }
        }
    }
}
