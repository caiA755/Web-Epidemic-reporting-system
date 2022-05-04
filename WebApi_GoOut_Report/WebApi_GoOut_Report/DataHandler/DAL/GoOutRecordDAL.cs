using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi_GoOut_Report.Models;

namespace WebApi_GoOut_Report.DataHandler.DAL
{
    //外出申请记录
    public class GoOutRecordDAL
    {
        //外出状态
        public enum StatusR :int
        { 
              申请中=0,
              已审批=1,
              已回校=2,
              已确认=3
        }
        //获取所有外出记录 
        public List<OutRecord> outRecords()
        {
            string sql = "select * from UserStu_tb join  StuOutschool_tb on UserStu_tb.UID=StuOutschool_tb.UID join Teacher_tb on StuOutschool_tb.TID = Teacher_tb.TID join dept_tb on UserStu_tb.ClassID=dept_tb.DID  order by StuOutschool_tb.CommitTime desc";
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            List<OutRecord> records = new List<OutRecord>();
            while (reader.Read())
            {
                OutRecord outRecord = new OutRecord();
                outRecord.SOID = (int)reader["SOID"];
                outRecord.StartTime = (DateTime)reader["StartTime"];
                outRecord.EndTime = (DateTime)reader["EndTime"];
                outRecord.CommitTime = (DateTime)reader["CommitTime"];
                outRecord.Reason = reader["REASON"].ToString();
                outRecord.ReplyText = reader["ReplyText"].ToString();
                StuUser user = new StuUser();
                user.UID = (int)reader["UID"];
                user.Username = reader["Username"].ToString();
                Dept dept = new Dept();
                dept.DID = (int)reader["DID"];
                dept.DeptName = reader["DeptName"].ToString();
                dept.ClassType = reader["ClassType"].ToString();
                dept.ClassName = reader["ClassName"].ToString();
                user.ClassID = dept;
                outRecord.UID = user;
                Teacher t = new Teacher();
                t.TID = (int)reader["TID"];
                t.TeacherName = reader["TeacherName"].ToString();
                outRecord.Status = ((StatusR)(int.Parse(reader["Status"].ToString()))).ToString();
                outRecord.TID = t;
                records.Add(outRecord);
            }
            return records;
        }
        //获取所有外出记录 （老师的权限：只能查看所负责班级学生的记录）
        public List<OutRecord> outRecords(int TID) {
            string sql = "select * from UserStu_tb join  StuOutschool_tb on UserStu_tb.UID=StuOutschool_tb.UID join Teacher_tb on StuOutschool_tb.TID = Teacher_tb.TID join dept_tb on UserStu_tb.ClassID=dept_tb.DID   where StuOutschool_tb.TID = " + TID+ " order by StuOutschool_tb.CommitTime desc";
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            List<OutRecord> records = new List<OutRecord>();
            while (reader.Read()) {
                OutRecord outRecord = new OutRecord();
                outRecord.SOID = (int)reader["SOID"];
                outRecord.StartTime = (DateTime)reader["StartTime"];
                outRecord.EndTime = (DateTime)reader["EndTime"];
                outRecord.CommitTime = (DateTime)reader["CommitTime"];
                outRecord.Reason = reader["REASON"].ToString();
                outRecord.ReplyText = reader["ReplyText"].ToString();
                StuUser user = new StuUser();
                user.UID = (int)reader["UID"];
                user.Username = reader["Username"].ToString();
                Dept dept = new Dept();
                dept.DID = (int)reader["DID"];
                dept.DeptName = reader["DeptName"].ToString();
                dept.ClassType = reader["ClassType"].ToString();
                dept.ClassName = reader["ClassName"].ToString();
                user.ClassID = dept;
                outRecord.UID = user;
                Teacher t = new Teacher();
                t.TID = (int)reader["TID"];
                t.TeacherName = reader["TeacherName"].ToString();
                outRecord.Status = ((StatusR)(int.Parse(reader["Status"].ToString()))).ToString();
                outRecord.TID = t;
                records.Add(outRecord);
            }
            return records;
        }

        public List<OutRecord> outRecords(DateTime start,DateTime end)
        {
            string sql = "select * from UserStu_tb join  StuOutschool_tb on UserStu_tb.UID=StuOutschool_tb.UID join Teacher_tb on StuOutschool_tb.TID = Teacher_tb.TID join dept_tb on UserStu_tb.ClassID=dept_tb.DID where StuOutschool_tb.Starttime>='" + start + "' and StuOutschool_tb.Endtime<='" + end + "'";
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            List<OutRecord> records = new List<OutRecord>();
            while (reader.Read())
            {
                OutRecord outRecord = new OutRecord();
                outRecord.SOID = (int)reader["SOID"];
                outRecord.StartTime = (DateTime)reader["StartTime"];
                outRecord.EndTime = (DateTime)reader["EndTime"];
                outRecord.CommitTime = (DateTime)reader["CommitTime"];
                outRecord.Reason = reader["REASON"].ToString();
                outRecord.ReplyText = reader["ReplyText"].ToString();
                StuUser user = new StuUser();
                user.UID = (int)reader["UID"];
                user.Username = reader["Username"].ToString();
                Dept dept = new Dept();
                dept.DID = (int)reader["DID"];
                dept.DeptName = reader["DeptName"].ToString();
                dept.ClassType = reader["ClassType"].ToString();
                dept.ClassName = reader["ClassName"].ToString();
                user.ClassID = dept;
                outRecord.UID = user;
                Teacher t = new Teacher();
                t.TID = (int)reader["TID"];
                t.TeacherName = reader["TeacherName"].ToString();
                outRecord.Status = ((StatusR)(int.Parse(reader["Status"].ToString()))).ToString();
                outRecord.TID = t;
                records.Add(outRecord);
            }
            return records;
        }

        public List<OutRecord> outRecordsBytime(int TID,DateTime start,DateTime end)
        {
            string sql = "select * from UserStu_tb join  StuOutschool_tb on UserStu_tb.UID=StuOutschool_tb.UID join Teacher_tb on StuOutschool_tb.TID = Teacher_tb.TID join dept_tb on UserStu_tb.ClassID=dept_tb.DID   where StuOutschool_tb.TID = " + TID + " and StuOutschool_tb.Starttime>='"+start+ "' and StuOutschool_tb.Endtime<='"+end+"' order by StuOutschool_tb.CommitTime desc";
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            List<OutRecord> records = new List<OutRecord>();
            while (reader.Read())
            {
                OutRecord outRecord = new OutRecord();
                outRecord.SOID = (int)reader["SOID"];
                outRecord.StartTime = (DateTime)reader["StartTime"];
                outRecord.EndTime = (DateTime)reader["EndTime"];
                outRecord.CommitTime = (DateTime)reader["CommitTime"];
                outRecord.Reason = reader["REASON"].ToString();
                outRecord.ReplyText = reader["ReplyText"].ToString();
                StuUser user = new StuUser();
                user.UID = (int)reader["UID"];
                user.Username = reader["Username"].ToString();
                Dept dept = new Dept();
                dept.DID = (int)reader["DID"];
                dept.DeptName = reader["DeptName"].ToString();
                dept.ClassType = reader["ClassType"].ToString();
                dept.ClassName = reader["ClassName"].ToString();
                user.ClassID = dept;
                outRecord.UID = user;
                Teacher t = new Teacher();
                t.TID = (int)reader["TID"];
                t.TeacherName = reader["TeacherName"].ToString();
                outRecord.Status = ((StatusR)(int.Parse(reader["Status"].ToString()))).ToString();
                outRecord.TID = t;
                records.Add(outRecord);
            }
            return records;
        }
        //查询个人外出记录
        public List<OutRecord> getSelfRecord(int UID)
        {
            string sql = "select * from UserStu_tb join  StuOutschool_tb on UserStu_tb.UID=StuOutschool_tb.UID join Teacher_tb on StuOutschool_tb.TID = Teacher_tb.TID join dept_tb on UserStu_tb.ClassID=dept_tb.DID   where  StuOutschool_tb.UID=" + UID;
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            List<OutRecord> records = new List<OutRecord>();
            while (reader.Read())
            {
                OutRecord outRecord = new OutRecord();
                outRecord.SOID = (int)reader["SOID"];
                outRecord.StartTime = (DateTime)reader["StartTime"];
                outRecord.EndTime = (DateTime)reader["EndTime"];
                outRecord.CommitTime = (DateTime)reader["CommitTime"];
                outRecord.Reason = reader["REASON"].ToString();
                outRecord.ReplyText = reader["ReplyText"].ToString();
                StuUser user = new StuUser();
                user.UID = (int)reader["UID"];
                user.Username = reader["Username"].ToString();
                Dept dept = new Dept();
                dept.DID = (int)reader["DID"];
                dept.DeptName = reader["DeptName"].ToString();
                dept.ClassType = reader["ClassType"].ToString();
                dept.ClassName = reader["ClassName"].ToString();
                user.ClassID = dept;
                outRecord.UID = user;
                Teacher t = new Teacher();
                t.TID = (int)reader["TID"];
                t.TeacherName = reader["TeacherName"].ToString();
                outRecord.TID = t;
                outRecord.Status = ((StatusR)(int.Parse(reader["Status"].ToString()))).ToString();
                records.Add(outRecord);
            }
            return records;
        }
        //外出记录按时间查询
        public List<OutRecord> getSelfRecordBytime(int UID,DateTime starttime,DateTime endTime)
        {
            string sql = "select * from UserStu_tb join  StuOutschool_tb on UserStu_tb.UID=StuOutschool_tb.UID join Teacher_tb on StuOutschool_tb.TID = Teacher_tb.TID join dept_tb on UserStu_tb.ClassID=dept_tb.DID   where  StuOutschool_tb.UID=" + UID+ " and StuOutschool_tb.StartTime>='"+starttime+ "' and StuOutschool_tb.endTime<='"+endTime+"'";
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            List<OutRecord> records = new List<OutRecord>();
            while (reader.Read())
            {
                OutRecord outRecord = new OutRecord();
                outRecord.SOID = (int)reader["SOID"];
                outRecord.StartTime = (DateTime)reader["StartTime"];
                outRecord.EndTime = (DateTime)reader["EndTime"];
                outRecord.CommitTime = (DateTime)reader["CommitTime"];
                outRecord.Reason = reader["REASON"].ToString();
                outRecord.ReplyText = reader["ReplyText"].ToString();
                StuUser user = new StuUser();
                user.UID = (int)reader["UID"];
                user.Username = reader["Username"].ToString();
                Dept dept = new Dept();
                dept.DID = (int)reader["DID"];
                dept.DeptName = reader["DeptName"].ToString();
                dept.ClassType = reader["ClassType"].ToString();
                dept.ClassName = reader["ClassName"].ToString();
                user.ClassID = dept;
                outRecord.UID = user;
                Teacher t = new Teacher();
                t.TID = (int)reader["TID"];
                t.TeacherName = reader["TeacherName"].ToString();
                outRecord.TID = t;
                outRecord.Status = ((StatusR)(int.Parse(reader["Status"].ToString()))).ToString();
                records.Add(outRecord);
            }
            return records;
        }
     
        //更新外出记录 改变外出状态
        public bool UpdateRecordsStatus(int status, int SOID)
        {
            if (status != 3 || status < 3)
            {
                status++;
            }
            String sql = String.Format("Update StuOutSchool_tb set status='{0}' where SOID='{1}'", status, SOID);
            bool result = new DBhelper().ExecuteNonQuery(sql);
            return result;
        }
        //获取外出记录条数
        public bool UpdateRecordsCount()
        {
            String sql = String.Format("select count(*) from StuOutSchool_tb");
            bool result = new DBhelper().ExecuteNonQuery(sql);
            return result;
        }

        //插入记录
        public bool InsertRecord(OutRecord record)
        {
            String sql = String.Format("insert into StuOutschool_tb([UID],TID,STARTTIME,ENDTIME,REASON,COMMITTIME,[STATUS],UNAME,TNAME) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')",record.UID.UID,record.TID.TID,record.StartTime,record.EndTime,record.Reason,System.DateTime.Now,(int)StatusR.申请中,record.UID.Username,record.TID.TeacherName);
            bool result = new DBhelper().ExecuteNonQuery(sql);
            return result;
        }

        public List<StuOutCount> GetOutCounts(int TID) {
            string sql = "select ClassName,Count(*) as C  from dbo.UserStu_tb JOIN dbo.StuOutschool_tb ON UserStu_tb.UID=StuOutschool_tb.UID join dbo.Dept_tb on Dept_tb.DID = UserStu_tb.ClassID where StuOutschool_tb.TID ='" + TID + "' group by DID,ClassName ";
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            List<StuOutCount> records = new List<StuOutCount>();
            while (reader.Read())
            {
                StuOutCount count = new StuOutCount();
                count.ClassName = reader["classname"].ToString();
                count.OutCount = int.Parse(reader["C"].ToString());
                records.Add(count);
            }
            return records;
         }
        public List<StuOutCount> GetOutCounts()
        {
            string sql = "select ClassName,Count(*) as C  from dbo.UserStu_tb JOIN dbo.StuOutschool_tb ON UserStu_tb.UID=StuOutschool_tb.UID join dbo.Dept_tb on Dept_tb.DID = UserStu_tb.ClassID  group by DID,ClassName ";
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            List<StuOutCount> records = new List<StuOutCount>();
            while (reader.Read())
            {
                StuOutCount count = new StuOutCount();
                count.ClassName = reader["classname"].ToString();
                count.OutCount = int.Parse(reader["C"].ToString());
                records.Add(count);
            }
            return records;
        }
    }
}