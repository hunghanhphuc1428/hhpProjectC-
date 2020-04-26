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
    class User_Group_Data
    {
        SqlConnection cnn = null;
        string strConnection = "server = DESKTOP-P8RV0NJ\\SQLEXPRESS;database=QLHS;uid=sa;pwd=19011999";
        public DataTable getListUser_Group(string GroupID)
        {

            DataTable dt = new DataTable();
            try
            {
                string SQL = "select A.UserName,A.Name, A.Gender, A.DateOfBirth,A.Email" +
                    " from [User] as A,(select UserName from User_Group where GroupID = @GroupID) as B " +
                    "where A.UserName = B.UserName";
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@GroupID", GroupID);
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
        public bool checkDeleteUser_Group(User_Group UserGroup)
        {
            string SQL = "Delete from User_Group where UserName = @UserName and GroupID = @GroupID";
            bool check;
            try
            {
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@UserName", UserGroup.UserName);
                cmd.Parameters.AddWithValue("@GroupID", UserGroup.GroupID);
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
        public bool checkDeleteUser_Group_Foreign_Key(string UserName)
        {
            string SQL = "Delete from User_Group where UserName = @UserName";
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
        public bool checkDeleteGroup_UserGroup_Foreign_Key(string GroupID)
        {
            string SQL = "Delete from User_Group where GroupID = @GroupID";
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
        public bool checkInsertUser_Group(User_Group UserGroup)
        {
            string SQL = "Insert into [User_Group](UserName, GroupID)" +
                " values(@UserName, @GroupID)";
            bool check;
            try
            {

                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@UserName", UserGroup.UserName);
                cmd.Parameters.AddWithValue("@GroupID", UserGroup.GroupID);

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
