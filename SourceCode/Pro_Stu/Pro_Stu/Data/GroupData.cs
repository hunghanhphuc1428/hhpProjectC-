using Pro_Stu.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_Stu.Data
{
    class GroupData
    {
        SqlConnection cnn = null;
        string strConnection = "server = DESKTOP-P8RV0NJ\\SQLEXPRESS;database=QLHS;uid=sa;pwd=19011999";
        public DataTable getListGroup()
        {
            DataTable dt = new DataTable();
            try
            {
                string SQL = "Select * from [Group] ";
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
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
        public bool checkInsertGroup(Group group)
        {
            string SQL = "Insert into [Group](GroupID, DateCreateAt)" +
                " values(@GroupID, @DateCreateAt)";
            bool check;
            try
            {

                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@GroupID", group.GroupID);
                cmd.Parameters.AddWithValue("@DateCreateAt", group.DateCreatAt);
 
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
        public DataTable SearchGroup(string GroupID)
        {
            DataTable dt = new DataTable();
            string SQL = "Select * from [Group] where GroupID like  '%'+@GroupID+'%'";
            try
            {
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@GroupID", GroupID);
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch
            {

            }
            finally
            {
                cnn.Close();
            }
            return dt;
        }
        public bool checkDeleteGroup(string GroupID)
        {
            string SQL = "Delete [Group] where GroupID=@GroupID";
            bool check;
            try
            {
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@GroupID", GroupID);
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
        public bool checkDeleteGroupID_Schedule_Foreign_Key(string GroupID)
        {
            string SQL = 
                         "   delete "+
                          "  from Schedule_User "+
                          "  where IndexShedule = "+
                          "  (select[Index] "+
                          "  from[Schedule] "+
                          "  where GroupID = @GroupID) "+

                          "  Delete from[Schedule] where GroupID = @GroupID  ";
            bool check;
            try
            {
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@GroupID", GroupID);

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
