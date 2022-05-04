using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_GoOut_Report.Models
{
    public class StuUser
    {
        public int UID { get; set; }
         public string Username { get; set; }
        public Role RID { get; set; }
        public string RRID { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public Dept ClassID { get; set; }
        public DateTime RegisterTime { get; set; }
        
        public DateTime LastLoginTime { get; set; }
        public string Phone { get; set; }

        public string SNO { get; set; }

    }
}