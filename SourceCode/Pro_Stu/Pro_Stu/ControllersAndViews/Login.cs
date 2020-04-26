using Pro_Stu.Controllers;
using Pro_Stu.ControllersAndViews;
using Pro_Stu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_Stu
{
    public partial class Login : Form
    {
        User User;
        public Login()
        {
            InitializeComponent();
        }
        public void OpenNewFormAdmin()
        {

            Application.Run(new FormAdmin(User));
        }
        public void OpenNewFormTeacher()
        {

            Application.Run(new FormTeacher(User));
        }
        public void OpenNewFormStudent()
        {

            Application.Run(new FormStudent(User));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text;
            string Password = txtPassword.Text;
            UserData UserData = new UserData();
            try
            {
                User = UserData.getUserToLogin(UserName, Password);
                if (User.Role.Equals("ADMIN"))
                {
                    this.Close();
                    Thread th = new Thread(OpenNewFormAdmin);
                    th.Start();
                }
                else if (User.Role.Equals("TEACHER"))
                {
                    this.Close();
                    Thread th = new Thread(OpenNewFormTeacher);
                    th.Start();
                }
                else if (User.Role.Equals("STUDENT"))
                {
                    this.Close();
                    Thread th = new Thread(OpenNewFormStudent);
                    th.Start();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Account not exist");
            }
        }
    }
}
