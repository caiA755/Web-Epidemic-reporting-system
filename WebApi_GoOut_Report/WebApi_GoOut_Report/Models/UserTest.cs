using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_GoOut_Report.Models
{
    public class UserTest
    {
       public int UID { get; set; }

       public int RID { get; set; }

       public string Password { get; set; }
    }
    public class RecordTest
    {
        public string UID { get; set; }
        public string TID { get; set; }
        public string UName { get; set; }
        public string TName { get; set; }
        public string Reason { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
    public class StuOutCount {
        public string ClassName { get; set; }
        public int OutCount { get; set; }
    }
    public class OriginStu {
        public string SNO { get; set; }
        public string Email { get; set; }
        public string Vcode { get; set; }

    }
}