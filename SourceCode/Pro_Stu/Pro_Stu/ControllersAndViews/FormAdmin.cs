using Pro_Stu.Controllers;
using Pro_Stu.Data;
using Pro_Stu.Models;
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
    public partial class FormAdmin : Form
    {
        BindingSource courselist = new BindingSource();
        BindingSource schedules = new BindingSource();
        BindingSource teachers = new BindingSource();

        User user;
        bool CheckRoleStudent = true;
        public FormAdmin(User User)
        {
            InitializeComponent();
            this.user = User;
            loadListUser();
            loadCourseData();
            AddCouresBinding();
            loadCourseType(cbCourseType);
            loadSlotIDInComboBox(cbSlotID);
            loadGroupIDInComboBox(cbGroupID);
            loadCourseIDInComboBox(cbCourseID);
            loadScheduleData();
            loadTeacherData();
            AddScheduleBinding();

        }

        public void loadListUser()
        {
            //dtDateOfBirth.Value = new DateTime(2012, 05, 28);
            //Console.WriteLine(dtDateOfBirth.Value.ToString());

            btnAdd.Enabled = false;

            txtUserName.ReadOnly = true;
            

            UserData UerData = new UserData();
            GroupData GroupData = new GroupData();

            bsUser.DataSource = UerData.getListUser("STUDENT");
            bsGroup.DataSource = GroupData.getListGroup();

            GridViewUser.DataSource = bsUser;
            GridViewGroup.DataSource = bsGroup;

            setValuesForCombobox();

            GridViewUser.Columns["Gender"].Visible = false;
            GridViewUser.Columns["Role"].Visible = false;
            GridViewGroup.Columns["DateCreateAt"].Visible = false;
            GridViewUser.Columns["Password"].Visible = false;

            txtUserName.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtPhoneNumber.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtGroupID.DataBindings.Clear();
            txtPassword.DataBindings.Clear();
            dtDateOfBirth.DataBindings.Clear();
            lbDateCreateAt.DataBindings.Clear();

            txtPassword.DataBindings.Add("Text", bsUser, "Password");
            txtUserName.DataBindings.Add("Text", bsUser, "UserName");
            txtName.DataBindings.Add("Text", bsUser, "Name");
            txtPhoneNumber.DataBindings.Add("Text", bsUser, "PhoneNumber");
            txtEmail.DataBindings.Add("Text", bsUser, "Email");
            txtGroupID.DataBindings.Add("Text", bsGroup, "GroupID");
            dtDateOfBirth.DataBindings.Add("Value", bsUser, "DateOfBirth");
            lbDateCreateAt.DataBindings.Add("Text", bsGroup, "DateCreateAt");


        }
        public void setValuesForCombobox()
        {
            GroupData GroupData = new GroupData();
            try
            {
                cbxGroupStudent.Items.Clear();
                foreach (DataRow row in GroupData.getListGroup().Rows)
                {
                    cbxGroupStudent.Items.Add(row["GroupID"]);
                }
                cbxGroupStudent.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("Ko co du lieu tren Group");
            }
        }
        //public void setReadOnlyForAllGridView(DataGridView DataGridView)
        //{
        //    foreach(DataGridViewBand band in DataGridView.Columns)
        //    {
        //        band.ReadOnly = true;
        //    }
        //}

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            string Role = "";
            string name = txtSearchName.Text;
            UserData dt = new UserData();
            if (CheckRoleStudent)
            {
                Role = "STUDENT";
            }
            else
            {
                Role = "TEACHER";
            }
            try
            {
                dtDateOfBirth.DataBindings.Clear();
                bsUser.DataSource = dt.SearchUser(name,Role);
                dtDateOfBirth.DataBindings.Add("Value", bsUser, "DateOfBirth");
            }
            catch
            {
                MessageBox.Show("Can not find");
            }
            //UserData UserData = new UserData();
            //if (CheckRoleStudent)
            //{

            //    DataView dv = UserData.getListUser("STUDENT").DefaultView;
            //    dv.RowFilter = string.Format("Name like '%{0}%'", name);
            //    GridViewDetail.DataSource = dv.ToTable();
            //}
            //else
            //{
            //    DataView dv = UserData.getListUser("TEACHER").DefaultView;
            //    dv.RowFilter = string.Format("Name like '%{0}%'", name);
            //    GridViewDetail.DataSource = dv.ToTable();
            //}
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string Role = "";
            string UserName = txtUserName.Text;
            User_Group_Data UserGroupData = new User_Group_Data();
            UserData u = new UserData();
            Schedule_User_Data schedule_User_Data = new Schedule_User_Data();
            try
            {
                UserGroupData.checkDeleteUser_Group_Foreign_Key(UserName);
                schedule_User_Data.checkDeleteUser_ScheduleUser_Foreign_Key(UserName);
                if (u.checkDeleteUser(UserName))
                {
                    MessageBox.Show("Delete complete!");
                    if (CheckRoleStudent) {
                        Role = "STUDENT";
                    }
                    else
                    {
                        Role = "TEACHER";
                    }
                    bsUser.DataSource = u.getListUser(Role);


                    GridViewGroup_SelectionChanged(null, null);
                }
            }
            catch
            {
                MessageBox.Show("Can not find id to delete");
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            String Role = "";
            User User = new User();
            User.UserName = txtUserName.Text;
            User.Password = txtPassword.Text;
            User.Gender = rdbMale.Checked;
            User.PhoneNumber = txtPhoneNumber.Text;
            User.Email = txtEmail.Text;


            User.DateOfBirth = DateTime.Parse(dtDateOfBirth.Value.ToString());

            if (rdbStudent.Checked == true)
            {

                User.Role = "STUDENT";
            }
            else
            {
                User.Role = "TEACHER";
            }

            User.Name = txtName.Text;
            UserData ud = new UserData();
            try
            {
                if (ud.checkUpdateUser(User))
                {
                    MessageBox.Show("Update Complete");
                    if (CheckRoleStudent)
                    {
                        Role = "STUDENT";
                    }
                    else
                    {
                        Role = "TEACHER";
                    }
                    bsUser.DataSource = ud.getListUser(Role);

                }
            }
            catch
            {
                MessageBox.Show("Update Fail");
            }





        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Role = "";
            User User = new User();
            User.UserName = txtUserName.Text;
            User.Password = txtPassword.Text;
            User.Gender = rdbMale.Checked;
            User.PhoneNumber = txtPhoneNumber.Text;
            User.Email = txtEmail.Text;


            User.DateOfBirth = DateTime.Parse(dtDateOfBirth.Value.ToString());
            if (rdbStudent.Checked)
            {
                User.Role = "STUDENT";
            }
            else
            {
                User.Role = "TEACHER";
            }
            User.Name = txtName.Text;
            UserData ud = new UserData();
            try
            {
                if (ud.checkInsertUser(User))
                {
                    MessageBox.Show("Insert Complete");

                    btnAdd.Enabled = false;
                    btnClearUser.Enabled = true;
                    btnEdit.Enabled = true;
                    btnRemove.Enabled = true;
                    btnAddStudentToGroup.Enabled = true;

                    txtUserName.ReadOnly = true;

                    txtPassword.DataBindings.Add("Text", bsUser, "Password");
                    txtUserName.DataBindings.Add("Text", bsUser, "UserName");
                    txtName.DataBindings.Add("Text", bsUser, "Name");
                    txtPhoneNumber.DataBindings.Add("Text", bsUser, "PhoneNumber");
                    txtEmail.DataBindings.Add("Text", bsUser, "Email");

                    if (CheckRoleStudent)
                    {
                        Role = "STUDENT";
                    }
                    else
                    {
                        Role = "TEACHER";
                    }
                    bsUser.DataSource = ud.getListUser(Role);

                }
            }
            catch
            {
                MessageBox.Show("Insert Fail");
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            Group Group = new Group();
            Group.GroupID = txtGroupID.Text;
            Group.DateCreatAt = DateTime.Now;
            GroupData GroupData = new GroupData();
            try
            {
                if (GroupData.checkInsertGroup(Group))
                {
                    MessageBox.Show("Insert Group Complete");
                    bsGroup.DataSource = GroupData.getListGroup();
                    setValuesForCombobox();
                    loadGroupIDInComboBox(cbGroupID);

                }
            }
            catch
            {
                MessageBox.Show("Insert Group Fail");
            }
        }




        private void txtSearchGroupID_TextChanged(object sender, EventArgs e)
        {
            string SearchGroupID = txtSearchGroupID.Text;
            GroupData GroupData = new GroupData();
            try
            {
                bsGroup.DataSource = GroupData.SearchGroup(SearchGroupID);
            }
            catch
            {

            }
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            string GroupID = txtGroupID.Text;
            GroupData GroupData = new GroupData();
            User_Group_Data user_Group_Data = new User_Group_Data();
            try
            {
                user_Group_Data.checkDeleteGroup_UserGroup_Foreign_Key(GroupID);
                GroupData.checkDeleteGroupID_Schedule_Foreign_Key(GroupID);
                if (GroupData.checkDeleteGroup(GroupID))
                {
                    MessageBox.Show("Delete Group Complete");
                    bsGroup.DataSource = GroupData.getListGroup();
                    setValuesForCombobox();
                }
            }
            catch
            {
                MessageBox.Show("Delete Group fail");
            }
        }



        private void GridViewGroup_SelectionChanged(object sender, EventArgs e)
        {
            string GroupID = txtGroupID.Text;
            User_Group_Data UserGroupData = new User_Group_Data();
            try
            {
                bsUser_Group.DataSource = UserGroupData.getListUser_Group(GroupID);
                GridViewDetail.DataSource = bsUser_Group;
            }
            catch
            {

            }
        }



        private void txtSearchNameGroup_TextChanged(object sender, EventArgs e)
        {
            User_Group_Data UserGroupData = new User_Group_Data();
            DataView dv = UserGroupData.getListUser_Group(txtGroupID.Text).DefaultView;
            dv.RowFilter = string.Format("Name like '%{0}%'", txtSearchNameGroup.Text);
            GridViewDetail.DataSource = dv.ToTable();
        }

        private void btnAddStudentToGroup_Click(object sender, EventArgs e)
        {
            User_Group UserGroup = new User_Group();
            UserGroup.UserName = txtUserName.Text;
            UserGroup.GroupID = cbxGroupStudent.Text;
            User_Group_Data UserGroupData = new User_Group_Data();
            try
            {
                if (UserGroupData.checkInsertUser_Group(UserGroup))
                {
                    MessageBox.Show("Insert Student To Group Complete");
                }
            }
            catch
            {
                MessageBox.Show("Insert Student To Group Fail");
            }
        }

        private void GridViewUser_SelectionChanged(object sender, EventArgs e)
        {

            bool Gender = bool.Parse(GridViewUser.Rows[GridViewUser.CurrentCell.RowIndex].Cells["Gender"].Value.ToString());
            if (Gender)
            {
                rdbMale.Checked = true;
            }
            else
            {
                rdbFemale.Checked = true;
            }
            if (GridViewUser.Rows[GridViewUser.CurrentCell.RowIndex].Cells["Role"].Value.ToString().Equals("STUDENT"))
            {
                rdbStudent.Checked = true;
                btnAddStudentToGroup.Enabled = true;
            }
            else
            {
                rdbTeacher.Checked = true;
                btnAddStudentToGroup.Enabled = false;
            }
        }

        private void btnDeleteStudentFormGroup_Click(object sender, EventArgs e)
        {
            User_Group UserGroup = new User_Group();
            UserGroup.GroupID = txtGroupID.Text;
            UserGroup.UserName = GridViewDetail.Rows[GridViewDetail.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim();

            User_Group_Data UserGroupData = new User_Group_Data();
            try
            {
                if (UserGroupData.checkDeleteUser_Group(UserGroup))
                {
                    MessageBox.Show("Delete Student in list Complete!");
                    bsUser_Group.DataSource = UserGroupData.getListUser_Group(UserGroup.GroupID);
                    GridViewDetail.DataSource = bsUser_Group;
                }
            }
            catch
            {
                MessageBox.Show("Delete Student in list Fail!");
            }
        }

        private void btnDisplayAllStudent_Click(object sender, EventArgs e)
        {
            CheckRoleStudent = true;
            UserData UserData = new UserData();
            try
            {
                bsUser.DataSource = UserData.getListUser("STUDENT");
            }
            catch
            {
                MessageBox.Show("Not data");
            }
        }

        private void btnDisplayAllTeacher_Click(object sender, EventArgs e)
        {
            CheckRoleStudent = false;
            UserData UserData = new UserData();
            try
            {
                bsUser.DataSource = UserData.getListUser("TEACHER");
            }
            catch
            {
                MessageBox.Show("Not data");
            }
        }
        private void btnClearUser_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnClearUser.Enabled = false;
            btnEdit.Enabled = false;
            btnRemove.Enabled = false;
            btnAddStudentToGroup.Enabled = false;

            txtUserName.ReadOnly = false;



            txtUserName.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtPhoneNumber.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtPassword.DataBindings.Clear();

            txtUserName.Clear();
            txtName.Clear();
            txtPhoneNumber.Clear();
            txtEmail.Clear();
            txtPassword.Clear();


        }

        #region Hieu
        #region Methods
        void AddCouresBinding()
        {
            dtgvCourse.DataSource = courselist;

            txtCourseID.DataBindings.Add(new Binding("Text", dtgvCourse.DataSource, "CourseID", true, DataSourceUpdateMode.Never));
            txtCourseName.DataBindings.Add(new Binding("Text", dtgvCourse.DataSource, "CourseName", true, DataSourceUpdateMode.Never));
            //  cbCourseType.DataBindings.Add(new Binding("Text", dtgvCourse.DataSource, "CourseType", true, DataSourceUpdateMode.Never));
        }
        void loadCourseData()
        {
            List<Course> courses = CourseData.GetInstance().GetListCourse();
            courselist.DataSource = courses;
        }
        void loadCourseType(ComboBox cb)
        {
            List<CourseType> courseTypes = CourseTypeData.GetInstance().loadCourseType();
            cb.DataSource = courseTypes;
            cb.DisplayMember = "CourseTypeName";
        }
        DataTable SearchCourseName(string name)
        {
            DataTable data = CourseData.GetInstance().SearchCourseName(name);
            return data;
        }
        #endregion
        #region Events
        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(txtCourseID.Text) || String.IsNullOrEmpty(txtCourseName.Text)))
            {
                string id = txtCourseID.Text;
                string name = txtCourseName.Text;
                string type = cbCourseType.Text;
                string idType = CourseTypeData.GetInstance().GetCourseTypeIdByCourseType(type);
                if (CourseData.GetInstance().InsertCourse(id, name, idType))
                {
                    MessageBox.Show("Add Successful");
                    loadCourseData();
                    loadCourseIDInComboBox(cbCourseID);
                }
                else
                {
                    MessageBox.Show("Add Fail");
                }
            }
        }

        private void btnEditCourse_Click(object sender, EventArgs e)
        {
            string id = txtCourseID.Text;
            string name = txtCourseName.Text;
            string type = cbCourseType.Text;
            string idType = CourseTypeData.GetInstance().GetCourseTypeIdByCourseType(type);
            if (CourseData.GetInstance().EditCoursẹ(id, name, idType))
            {
                MessageBox.Show("Edit Successful");
                loadCourseData();
            }
            else
            {
                MessageBox.Show("Edit Fail");
            }
        }

        private void btnRemoveCourse_Click(object sender, EventArgs e)
        {
            string id = txtCourseID.Text;
            if (CourseData.GetInstance().DeleteCourse(id))
            {
                MessageBox.Show("Delete Successful");
                loadCourseData();
            }
            else
            {
                MessageBox.Show("Delete Fail");
            }
        }

        private void btnSearchCourse_Click(object sender, EventArgs e)
        {
            string name = txtSearchCourse.Text;
            DataTable courses = SearchCourseName(name);
            courselist.DataSource = courses;
        }
        private void dtgvCourse_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvCourse.SelectedCells.Count > 0)
            {
                string CourseTypeID = dtgvCourse.SelectedCells[0].OwningRow.Cells["CourseType"].Value.ToString();
                int index = -1;
                int i = 0;
                foreach (CourseType item in cbCourseType.Items)
                {
                    if (item.CourseTypeID == CourseTypeID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbCourseType.SelectedIndex = index;
            }
        }
        void loadTeacherData()
        {
            UserData userData = new UserData();
            try
            {
                teachers.DataSource = userData.getListUser("TEACHER");
            }
            catch (Exception)
            {

                MessageBox.Show("Not Data");
            }
        }
        void loadScheduleData()
        {
            schedules.DataSource = ScheduleData.Instance().GetListSchedule();
            lbDateCreated.Text = "DateCreated : " + DateTime.Now;
            lbUserNameBooker.Text = "UserNameBooker : " + user.Name;

        }
        void AddScheduleBinding()
        {
            dtgvSchedule.DataSource = schedules;
            dtgvListTeacher.DataSource = teachers;
            dtpkDate.DataBindings.Add(new Binding("Value", dtgvSchedule.DataSource, "Date", true, DataSourceUpdateMode.Never));
            cbSlotID.DataBindings.Add(new Binding("Text", dtgvSchedule.DataSource, "SlotID", true, DataSourceUpdateMode.Never));
            cbGroupID.DataBindings.Add(new Binding("Text", dtgvSchedule.DataSource, "GroupID", true, DataSourceUpdateMode.Never));
            txtSearchTeacher.DataBindings.Add(new Binding("Text", dtgvListTeacher.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            //     lbUserNameBooker.DataBindings.Add(new Binding("Text", dtgvSchedule.DataSource, "UserNameBooker", true, DataSourceUpdateMode.Never));
        }
        void loadGroupIDInComboBox(ComboBox cb)
        {
            GroupData g = new GroupData();
            cb.DataSource = g.getListGroup();
            cb.DisplayMember = "GroupID";
        }
        void loadCourseIDInComboBox(ComboBox cb)
        {
            List<Course> courses = CourseData.GetInstance().GetListCourse();
            cb.DataSource = courses;
            cb.DisplayMember = "CourseName";
        }
        void loadSlotIDInComboBox(ComboBox cb)
        {
            cb.DataSource = ScheduleData.Instance().GetListSlot();
            cb.DisplayMember = "SlotID";
        }

        bool checkDuplicateData(string newDate, string newSlotID, string newGroupID)
        {
            foreach (DataGridViewRow item in dtgvSchedule.Rows)
            {
                int index = item.Index;
                index++;
                if (!index.Equals(dtgvSchedule.Rows.Count))
                {

                    string crdate = item.Cells["Date"].Value.ToString();
                    string crslot = item.Cells["SlotID"].Value.ToString();
                    string crgroup = item.Cells["GroupID"].Value.ToString();
                    //MessageBox.Show(item.Cells["Date"].Value.ToString());
                    if (crdate.Equals(newDate) && crslot.Equals(newSlotID) && crgroup.Equals(newGroupID))
                    {
                        //MessageBox.Show("TRUE");
                        return false;
                    }
                }
            }
            return true;
        }
        void setDateToAddScheduleData()
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(7);
        }
        bool addUserSchdule(string groupid)
        {
            return ScheduleData.Instance().AddUserSchedule(groupid);
        }
        bool addTeacherSchdule(string username, string index)
        {
            return ScheduleData.Instance().AddTeacherSchedule(username, index);
        }
        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            int weeks = Convert.ToInt32(nmAddBasedWeek.Value);
            int count = 0;
            do
            {
                string date = dtpkDate.Value.ToString().Split(' ')[0];
                string datecheck = dtpkDate.Value.ToString();
                string slotID = cbSlotID.Text;
                string groupID = cbGroupID.Text;
                string courseID = CourseData.GetInstance().GetCourseIDByCourseName(cbCourseID.Text);
                string userNameBooker = user.UserName;
                if (checkDuplicateData(datecheck, slotID, groupID))
                {
                    if (ScheduleData.Instance().AddSchedule(date, slotID, groupID, courseID, userNameBooker))
                    {
                        MessageBox.Show("Add Successful");
                        if (addUserSchdule(cbGroupID.Text))
                        {
                            string info = "Add Schedule to group " + cbGroupID.Text + " Successful";
                            MessageBox.Show(info);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Add Fail");
                    }
                }
                else
                {
                    MessageBox.Show("Duplicate Data");
                }
                if (weeks != 1)
                {
                    setDateToAddScheduleData();

                }
                count++;

            } while (count < weeks);

            loadScheduleData();
        }

        private void btnEditSchedule_Click(object sender, EventArgs e)
        {
            string date = dtpkDate.Value.ToString().Split(' ')[0];
            string datecheck = dtpkDate.Value.ToString();

            string slotID = cbSlotID.Text;
            string groupID = cbGroupID.Text;
            string courseID = CourseData.GetInstance().GetCourseIDByCourseName(cbCourseID.Text);
            string userNameBooker = user.UserName;
            string index = dtgvSchedule.SelectedCells[0].OwningRow.Cells["Index"].Value.ToString();
            if (checkDuplicateData(datecheck, slotID, groupID))
            {
                if (ScheduleData.Instance().EditSchedule(date, slotID, groupID, courseID, userNameBooker, index))
                {
                    MessageBox.Show("Edit Successful");
                    loadScheduleData();
                }
                else
                {
                    MessageBox.Show("Edit Fail");
                }
            }
            else
            {
                MessageBox.Show("Duplicate Data");
            }
        }

        private void dtgvSchedule_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvSchedule.SelectedCells.Count > 0)
            {
                string id = dtgvSchedule.SelectedCells[0].OwningRow.Cells["CourseID"].Value.ToString();
                int index = -1;
                int i = 0;
                foreach (Course item in cbCourseID.Items)
                {
                    if (item.CourseID == id)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbCourseID.SelectedIndex = index;
            }
        }
        bool DeleteScheduleFromStudentAndTeacher(string groupid, string index)
        {
            return ScheduleData.Instance().DeleteUserSchedule(groupid, index);
        }
        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            string index = dtgvSchedule.SelectedCells[0].OwningRow.Cells["Index"].Value.ToString();
            DeleteScheduleFromStudentAndTeacher(cbGroupID.Text, index);

            if (MessageBox.Show("Do you really want to delete this", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (ScheduleData.Instance().DeleteSchedule(index))
                {
                    MessageBox.Show("Delete Successful");
                }
                else
                {
                    MessageBox.Show("Delete Fail");
                }
            }

            loadScheduleData();


        }
        void searhScheduleByDate(DateTime fromDate, DateTime toDate)
        {
            DataTable data = ScheduleData.Instance().SearchScheduleByDate(fromDate, toDate);
            schedules.DataSource = data;
        }
        private void btnSearchSchedule_Click(object sender, EventArgs e)
        {
            searhScheduleByDate(dtpkSearchSheduleFromDate.Value, dtpkSearchScheduleToDate.Value);

        }

        private void btnShowSchedule_Click(object sender, EventArgs e)
        {
            loadScheduleData();
        }
        private void btnSearchTeacher_Click(object sender, EventArgs e)
        {
            string name = txtSearchTeacher.Text;
            DataTable data = ScheduleData.Instance().SearchTeacher(name);
            teachers.DataSource = data;
        }

        private void btnAddScheduleToTeacher_Click(object sender, EventArgs e)
        {
            string index = dtgvSchedule.SelectedCells[0].OwningRow.Cells["Index"].Value.ToString();
            string username = dtgvListTeacher.SelectedCells[0].OwningRow.Cells["UserName"].Value.ToString();
            if (addTeacherSchdule(username, index))
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Duplicate Schedule");
            }
        }

        #endregion

        #endregion


    }
}
