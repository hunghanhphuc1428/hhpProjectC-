using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_Stu.Data
{
    public class ScheduleData
    {
        private static ScheduleData _instance;
        private ScheduleData() { }
        public static ScheduleData Instance()
        {
            if (_instance == null)
                _instance = new ScheduleData();
            return _instance;
        }
        public DataTable GetListSchedule()
        {
            string query = "SELECT * FROM [dbo].[Schedule]";
            DataTable data = DataProvider.GetInstance().ExcuteQuery(query);
            return data;
        }
        public DataTable GetListSlot()
        {
            string query = "SELECT * FROM [dbo].[Slot]";
            DataTable data = DataProvider.GetInstance().ExcuteQuery(query);
            return data;
        }
        public bool AddSchedule(string date, string slotID, string GroupID, string CourseID, string UserNameBooker)
        {
            int result = 0;
            string query = string.Format("INSERT [dbo].[Schedule ] VALUES ( '{0}','{1}','{2}','{3}','{4}', GETDATE() )", date, slotID,
                GroupID, CourseID, UserNameBooker);
            try
            {
                result = DataProvider.GetInstance().ExcuteNonQuery(query);
            }
            catch (SqlException e)
            {

                throw new Exception(e.Message);
            }
            return result > 0;
        }
        public bool EditSchedule(string date, string slotID, string GroupID, string CourseID, string UserNameBooker, string index)
        {
            int result = 0;
            string query = string.Format("UPDATE [dbo].[Schedule ] SET SlotID = '{1}' ,CourseID = '{3}' , GroupID = '{2}' , [Date] = '{0}' , DateCreated = GETDATE() , UserNameBooker = '{4}' WHERE [Index] = '{5}'", date, slotID,
                GroupID, CourseID, UserNameBooker, index);
            try
            {
                result = DataProvider.GetInstance().ExcuteNonQuery(query);
            }
            catch (SqlException e)
            {

                throw new Exception(e.Message);
            }
            return result > 0;
        }
        public bool DeleteSchedule(string index)
        {
            int result = 0;
            string query = "DELETE [dbo].[Schedule ] WHERE [Index] = " + index;
            result = DataProvider.GetInstance().ExcuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteUserSchedule(string GroupID, string index)
        {

            int result = DataProvider.GetInstance().ExcuteNonQuery("exec USP_DeleteScheduleTeacherAndStudent  " +
                " @idgroup , @indexSchedule   ", new object[] { GroupID, index  });
            return result > 0;
        }
        public DataTable SearchSchedule(string GroupID)
        {
            string query = string.Format("SELECT * FROM [dbo].[Schedule ] WHERE GroupID like '%{0}%' ", GroupID);
            DataTable data = DataProvider.GetInstance().ExcuteQuery(query);
            return data;
        }
        public DataTable SearchTeacher(string name)
        {
            string query = string.Format("SELECT * From dbo.[User]  where Name like  '%'+'{0}'+'%' and Role = 'TEACHER' ", name);
            DataTable data = DataProvider.GetInstance().ExcuteQuery(query);
            return data;
        }
        public DataTable SearchScheduleByDate(DateTime Fromdate, DateTime toDate)
        {
            //DataTable data;
            //string dateString = date.ToString().Split(' ')[0];
            //string query = String.Format("SELECT * FROM [dbo].[Schedule ] WHERE [Date] = '{0}' ",dateString);
            //data = DataProvider.GetInstance().ExcuteQuery(query);
            return DataProvider.GetInstance().ExcuteQuery("exec USP_GetScheduleByDate @fromDate , @toDate ", new object[] { Fromdate, toDate });

        }
        public bool AddUserSchedule(string groupId)
        {
            int result = DataProvider.GetInstance().ExcuteNonQuery("exec  USP_AddUserSchedule @idgroup ", new object[] { groupId });
            return result > 0;
        }
        public bool AddTeacherSchedule(string username, string index)
        {
            int result = DataProvider.GetInstance().ExcuteNonQuery(" exec USP_AddTeacher @username , @index  ", new object[] { username, index });
            return result > 0;
        }

    }
}
