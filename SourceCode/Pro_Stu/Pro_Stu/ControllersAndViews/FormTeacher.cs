using Pro_Stu.Controllers;
using Pro_Stu.Data;
using Pro_Stu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_Stu.ControllersAndViews
{
    public partial class FormTeacher : Form
    {
        DateTime Date = DateTime.Now;
        double Week = 0;
        public User User { get; set; }
        public FormTeacher(User User)
        {
            InitializeComponent();
            this.User = User;
            LoadInfoUser();
            //DateTime dateValue = new DateTime(2020, 4, 3);
            //MessageBox.Show(dateValue.ToString("ddd"));
        }
        public void LoadInfoUser()
        {
            txtNameTeacher.Text = User.Name;
            txtDateOfBirth.Text = User.DateOfBirth.ToString("MM-dd-yyyy");
            txtEmailTeacher.Text = User.Email;
            txtPhoneNumberTeacher.Text = User.PhoneNumber;

           
            Schedule_User_Data SheduleUserData = new Schedule_User_Data();
           
            loadSchedule();
            bsGroup_User.DataSource = SheduleUserData.getListGroup_User(User.UserName);
            GridViewGroup.DataSource = bsGroup_User;

            txtGroup.DataBindings.Clear();

            txtGroup.DataBindings.Add("Text", bsGroup_User, "GroupID");
        }
        public void clearSchedule()
        {
            txtSlot1MonT.Text = string.Empty;
            txtSlot2MonT.Text = string.Empty;
            txtSlot3MonT.Text = string.Empty;
            txtSlot4MonT.Text = string.Empty;
            txtSlot5MonT.Text = string.Empty;
            txtSlot6MonT.Text = string.Empty;

            txtSlot1TueT.Text = string.Empty;
            txtSlot2TueT.Text = string.Empty;
            txtSlot3TueT.Text = string.Empty;
            txtSlot4TueT.Text = string.Empty;
            txtSlot5TueT.Text = string.Empty;
            txtSlot6TueT.Text = string.Empty;

            txtSlot1WedT.Text = string.Empty;
            txtSlot2WedT.Text = string.Empty;
            txtSlot3WedT.Text = string.Empty;
            txtSlot4WedT.Text = string.Empty;
            txtSlot5WedT.Text = string.Empty;
            txtSlot6WedT.Text = string.Empty;

            txtSlot1ThuT.Text = string.Empty;
            txtSlot2ThuT.Text = string.Empty;
            txtSlot3ThuT.Text = string.Empty;
            txtSlot4ThuT.Text = string.Empty;
            txtSlot5ThuT.Text = string.Empty;
            txtSlot6ThuT.Text = string.Empty;

            txtSlot1FriT.Text = string.Empty;
            txtSlot2FriT.Text = string.Empty;
            txtSlot3FriT.Text = string.Empty;
            txtSlot4FriT.Text = string.Empty;
            txtSlot5FriT.Text = string.Empty;
            txtSlot6FriT.Text = string.Empty;

            txtSlot1SatT.Text = string.Empty;
            txtSlot2SatT.Text = string.Empty;
            txtSlot3SatT.Text = string.Empty;
            txtSlot4SatT.Text = string.Empty;
            txtSlot5SatT.Text = string.Empty;
            txtSlot6SatT.Text = string.Empty;

            txtSlot1SunT.Text = string.Empty;
            txtSlot2SunT.Text = string.Empty;
            txtSlot3SunT.Text = string.Empty;
            txtSlot4SunT.Text = string.Empty;
            txtSlot5SunT.Text = string.Empty;
            txtSlot6SunT.Text = string.Empty;

        }
        public void loadSchedule()
        {
            clearSchedule();
            DataTable Datatb = new DataTable();
            Schedule_User_Data SheduleUserData = new Schedule_User_Data();
            try
            {
                
                string newLine = Environment.NewLine;
                Datatb = SheduleUserData.getListShedule_User(User.UserName, FirstDayOfWeek(Date), LastDayOfWeek(Date));
                //MessageBox.Show(Datatb.Rows[1].Field<string>("SlotID"));
                foreach (DataRow row in Datatb.Rows)
                {
                    DateTime dateValue = DateTime.Parse(row["Date"].ToString());


                    if (dateValue.ToString("ddd").Equals("Mon"))
                    {
                        if (row["SlotID"].ToString().Equals("Slot1"))
                        {
                            txtSlot1MonT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");

                        }
                        else if (row["SlotID"].ToString().Equals("Slot2"))
                        {
                            txtSlot2MonT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot3"))
                        {
                            txtSlot3MonT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot4"))
                        {
                            txtSlot4MonT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot5"))
                        {
                            txtSlot5MonT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot6"))
                        {
                            txtSlot6MonT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                    }
                    else if (dateValue.ToString("ddd").Equals("Tue"))
                    {

                        if (row["SlotID"].ToString().Equals("Slot1"))
                        {
                            txtSlot1TueT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");

                        }
                        else if (row["SlotID"].ToString().Equals("Slot2"))
                        {
                            txtSlot2TueT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot3"))
                        {
                            txtSlot3TueT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot4"))
                        {
                            txtSlot4TueT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot5"))
                        {
                            txtSlot5TueT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot6"))
                        {
                            txtSlot6TueT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                    }
                    else if (dateValue.ToString("ddd").Equals("Wed"))
                    {
                        if (row["SlotID"].ToString().Equals("Slot1"))
                        {
                            txtSlot1WedT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot2"))
                        {
                            txtSlot2WedT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot3"))
                        {
                            txtSlot3WedT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot4"))
                        {
                            txtSlot4WedT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot5"))
                        {
                            txtSlot5WedT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot6"))
                        {
                            txtSlot6WedT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                    }
                    else if (dateValue.ToString("ddd").Equals("Thu"))
                    {
                        if (row["SlotID"].ToString().Equals("Slot1"))
                        {
                            txtSlot1ThuT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot2"))
                        {
                            txtSlot2ThuT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot3"))
                        {
                            txtSlot3ThuT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot4"))
                        {
                            txtSlot4ThuT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot5"))
                        {
                            txtSlot5ThuT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot6"))
                        {
                            txtSlot6ThuT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                    }
                    else if (dateValue.ToString("ddd").Equals("Fri"))
                    {
                        if (row["SlotID"].ToString().Equals("Slot1"))
                        {
                            txtSlot1FriT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot2"))
                        {
                            txtSlot2FriT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot3"))
                        {
                            txtSlot3FriT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot4"))
                        {
                            txtSlot4FriT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot5"))
                        {
                            txtSlot5FriT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot6"))
                        {
                            txtSlot6FriT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                    }
                    else if (dateValue.ToString("ddd").Equals("Sat"))
                    {
                        if (row["SlotID"].ToString().Equals("Slot1"))
                        {
                            txtSlot1SatT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot2"))
                        {
                            txtSlot2SatT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot3"))
                        {
                            txtSlot3SatT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot4"))
                        {
                            txtSlot4SatT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot5"))
                        {
                            txtSlot5SatT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot6"))
                        {
                            txtSlot6SatT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                    }
                    else if (dateValue.ToString("ddd").Equals("Sun"))
                    {
                        if (row["SlotID"].ToString().Equals("Slot1"))
                        {
                            txtSlot1SunT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot2"))
                        {
                            txtSlot2SunT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot3"))
                        {
                            txtSlot3SunT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot4"))
                        {
                            txtSlot4SunT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot5"))
                        {
                            txtSlot5SunT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                        else if (row["SlotID"].ToString().Equals("Slot6"))
                        {
                            txtSlot6SunT.Text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy");
                        }
                    }

                }


            }
            catch
            {
                MessageBox.Show("Loi");
            }
        }
        public void getAttendance(TextBox text, string slot)
        {
            if (text.Text != string.Empty)
            {
                string[] infoSlot_Day = text.Text.ToString().Split('\n');
                string Group = infoSlot_Day[0];

                DateTime Date = DateTime.ParseExact(infoSlot_Day[2], "dd-MM-yyyy", CultureInfo.InvariantCulture);
                Schedule_User_Data ScheduleUser = new Schedule_User_Data();
                CheckAttendance frmCheck = new CheckAttendance(ScheduleUser.getListStudentAttendance(Group, Date, slot));
                frmCheck.ShowDialog();
            }
        }
        public DateTime FirstDayOfWeek(DateTime date)
        {
            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime fdowDate = date.AddDays(offset);
            return fdowDate;
        }
        public DateTime LastDayOfWeek(DateTime date)
        {
            DateTime ldowDate = FirstDayOfWeek(date).AddDays(6);
            return ldowDate;
        }

        private void GridViewGroup_SelectionChanged(object sender, EventArgs e)
        {
            string GroupID = txtGroup.Text;
            User_Group_Data UserGroupData = new User_Group_Data();
            try
            {
               bsDetailGroup.DataSource = UserGroupData.getListUser_Group(GroupID);
               GridViewDetailGroup.DataSource = bsDetailGroup;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void txtSearchGroup_TextChanged(object sender, EventArgs e)
        {
            Schedule_User_Data SheduleUserData = new Schedule_User_Data();
            DataView dv = SheduleUserData.getListGroup_User(User.UserName).DefaultView;
            dv.RowFilter = string.Format("GroupID like '%{0}%'", txtSearchGroup.Text);
            GridViewGroup.DataSource = dv.ToTable();
        }

        private void btnPreWeek_Click(object sender, EventArgs e)
        {
            Date = Date.AddDays(-7);
            loadSchedule();
        }

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            Date = Date.AddDays(7);
            loadSchedule();
        }

        private void txtSlot1MonT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot1MonT, "Slot1");
        }

        private void txtSlot2MonT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot2MonT, "Slot2");
        }

        private void txtSlot3MonT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot3MonT, "Slot3");
        }

        private void txtSlot4MonT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot4MonT, "Slot4");
        }

        private void txtSlot5MonT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot5MonT, "Slot5");
        }

        private void txtSlot6MonT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot6MonT, "Slot6");
        }

        private void txtSlot1TueT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot1TueT, "Slot1");
        }

        private void txtSlot2TueT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot2TueT, "Slot2");
        }

        private void txtSlot3TueT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot3TueT, "Slot3");
        }

        private void txtSlot4TueT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot4TueT, "Slot4");
        }

        private void txtSlot5TueT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot5TueT, "Slot5");
        }

        private void txtSlot6TueT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot6TueT, "Slot6");
        }

        private void txtSlot1WedT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot1WedT, "Slot1");
        }

        private void txtSlot1ThuT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot1ThuT, "Slot1");
        }

        private void txtSlot1FriT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot1FriT, "Slot1");
        }

        private void txtSlot1SatT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot1SatT, "Slot1");
        }

        private void txtSlot1SunT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot1SunT, "Slot1");
        }

        private void txtSlot2WedT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot2WedT, "Slot2");
        }

        private void txtSlot2ThuT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot2ThuT, "Slot2");
        }

        private void txtSlot2FriT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot2FriT, "Slot2");
        }

        private void txtSlot2SatT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot2SatT, "Slot2");
        }

        private void txtSlot2SunT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot2SunT, "Slot2");
        }

        private void txtSlot3WedT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot3WedT, "Slot3");
        }

        private void txtSlot3ThuT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot3ThuT, "Slot3");
        }

        private void txtSlot3FriT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot3FriT, "Slot3");
        }

        private void txtSlot3SatT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot3SatT, "Slot3");
        }

        private void txtSlot3SunT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot3SunT, "Slot3");
        }

        private void txtSlot4WedT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot4WedT, "Slot4");
        }

        private void txtSlot4ThuT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot4ThuT, "Slot4");
        }

        private void txtSlot4FriT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot4FriT, "Slot4");
        }

        private void txtSlot4SatT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot4SatT, "Slot4");
        }

        private void txtSlot4SunT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot4SunT, "Slot4");
        }

        private void txtSlot5WedT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot5WedT, "Slot5");
        }

        private void txtSlot5ThuT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot5ThuT, "Slot5");
        }

        private void txtSlot5FriT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot5FriT, "Slot5");
        }

        private void txtSlot5SatT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot5SatT, "Slot5");
        }

        private void txtSlot5SunT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot5SunT, "Slot5");
        }

        private void txtSlot6WedT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot6WedT, "Slot6");
        }

        private void txtSlot6ThuT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot6ThuT, "Slot6");
        }

        private void txtSlot6FriT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot6FriT, "Slot6");
        }

        private void txtSlot6SatT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot6SatT, "Slot6");
        }

        private void txtSlot6SunT_Click(object sender, EventArgs e)
        {
            getAttendance(txtSlot6SunT, "Slot6");
        }

        private void btnLogut_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(OpenNewFormLogin);
            th.Start();
        }
        public void OpenNewFormLogin()
        {

            Application.Run(new Login());
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {

            FormChangePassword form = new FormChangePassword(User.Password, User.UserName);
            form.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            UserData UserData = new UserData();
            try
            {
                if (UserData.checkUpdateInfoUser(txtPhoneNumberTeacher.Text, txtEmailTeacher.Text, User.UserName))
                {
                    MessageBox.Show("Update sucessful");
                }
            }
            catch
            {
                MessageBox.Show("Update Info Save");
            }
        }
    }
}
