using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_GoOut_Report.Models
{
    public class OutRecord
    {
        public int SOID { get; set; }
        public StuUser UID { get; set; }
        public Teacher TID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Reason { get; set; }
        public DateTime CommitTime { get; set; }
        public Status StatusID { get; set; }
        public string ReplyText { get; set; }

        public string Status { get; set; }
    }
}