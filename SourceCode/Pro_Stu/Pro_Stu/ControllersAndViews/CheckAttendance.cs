using Pro_Stu.Data;
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
    
    public partial class CheckAttendance : Form
    {
        DataTable listAttendance = new DataTable();
        public CheckAttendance(DataTable data)
        {
            InitializeComponent();
            this.listAttendance = data;
            listAttendance.Columns["Status"].ColumnName = "Attendance";
            bsListCheckAttendance.DataSource = listAttendance;
            GridViewAttendance.DataSource = bsListCheckAttendance;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            bool check=false;
            Schedule_User_Data ScheduleUserData = new Schedule_User_Data();
            try
            {
                foreach (DataRow row in listAttendance.Rows)
                {
                  check =  ScheduleUserData.CheckUpdate(row["UserName"].ToString(), bool.Parse(row["Attendance"].ToString()));
                }
                if (check)
                {
                    MessageBox.Show("Insert Complete");
                }
            }
            catch
            {
                MessageBox.Show("Insert False");
            }
        }
    }
}
