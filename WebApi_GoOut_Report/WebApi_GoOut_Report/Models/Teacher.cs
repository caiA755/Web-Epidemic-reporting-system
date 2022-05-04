using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_GoOut_Report.Models
{
    public class Teacher
    {
        public int TID { get; set; }
        public string TeacherName { get; set; }
        public string Sex { get; set; }
        public string Password { get; set; }
        public Role RID { get; set; }
        public DateTime LastLoginTime { get; set; }

    }
}