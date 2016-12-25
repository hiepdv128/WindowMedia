using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowMedia
{
    public partial class SignIn : Form
    {
        private ResourceTransporter resourceTransporter;

        public SignIn()
        {
            InitializeComponent();

            resourceTransporter = new ResourceTransporter();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();

            new SignUp().Show();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsernameSingIn.Text) || String.IsNullOrEmpty(txtPasswordSingIn.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            String query = String.Format(
                "SELECT * FROM Users WHERE Username='{0}' AND Password='{1}'",
                txtUsernameSingIn.Text,
                txtPasswordSingIn.Text
            );

            var queryResult = new SqlCommand(query, resourceTransporter.GetConnection()).ExecuteScalar();

            if (queryResult == null)
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu");
                txtPasswordSingIn.Text = "";
                return;
            }

            SimpleMedia media = new SimpleMedia();
            media.setUsername(txtUsernameSingIn.Text);
            media.Show();

            this.Close();
        }

        public void setUpUser(string username, string password)
        {
            this.txtUsernameSingIn.Text = username;
            this.txtPasswordSingIn.Text = password;
        }
    }
}