using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowMedia
{
    public partial class SignUp : Form
    {
        private ResourceTransporter resourceTransporter;

        public SignUp()
        {
            InitializeComponent();

            resourceTransporter = new ResourceTransporter();
        }

        private void btnSingUp_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtPassword.Text) ||
                String.IsNullOrEmpty(txtPasswordAgain.Text) || String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            if (!String.Equals(txtPassword.Text, txtPasswordAgain.Text))
            {
                MessageBox.Show("Pass work không khớp, vui lòng nhập lại");

                this.txtPassword.Text = "";
                this.txtPasswordAgain.Text = "";
                return;
            }

            SqlCommand checkExistUserCommand = new SqlCommand(String.Format("SELECT * FROM Users WHERE Username='{0}'", txtUsername.Text), resourceTransporter.GetConnection());
            if (checkExistUserCommand.ExecuteScalar() != null)
            {
                MessageBox.Show("User đã tồn tại");
                this.resetFrom();

                return;
            }

            SqlCommand insertCommand = new SqlCommand(String.Format("INSERT INTO Users VALUES ('{0}', '{1}', '{2}')", txtUsername.Text, txtPassword.Text, txtName.Text), resourceTransporter.GetConnection());
            insertCommand.ExecuteNonQuery();
            SignIn signInForm = new SignIn();
            signInForm.setUpUser(txtUsername.Text, txtPassword.Text);
            signInForm.Show();
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.resetFrom();
        }

        private void resetFrom()
        {
            this.txtUsername.Text = "";
            this.txtName.Text = "";
            this.txtPassword.Text = "";
            this.txtPasswordAgain.Text = "";
        }

        private void SignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            new SignIn().Show();
        }


    }
}
