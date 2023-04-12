using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LottoWForms
{
    public partial class RegisterForm : Form
    {
        private LoginForm loginForm;

        public RegisterForm(LoginForm context)
        {
            this.loginForm = context;
            InitializeComponent();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            string login = this.loginInput.Text;
            string pass = this.passInput.Text;
            string rePass = this.rePassInput.Text;

            if(pass != rePass)
            {
                MessageBox.Show("Passwords are not equal!");
                this.passInput.Clear();
                this.rePassInput.Clear();

                return;
            }

            try
            {
                loginForm.auth.SigneIn(login, pass);
            }
            catch (Exception error)
            {
                MessageBox.Show($"Something went wrong! Error: {error.Message}");
                return;
            }

            this.ExitForm();

            
        }

        private void goBackLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ExitForm();

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.loginForm.Show();
            base.OnFormClosing(e);
        }

        private void ExitForm()
        {
            this.loginForm.Show();
            this.Close();
        }
    }
}
