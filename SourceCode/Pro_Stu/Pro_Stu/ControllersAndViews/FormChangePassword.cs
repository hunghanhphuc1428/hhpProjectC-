using Pro_Stu.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_Stu.ControllersAndViews
{
    public partial class FormChangePassword : Form
    {
        string Password;
        string UserName;
        public FormChangePassword(string Password, string UserName)
        {
            InitializeComponent();
            this.Password = Password;
            this.UserName = UserName;
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            if (Password.Equals(txtOldPassword.Text))
            {
                if(txtNewPassword.Text.LongCount() > 7)
                {
                    if (txtNewPassword.Text.Equals(txtConfirmPassword.Text))
                    {
                        UserData UserData = new UserData();
                        try
                        {
                            if(UserData.checkUpdateUserPassword(txtNewPassword.Text, UserName))
                            {
                                MessageBox.Show("Update Complete");
                                
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Update Password Fail");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Confirm password fail");
                    }
                 }
                else
                {
                    MessageBox.Show("Password least must 8 character");
                }
            }
            else
            {
                MessageBox.Show("Old Password Wrong");
            }
        }
    }
}
