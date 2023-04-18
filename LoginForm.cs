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
    public partial class LoginForm : Form
    {
        public Authenticator auth = new Authenticator();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {

            string login = this.loginInput.Text;
            string password = this.passInput.Text;

            try
            {
                this.auth.LoginIn(login, password);
            }
            catch(Exception _)
            {
                MessageBox.Show("Invalid login!");
                return;
            }

            GameForm gameForm = new GameForm(this, this.auth);
            this.Hide();
            gameForm.Show();

        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(this);
            this.Hide();
            registerForm.Show();
        }
    }
}