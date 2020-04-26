using Pro_Stu.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_Stu.Data
{
    public class CourseTypeData
    {
        private static CourseTypeData _instance;
        private CourseTypeData() { }
        public static CourseTypeData GetInstance()
        {
            if (_instance == null)
                _instance = new CourseTypeData();
            return _instance;
        }
        public void InsertCourseTypeID(int id, string CoureTypeName)
        {
            DataProvider.GetInstance().ExcuteNonQuery("INSERT [dbo].CourseType VALUES ( '@CourseTypeID' , '@CourseTypeName' )", new object[] { id, CoureTypeName });
        }
        public List<CourseType> loadCourseType()
        {
            List<CourseType> listCourseType = new List<CourseType>();
            string query = " SELECT * FROM [dbo].[CourseType] ";
            DataTable data = DataProvider.GetInstance().ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                CourseType ctype = new CourseType(item);
                listCourseType.Add(ctype);
            }
            return listCourseType;
        }
        public string GetCourseTypeIdByCourseType(string type)
        {
            string query = "SELECT  * FROM [dbo].[CourseType] WHERE CourseTypeName = @type ";
            DataTable data = DataProvider.GetInstance().ExcuteQuery(query, new object[] { type });
            foreach (DataRow item in data.Rows)
            {
                CourseType t = new CourseType(item);
                return t.CourseTypeID;

            }
            return null;
        }
        public string GetCourseTypeNameByCourseTypeID(string idtype)
        {
            string query = "SELECT  * FROM [dbo].[CourseType] WHERE CourseTypeID = @idtype  ";
            DataTable data = DataProvider.GetInstance().ExcuteQuery(query,new object[] { idtype });
            foreach (DataRow item in data.Rows)
            {
                CourseType t = new CourseType(item);
                return t.CourseTypeName;

            }
            return null;
        }

    }
}
