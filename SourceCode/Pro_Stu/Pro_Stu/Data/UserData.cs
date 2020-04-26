using Pro_Stu.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_Stu.Controllers
{
    class UserData
    {
        SqlConnection cnn = null;
        string strConnection = "server = DESKTOP-P8RV0NJ\\SQLEXPRESS;database=QLHS;uid=sa;pwd=19011999";

        public User getUserToLogin(string UserName, string Password)
        {
            cnn = new SqlConnection(strConnection);
            string SQL = "Select * from [User] where UserName = @UserName and Password = @Password";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);

            SqlDataReader dr;
            try
            {
                cnn.Open();
                dr = cmd.ExecuteReader();
                User u = new User();
                while (dr.Read())
                {

                    u.UserName = dr["UserName"].ToString();
                    u.Password = dr["Password"].ToString();
                    u.Gender = bool.Parse(dr["Gender"].ToString());
                    u.PhoneNumber = dr["PhoneNumber"].ToString();
                    u.Email = dr["Email"].ToString();
                    u.DateOfBirth = DateTime.Parse(dr["DateOfBirth"].ToString());
                    u.Role = dr["Role"].ToString();
                    u.Name = dr["Name"].ToString();

                }
                return u;
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                cnn.Close();
            }
            return null;
        }
        public DataTable getListUser(string Role)
        {
            DataTable dt = new DataTable();
            try
            {
                string SQL = "Select * from [User] where Role <> 'ADMIN' and Role = @Role ";
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@Role", Role);
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
        public bool checkUpdateUser(User user)
        {
            string SQL = "Update [User] set Name=@Name,Gender=@Gender,PhoneNumber=@PhoneNumber,Email=@Email,DateOfBirth=@DateOfBirth,Role=@Role where UserName=@UserName";
            bool check;
            try
            {
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
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
        public bool checkDeleteUser(string UserName)
        {
            string SQL = "Delete [User] where UserName=@UserName";
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
        public bool checkInsertUser(User user)
        {
            string SQL = "Insert into [User](UserName, Gender, PhoneNumber, Email, DateOfBirth, Role, Name)" +
                " values(@UserName,@Gender,@PhoneNumber,@Email,@DateOfBirth,@Role,@Name)";
            bool check;
            try
            {
                
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
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
        public DataTable SearchUser(string Name, string Role)
        {
            DataTable dt = new DataTable();
            string SQL = "Select * from [User] where Name like  '%'+@Name+'%' and Role <> 'ADMIN' and Role = @Role";
            try
            {
                 cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Role", Role);
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
        public bool checkUpdateUserPassword(string Password, string UserName)
        {
            string SQL = "Update [User] set Password=@Password where UserName=@UserName";
            bool check;
            try
            {

                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@Password", Password);
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
        public bool checkUpdateInfoUser(string PhoneNumber, string Email, string UserName)
        {
            string SQL = "Update [User] set PhoneNumber=@PhoneNumber, Email = @Email where UserName=@UserName";
            bool check;
            try
            {
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", Email);
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
