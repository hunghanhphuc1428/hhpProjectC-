using System;
using System.Data;
using System.Data.SqlClient;

namespace Pro_Stu.Data
{
    class Schedule_User_Data
    {

        SqlConnection cnn = null;
        string strConnection = "server = DESKTOP-P8RV0NJ\\SQLEXPRESS;database=QLHS;uid=sa;pwd=19011999";
        public DataTable getListShedule_User(string UserName,DateTime FirstOfWeek, DateTime LastOfWeek)
        {
            DataTable dt = new DataTable();
            try
            {
                //string SQL1 = "select A.* " +
                //    "from [Schedule ] as A, (Select A.IndexShedule from Schedule_User as A where UserName = @UserName) as B" +
                //    " where A.[Index] = B.IndexShedule and A.Date Between @FirstOfWeek AND @LastOfWeek ";

                string SQL = "select A.*  , B.Status "
                   + " from[Schedule] as A, (Select A.IndexShedule, A.Status from Schedule_User as A where UserName = @UserName) as B"
                  + "   where A.[Index] = B.IndexShedule and A.Date Between @FirstOfWeek AND @LastOfWeek";
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@FirstOfWeek", FirstOfWeek);
                cmd.Parameters.AddWithValue("@LastOfWeek", LastOfWeek);

                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                cnn.Close();
            }
            return dt;
        }
        public DataTable getListGroup_User(string UserName)
        {
            DataTable dt = new DataTable();
            try
            {
                string SQL = "select DISTINCT A.GroupID " +
                    "from [Schedule ] as A, (Select A.IndexShedule from Schedule_User as A where UserName = @UserName) as B " +
                    "where A.[Index] = B.IndexShedule";
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                cnn.Close();
            }
            return dt;

        }
        public DataTable getListStudentAttendance(string GroupID, DateTime date, string slot)
        {
            DataTable dt = new DataTable();
            try
            {
                string SQL = "select A.UserName, A.Status, B.Name from" +
                    " Schedule_User as A, (select A.UserName,A.Name from [User] as A,(select UserName from User_Group where GroupID = 'SE1321') as B where A.UserName = B.UserName) as B, (select A.[Index] " +
                    "from [Schedule ] as A " +
                    " where A.Date = @Date and A.SlotID = @Slot and A.GroupID = 'SE1321')  as C " +
                    "where A.UserName = B.UserName and A.IndexShedule = C.[Index]";
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@GroupID", GroupID);
                cmd.Parameters.AddWithValue("@Slot", slot);
                cmd.Parameters.AddWithValue("@Date", date);
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                cnn.Close();
            }
            return dt;
        }
        public bool CheckUpdate(string UserName, bool Status)
        {
            bool check;
            try
            {
                string SQL = "Update Schedule_User set Status = @Status where UserName = @UserName";
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);

                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Status", Status);
                cnn.Open();
                check = cmd.ExecuteNonQuery() > 0;
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                cnn.Close();
            }
            return check;

        }
        public DataTable getListCourseID_GroupID(string UserName)
        {
            DataTable dt = new DataTable();
            try
            {
                string SQL = "select A.CourseName, B.CourseID, B.GroupID "+
                  "  from Course as A, "+
			
                 " ( select DISTINCT A.CourseID, A.GroupID "+
             "   from[Schedule ] as A ,	(select DISTINCT A.IndexShedule "+
                    "  from Schedule_User as A "+
                 "  where A.UserName = @UserName) AS B, Course as C "+
                 " where A.[Index] = B.IndexShedule ) as B "+
               " where A.CourseID = B.CourseID";
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@UserName", UserName);
           
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                cnn.Close();
            }
            return dt;
        }
        public DataTable getListGroupID_From_CourseID(string UserName, string CourseID)
        {
            DataTable dt = new DataTable();
            try
            {
                string SQL = "Select B.GroupID" +
                    " from " +
                    " (select A.CourseName, B.CourseID, B.GroupID " +
                  "  from Course as A, " +

                 " ( select DISTINCT A.CourseID, A.GroupID " +
             "   from[Schedule ] as A ,	(select DISTINCT A.IndexShedule " +
                    "  from Schedule_User as A " +
                 "  where A.UserName = @UserName) AS B, Course as C " +
                 " where A.[Index] = B.IndexShedule ) as B " +
               " where A.CourseID = B.CourseID ) as B" +
               " where B.CourseID = @CourseID";
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@CourseID", CourseID);
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                cnn.Close();
            }
            return dt;
        }
        public bool checkDeleteUser_ScheduleUser_Foreign_Key(string UserName)
        {
            string SQL = "Delete from Schedule_User where UserName = @UserName";
            bool check;
            try
            {
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@UserName", UserName);

                cnn.Open();
                check = cmd.ExecuteNonQuery() > 0;
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                cnn.Close();
            }
            return check;

        }
    }
}
