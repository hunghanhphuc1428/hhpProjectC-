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
    public class CourseData
    {
        private static CourseData _instance;
        private CourseData() { }
        public static CourseData GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CourseData();
            }
            return _instance;
        }
        public DataTable GetCourseTypeNameByCourseType(int id)
        {
            string query = "SELECT ct.CourseTypeName FROM [dbo].[Course] as c , [dbo].[CourseType] as ct WHERE c.CourseType = " + id;
            DataTable data = DataProvider.GetInstance().ExcuteQuery(query);
            return data;
        }
        public string GetCourseIDByCourseName(string name)
        {
            string query = "SELECT  * FROM [dbo].[Course] WHERE CourseName = @name  ";
            DataTable data = DataProvider.GetInstance().ExcuteQuery(query, new object[] { name });
            foreach (DataRow item in data.Rows)
            {
                Course t = new Course(item);
                return t.CourseID;

            }
            return null;
        }
        public List<Course> GetListCourse()
        {
            List<Course> courses = new List<Course>();
            string query = "SELECT * FROM [dbo].[Course] ";
            DataTable data = DataProvider.GetInstance().ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Course c = new Course(item);
                courses.Add(c);
            }
            return courses;
        }
        public DataTable SearchCourseName(string name)
        {
            string query = string.Format("SELECT * FROM [dbo].[Course] WHERE CourseName like '%{0}%' ", name);
            DataTable data = DataProvider.GetInstance().ExcuteQuery(query);
            return data;
        }
        public bool InsertCourse(string ID, string Name, string type)
        {
            int result = 0;
            string query = string.Format("INSERT [dbo].[Course] VALUES ('{0}', '{1}' , '{2}'  )", ID, Name, type);
            try
            {
                result = DataProvider.GetInstance().ExcuteNonQuery(query);

            }
            catch (Exception )
            {

                throw new Exception("Duplicate data");
            }

            return result > 0;
        }
        public bool EditCoursẹ(string ID, string Name, string type)
        {
            int result = 0;
            string query = "UPDATE [dbo].Course SET CourseType = @type , CourseName = @name  WHERE CourseID = @id ";
            try
            {
                result = DataProvider.GetInstance().ExcuteNonQuery(query, new object[] { type , Name, ID});

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return result > 0;
        }
        public bool DeleteCourse(string ID)
        {
            int result = 0;
            string query = "DELETE [dbo].Course WHERE CourseID = @id ";
            result = DataProvider.GetInstance().ExcuteNonQuery(query, new object[] { ID});
            return result > 0;
        }
    }
}
