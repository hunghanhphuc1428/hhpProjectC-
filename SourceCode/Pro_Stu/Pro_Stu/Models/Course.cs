using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_Stu.Models
{
    public class Course
    {
        public Course(string courseid, string coursename, string coursetype)
        {
            CourseID = courseid;
            CourseName = coursename;
            CourseType = coursetype;
        }
        public Course(DataRow row)
        {
            CourseID = row["CourseID"].ToString();
            CourseName = row["CourseName"].ToString();
            CourseType = row["CourseType"].ToString();
        }
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseType { get; set; }

    }
}
