using KutuphaneOtomasyonu.Business;
using KutuphaneOtomasyonu.Core.DependencyResolvers;
using KutuphaneOtomasyonu.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class RegisterScreen : Form
    {
        private UserManager _userManager;
        public RegisterScreen()
        {
            InitializeComponent();
            _userManager = KutuphaneOtomasyonuFactory.CreateUserManager();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };

            var result = _userManager.Register(user);
            if (result.Success)
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                MessageBox.Show(result.Message);
            }else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void RegisterScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
