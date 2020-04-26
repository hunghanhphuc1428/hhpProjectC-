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
    public partial class FormStudent : Form
    {
        DataTable DataCourse = new DataTable();
        DateTime Date = DateTime.Now;
        double Week = 0;
        public User User { get; set; }
        public FormStudent(User User)
        {
            InitializeComponent();
            this.User = User;
            LoadData();
   



        }
        public void LoadData()
        {
            txtNameStudent.Text = User.Name;
            if (User.Gender)
            {
                txtGenderStudent.Text = "Male";
            }
            else
            {
                txtGenderStudent.Text = "Female";
            }
            txtPhoneNumberStudent.Text = User.PhoneNumber;
            txtEmailStudent.Text = User.Email;
            txtDateOfBirth.Text = User.DateOfBirth.ToString("dd-MM-yyyy");
            Schedule_User_Data SheduleUserData = new Schedule_User_Data();
            loadSchedule();

            Schedule_User_Data schedule_User_Data = new Schedule_User_Data();
             DataCourse = schedule_User_Data.getListCourseID_GroupID(User.UserName);
            bsCourseID.DataSource = DataCourse;
            GridViewCourse.DataSource = bsCourseID;

            GridViewCourse.Columns["CourseID"].Visible = false;
            GridViewCourse.Columns["GroupID"].Visible = false;

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
                    string Status;

                    try
                    {
                        Status = bool.Parse(row["Status"].ToString()) == true ? "(Attended)" : "(Absent)";
                    }
                    catch
                    {
                        Status = "(Not Yet)";
                    }
                    string text = row["GroupID"].ToString() + newLine + row["CourseID"].ToString() + newLine + dateValue.ToString("dd-MM-yyyy") + newLine + Status;

                    if (dateValue.ToString("ddd").Equals("Mon"))
                    {
                        if (row["SlotID"].ToString().Equals("Slot1"))
                        {

                            txtSlot1MonT.Text = text;


                        }
                        else if (row["SlotID"].ToString().Equals("Slot2"))
                        {
                            txtSlot2MonT.Text = text; 
                        }
                        else if (row["SlotID"].ToString().Equals("Slot3"))
                        {
                            txtSlot3MonT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot4"))
                        {
                            txtSlot4MonT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot5"))
                        {
                            txtSlot5MonT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot6"))
                        {
                            txtSlot6MonT.Text = text;
                        }
                    }
                    else if (dateValue.ToString("ddd").Equals("Tue"))
                    {

                        if (row["SlotID"].ToString().Equals("Slot1"))
                        {
                            txtSlot1TueT.Text = text;

                        }
                        else if (row["SlotID"].ToString().Equals("Slot2"))
                        {
                            txtSlot2TueT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot3"))
                        {
                            txtSlot3TueT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot4"))
                        {
                            txtSlot4TueT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot5"))
                        {
                            txtSlot5TueT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot6"))
                        {
                            txtSlot6TueT.Text = text;
                        }
                    }
                    else if (dateValue.ToString("ddd").Equals("Wed"))
                    {
                        if (row["SlotID"].ToString().Equals("Slot1"))
                        {
                            txtSlot1WedT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot2"))
                        {
                            txtSlot2WedT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot3"))
                        {
                            txtSlot3WedT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot4"))
                        {
                            txtSlot4WedT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot5"))
                        {
                            txtSlot5WedT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot6"))
                        {
                            txtSlot6WedT.Text = text;
                        }
                    }
                    else if (dateValue.ToString("ddd").Equals("Thu"))
                    {
                        if (row["SlotID"].ToString().Equals("Slot1"))
                        {
                            txtSlot1ThuT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot2"))
                        {
                            txtSlot2ThuT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot3"))
                        {
                            txtSlot3ThuT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot4"))
                        {
                            txtSlot4ThuT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot5"))
                        {
                            txtSlot5ThuT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot6"))
                        {
                            txtSlot6ThuT.Text = text;
                        }
                    }
                    else if (dateValue.ToString("ddd").Equals("Fri"))
                    {
                        if (row["SlotID"].ToString().Equals("Slot1"))
                        {
                            txtSlot1FriT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot2"))
                        {
                            txtSlot2FriT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot3"))
                        {
                            txtSlot3FriT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot4"))
                        {
                            txtSlot4FriT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot5"))
                        {
                            txtSlot5FriT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot6"))
                        {
                            txtSlot6FriT.Text = text;
                        }
                    }
                    else if (dateValue.ToString("ddd").Equals("Sat"))
                    {
                        if (row["SlotID"].ToString().Equals("Slot1"))
                        {
                            txtSlot1SatT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot2"))
                        {
                            txtSlot2SatT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot3"))
                        {
                            txtSlot3SatT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot4"))
                        {
                            txtSlot4SatT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot5"))
                        {
                            txtSlot5SatT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot6"))
                        {
                            txtSlot6SatT.Text = text;
                        }
                    }
                    else if (dateValue.ToString("ddd").Equals("Sun"))
                    {
                        if (row["SlotID"].ToString().Equals("Slot1"))
                        {
                            txtSlot1SunT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot2"))
                        {
                            txtSlot2SunT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot3"))
                        {
                            txtSlot3SunT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot4"))
                        {
                            txtSlot4SunT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot5"))
                        {
                            txtSlot5SunT.Text = text;
                        }
                        else if (row["SlotID"].ToString().Equals("Slot6"))
                        {
                            txtSlot6SunT.Text = text;
                        }
                    }

                }


            }
            catch
            {
                MessageBox.Show("Loi");
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

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            Date = Date.AddDays(7);
            loadSchedule();
        }

        private void btnPreWeek_Click(object sender, EventArgs e)
        {
            Date = Date.AddDays(-7);
            loadSchedule();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            

            FormChangePassword form = new FormChangePassword(User.Password, User.UserName);
            form.ShowDialog();

        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            UserData UserData = new UserData();
            try
            {
                if(UserData.checkUpdateInfoUser(txtPhoneNumberStudent.Text, txtEmailStudent.Text, User.UserName))
                {
                    MessageBox.Show("Update sucessful");
                }
            }
            catch {
                MessageBox.Show("Update Info Save");
            }
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

        private void GridViewCourse_SelectionChanged(object sender, EventArgs e)
        {
            string CourseID = GridViewCourse.Rows[GridViewCourse.CurrentCell.RowIndex].Cells["CourseID"].Value.ToString();
           
            Schedule_User_Data schedule_User_Data = new Schedule_User_Data();
            schedule_User_Data.getListGroupID_From_CourseID(User.UserName, CourseID);
            bsGroupID.DataSource = schedule_User_Data.getListGroupID_From_CourseID(User.UserName, CourseID);
            GridViewGroup.DataSource = bsGroupID;
          

        }

        private void GridViewGroup_SelectionChanged(object sender, EventArgs e)
        {
            string GroupID = GridViewGroup.Rows[GridViewGroup.CurrentCell.RowIndex].Cells["GroupID"].Value.ToString();
            User_Group_Data user_Group_Data = new User_Group_Data();
            bsDetailGroup.DataSource = user_Group_Data.getListUser_Group(GroupID);
            GroupViewDetailStudent.DataSource = bsDetailGroup;

            GroupViewDetailStudent.Columns["Gender"].Visible = false;
            GroupViewDetailStudent.Columns["Email"].Visible = false;
            GroupViewDetailStudent.Columns["DateOfBirth"].Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string searchCourse = txtSearchCourse.Text;
            DataView dv = DataCourse.DefaultView;
            dv.RowFilter = string.Format("CourseID like '%{0}%'", searchCourse);
            GridViewCourse.DataSource = dv.ToTable();
        }
    }
}
