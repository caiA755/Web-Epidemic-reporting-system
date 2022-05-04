using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_GoOut_Report.Models
{
    public class Dept
    {
        public int DID { get; set; }
        public string DeptName { get; set; }
        public string ClassName { get; set; }
        public Teacher TID { get; set; }
        
       public string ClassType { get; set; }

    }
}