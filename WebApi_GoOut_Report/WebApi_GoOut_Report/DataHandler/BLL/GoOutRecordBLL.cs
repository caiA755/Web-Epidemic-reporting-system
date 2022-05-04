using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_GoOut_Report.DataHandler.DAL;
using WebApi_GoOut_Report.Models;

namespace WebApi_GoOut_Report.DataHandler.BLL
{
    public class GoOutRecordBLL
    {
        GoOutRecordDAL goOutRecordDAL = new GoOutRecordDAL();
        public List<OutRecord> outRecords()
        {
            return goOutRecordDAL.outRecords();
        }
        //获取所有外出记录 （老师的权限：只能查看所负责班级学生的记录）
        public List<OutRecord> outRecords(int TID)
        {
            return goOutRecordDAL.outRecords(TID);
        }
        public List<OutRecord> outRecords(DateTime start,DateTime end)
        {
            return goOutRecordDAL.outRecords(start,end);
        }
        //外出记录按时间查询

        //更新外出记录 改变外出状态
        public bool UpdateRecordsStatus(int status, int SOID)
        {
            return goOutRecordDAL.UpdateRecordsStatus(status, SOID);
        }
        
        public List<OutRecord> outRecordsBytime(int TID,DateTime start,DateTime end)
        {
            return goOutRecordDAL.outRecordsBytime(TID,start, end);
        }
        //获取外出记录条数
        public bool UpdateRecordsCount()
        {
            return goOutRecordDAL.UpdateRecordsCount();
        }
        public bool InsertRecord(OutRecord record)
        {
            return goOutRecordDAL.InsertRecord(record);
        }
        public List<OutRecord> getSelfRecord(int UID)
        {
            return goOutRecordDAL.getSelfRecord(UID);
        }
        public List<OutRecord> getSelfRecordBytime(int UID, DateTime starttime, DateTime endTime)
        {
            return goOutRecordDAL.getSelfRecordBytime(UID,starttime,endTime);
        }
        public List<StuOutCount> GetOutCounts(int TID)
        {
            return goOutRecordDAL.GetOutCounts(TID);
        }
        public List<StuOutCount> GetOutCounts()
        {
            return goOutRecordDAL.GetOutCounts();
        }
     
        }
}