using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_Stu.Models
{
    public class CourseType
    {

        public CourseType(string id, string name)
        {
            CourseTypeID = id;
            CourseTypeName = name;
        }
        public CourseType(DataRow row)
        {
            CourseTypeID = (row["CourseTypeID"].ToString());
            CourseTypeName = row["CourseTypeName"].ToString();

        }
        public string CourseTypeID { get; set; }
        public string CourseTypeName { get; set; }

    }
}
