using KutuphaneOtomasyonu.Business;
using KutuphaneOtomasyonu.Core.DependencyResolvers;
using KutuphaneOtomasyonu.DataAccess.Base;
using KutuphaneOtomasyonu.DataAccessB;
using KutuphaneOtomasyonu.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class LoginScreen : Form
    {
        private UserManager _userManager;
        private RegisterScreen _registerScreen;
        public LoginScreen()
        {
            InitializeComponent();
            _userManager = KutuphaneOtomasyonuFactory.CreateUserManager();
            _registerScreen = KutuphaneOtomasyonuFactory.CreateRegisterScreen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            var result = _userManager.Login(email, password);

            if (result.Success)
            {
                MessageBox.Show(result.Message);
                txtEmail.Text = "";
                txtPassword.Text = "";
            } else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            _registerScreen.Show();
        }
    }
}
