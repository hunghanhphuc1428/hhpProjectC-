using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_Stu.Models
{
    public class Schedule
    {
        public Schedule(string date, string slotid, string groupid,
            string courseid, string userNameBooker, DateTime dateCreated)
        {
            Date = date;
            SlotID = slotid;
            GroupID = groupid;
            CourseID = courseid;
            UserNameBooker = userNameBooker;
            DateCreated = dateCreated;
        }
        public string Date { get; set; }
        public string SlotID { get; set; }
        public string GroupID { get; set; }
        public string CourseID { get; set; }
        public string UserNameBooker { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
