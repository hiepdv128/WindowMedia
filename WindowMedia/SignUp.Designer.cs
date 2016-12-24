namespace WindowMedia
{
    partial class SignUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSingUp = new System.Windows.Forms.Button();
            this.txtPasswordAgain = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(110, 34);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(202, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(110, 72);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(202, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(110, 153);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(202, 20);
            this.txtName.TabIndex = 2;
            // 
            // btnSingUp
            // 
            this.btnSingUp.Location = new System.Drawing.Point(214, 212);
            this.btnSingUp.Name = "btnSingUp";
            this.btnSingUp.Size = new System.Drawing.Size(75, 23);
            this.btnSingUp.TabIndex = 3;
            this.btnSingUp.Text = "Sign Up";
            this.btnSingUp.UseVisualStyleBackColor = true;
            this.btnSingUp.Click += new System.EventHandler(this.btnSingUp_Click);
            // 
            // txtPasswordAgain
            // 
            this.txtPasswordAgain.Location = new System.Drawing.Point(110, 111);
            this.txtPasswordAgain.Name = "txtPasswordAgain";
            this.txtPasswordAgain.Size = new System.Drawing.Size(202, 20);
            this.txtPasswordAgain.TabIndex = 1;
            this.txtPasswordAgain.UseSystemPasswordChar = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(110, 212);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear all";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Confirm password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Name";
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 293);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSingUp);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPasswordAgain);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Name = "SignUp";
            this.Text = "SignUp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SignUp_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSingUp;
        private System.Windows.Forms.TextBox txtPasswordAgain;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}