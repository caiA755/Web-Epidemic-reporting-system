using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_GoOut_Report.DataHandler.BLL;
using WebApi_GoOut_Report.Models;

namespace WebApi_GoOut_Report.Controllers
{
    public class RecordsController : ApiController
    {
        GoOutRecordBLL RecordBLL = new GoOutRecordBLL(); 
         [HttpPost]
        public IHttpActionResult InsertRecord([FromBody]RecordTest r)
        {
            OutRecord outRecord = new OutRecord();
            StuUser stu = new StuUser();
            stu.UID = int.Parse(r.UID);
            stu.Username = r.UName;
            outRecord.UID = stu;
            Teacher t = new Teacher();
            t.TID = int.Parse(r.TID);
            t.TeacherName = r.TName;
            outRecord.TID = t;
            outRecord.StartTime = r.StartTime;
            outRecord.EndTime = r.EndTime;
            outRecord.Reason = r.Reason;
            return Json<Boolean>(RecordBLL.InsertRecord(outRecord));
        }

        [HttpGet]
        public IHttpActionResult getSelfRecord(int  UID)
        {   
            return Json<List<OutRecord>>(RecordBLL.getSelfRecord(UID));
        }

        [HttpPost]
        public IHttpActionResult getSelfRecordByTime([FromBody]RecordTest record)
        {
            return Json<List<OutRecord>>(RecordBLL.getSelfRecordBytime(int.Parse(record.UID),record.StartTime,record.EndTime));
        }

        [HttpGet]
        public IHttpActionResult getSelfRecordByTid(int TID)
        {
            return Json<List<OutRecord>>(RecordBLL.outRecords(TID));
        }

        [HttpGet]
        public IHttpActionResult changeStatus(int SOID,int Status)
        {
            return Json<Boolean>(RecordBLL.UpdateRecordsStatus(Status,SOID));
        }

        [HttpPost]
        public IHttpActionResult outRecordsBytime([FromBody] RecordTest record)
        {
            return Json<List<OutRecord>>(RecordBLL.outRecordsBytime(int.Parse(record.TID.ToString()),record.StartTime,record.EndTime));
        }
        [HttpGet]
        public IHttpActionResult getOutCounts(int TID)
        {
            return Json<List<StuOutCount>>(RecordBLL.GetOutCounts(TID));
        }

        [HttpPost]
        public IHttpActionResult getAllrecords()
        {
            return Json<List<OutRecord>>(RecordBLL.outRecords());
        }
        [HttpPost]
        public IHttpActionResult getOutCounts()
        {
            return Json<List<StuOutCount>>(RecordBLL.GetOutCounts());
        }

        [HttpPost]
        public IHttpActionResult getAllrecordsBytime([FromBody] RecordTest record)
        {
            return Json<List<OutRecord>>(RecordBLL.outRecords(record.StartTime,record.EndTime));
        }
     


        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}