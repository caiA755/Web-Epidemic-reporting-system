using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi_GoOut_Report.Models;

namespace WebApi_GoOut_Report.DataHandler.DAL
{
    public class UserDAL
    {
        //学生 
        //学生登录
        public bool StuLogin(StuUser user) {
            String sql = String.Format("select count(*) from UserStu_tb where UID='{0}' and Password='{1}' and RID='{2}'", user.UID, user.Password,user.RID.RID);
            int result =(int) new DBhelper().GetScalar(sql);
            return result>0;
        }
        //学生注册

        //获取所有学生信息
        public List<StuUser> GetAllStuUser()
        {
            string sql = string.Format("select * from UserStu_tb,Role_tb,Dept_tb,Teacher_tb where UserStu_tb.RID=Role_tb.RID and UserStu_tb.ClassID=Dept_tb.DID and Dept_tb.TID = Teacher_tb.TID");
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            List<StuUser> stuUsers = new List<StuUser>();
            while (reader.Read())
            {
                StuUser st = new StuUser();
                st.UID = (int)reader["UID"];
                st.Username = reader["USERNAME"].ToString();
                st.Password = reader["PASSWORD"].ToString();
                st.Sex = reader["SEX"].ToString();
                st.RegisterTime = (DateTime)reader["RegisterTime"];
                st.Phone = reader["Phone"].ToString();
                st.LastLoginTime = (DateTime)reader["LastLoginTime"];
                Role r = new Role();
                r.RID = (int)reader["RID"];
                r.RoleName = reader["RoleName"].ToString();
                st.RID = r;
                Dept dept = new Dept();
                dept.DID =(int)reader["DID"];
                dept.ClassName = reader["ClassName"].ToString();
                dept.DeptName = reader["DeptName"].ToString();
                dept.ClassType = reader["ClassType"].ToString();
                Teacher teacher = new Teacher();
                teacher.TID = (int)reader["TID"];
                teacher.TeacherName = reader["TeacherName"].ToString();
                dept.TID = teacher;
                st.ClassID = dept;
                stuUsers.Add(st);
            }
            reader.Close();
            return stuUsers;
        }
        //获取单个学生信息
        public StuUser GetOneStuUser()
        {
            string sql = string.Format("select * from UserStu_tb,Role_tb where UserStu_tb.RID=Role_tb.RID");
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            StuUser st = new StuUser();
            while (reader.Read())
            {
                st.UID = (int)reader["UID"];
                st.Username = reader["USERNAME"].ToString();
                st.Password = reader["PASSWORD"].ToString();
                st.Sex = reader["SEX"].ToString();
                st.RegisterTime = (DateTime)reader["RegisterTime"];
                st.Phone = reader["Phone"].ToString();
                st.LastLoginTime = (DateTime)reader["LastLoginTime"];
                Role r = new Role();
                r.RID = (int)reader["RID"];
                r.RoleName = reader["RoleName"].ToString();
                st.RID = r;
            }
            reader.Close();
            return st;
        }

        //获取学生信息
        public StuUser GetStuUserInfo(int UID,int RID)
        {
            string sql = string.Format("select * from UserStu_tb,Role_tb,Dept_tb,Teacher_tb where UserStu_tb.RID=Role_tb.RID and UserStu_tb.ClassID=Dept_tb.DID and Dept_tb.TID = Teacher_tb.TID AND [UID]='{0}' and UserStu_tb.RID='{1}'", UID,RID);
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            StuUser st = new StuUser();
            while (reader.Read())
            {
                st.UID = (int)reader["UID"];
                st.Username = reader["USERNAME"].ToString();
                st.Password = reader["PASSWORD"].ToString();
                st.Sex = reader["SEX"].ToString();
                st.RegisterTime = (DateTime)reader["RegisterTime"];
                st.Phone = reader["Phone"].ToString();
                st.LastLoginTime = (DateTime)reader["LastLoginTime"];
                Role r = new Role();
                r.RID = (int)reader["RID"];
                r.RoleName = reader["RoleName"].ToString();
                st.RID = r;
                Dept dept = new Dept();
                dept.DID = (int)reader["DID"];
                dept.ClassName = reader["ClassName"].ToString();
                dept.DeptName = reader["DeptName"].ToString();
                dept.ClassType = reader["ClassType"].ToString();
                Teacher teacher = new Teacher();
                teacher.TID = (int)reader["TID"];
                teacher.TeacherName = reader["TeacherName"].ToString();
                dept.TID = teacher;
                st.ClassID = dept;
            }
            reader.Close();
            return st;
        }
        //获取学生个数
        public int GetStuCount()
        {
            string sql = "select count(*) from UserStu_tb";
            int result = (int)new DBhelper().GetScalar(sql);
            return result;
        }

        //修改学生信息
        public bool UpdateStu(StuUser stu)
        {
            String sql = String.Format("Update UserStu_tb set USERNAME='{0},ClassID='{1}',Sex='{2}' where UID='{3}'", stu.Username, stu.ClassID,stu.Sex,stu.UID);
            bool result = new DBhelper().ExecuteNonQuery(sql);
            return result;
        }
        //修改学生密码
        public bool UpdateStuPwd(StuUser stu)
        {
            String sql = String.Format("Update UserStu_tb set Password='{0}' where UID='{1}'", stu.Password, stu.UID);
            bool result = new DBhelper().ExecuteNonQuery(sql);
            return result;
        }
        //删除学生信息
        public bool DelOneStu(int UID)
        {
            String sql = String.Format("delete from UserStu_tb  where UID='{0}'", UID);
            bool result = new DBhelper().ExecuteNonQuery(sql);
            return result;
        }

        //老师
        //老师登录
        public bool TeacherLogin(Teacher teacher)
        {
            String sql = String.Format("select count(*) from Teacher_tb where TID='{0}' and Password='{1}' and RID='{2}'", teacher.TID, teacher.Password, teacher.RID.RID);
            int result = (int)new DBhelper().GetScalar(sql);
            return result > 0;
        }
        //获取所有老师信息
        public List<Teacher> GetTeachers() {
            string sql = string.Format("select *,Teacher_tb.RID as R from Teacher_tb,Role_tb where Teacher_tb.RID=Role_tb.RID ");
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            List<Teacher> teachers = new List<Teacher>();
            while (reader.Read())
            {
                Teacher t = new Teacher();
                t.TID = (int)reader["TID"];
                t.TeacherName = reader["TeacherName"].ToString();
                t.Sex = reader["Sex"].ToString();
                t.Password = reader["Password"].ToString();
                t.LastLoginTime = (DateTime)reader["RegisterTime"];
                Role r = new Role();
                r.RID =int.Parse(reader["R"].ToString());
                r.RoleName = reader["RoleName"].ToString();
                t.RID = r;
                teachers.Add(t);
            }
            reader.Close();
            return teachers;
        }
        //获取单个老师信息
        public Teacher GetOneTeachers(int TID ,int RID)
        {
            string sql = string.Format("select * from Teacher_tb,Role_tb where Teacher_tb.RID=Role_tb.RID and Teacher_tb.TID='{0}' and Teacher_tb.RID='{1}'", TID,RID);
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            Teacher t = new Teacher();
            while (reader.Read())
            {  
                t.TID = (int)reader["TID"];
                t.TeacherName = reader["TeacherName"].ToString();
                t.Sex = reader["Sex"].ToString();
                t.Password = reader["Password"].ToString();
                //t.LastLoginTime = (DateTime)reader["LastLoginTime"];
                Role r = new Role();
                r.RID = (int)reader["RID"];
                r.RoleName = reader["RoleName"].ToString();
                t.RID = r;
            }
            reader.Close();
            return t;
        }
        //删除单个老师信息
        public bool DelOneTeacher(int TID)
        {
            String sql = String.Format("delete from teacher_tb where TID='{0}'",TID);
            bool result = new DBhelper().ExecuteNonQuery(sql);
            return result;
        }
        //编辑单个老师信息
        public bool UpdateOneTeacher(Teacher teacher)
        {
            String sql = String.Format("update  teacher_tb set TeacherName='{0}',SEX='{1}',Password='{2}',RID='{3}' where TID='{4}'", teacher.TeacherName,teacher.Sex,teacher.Password,teacher.RID,teacher.TID);
            bool result = new DBhelper().ExecuteNonQuery(sql);
            return result;
        }
        //添加单个老师信息
        public bool InsertOneTeacher(Teacher teacher)
        {
            String sql = String.Format("insert into teacher_tb(TeacherName,SEX,PASSWORD,RID) VALUES('{0}','{1}','{2}','{3}')", teacher.TeacherName, teacher.Sex, teacher.Password, teacher.RID);
            bool result = new DBhelper().ExecuteNonQuery(sql);
            return result;
        }
        //获取老师人数
        public int GetTeacherCount() {
            string sql = "select count(*) from teacher_tb";
            int result = (int)new DBhelper().GetScalar(sql);
            return result;
        }

        //角色
        //获取角色信息
        public List<Role> GetRole()
         {
            string sql = string.Format("select * from Role_tb ");
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            List<Role> roles = new List<Role>();
            while (reader.Read())
            {
                Role r = new Role();
                r.RID = (int)reader["RID"];
                r.RoleName = reader["RoleName"].ToString();
                roles.Add(r);
            }
            reader.Close();
            return roles;
        }
        //修改角色信息
        public bool UpdateRole(Role role)
        {
            String sql = String.Format("Update Role_tb set rolename='{0}' where rid='{1}'", role.RoleName,role.RID);
            bool result = new DBhelper().ExecuteNonQuery(sql);
            return result;
        }
        //删除角色信息
        public bool DelRole(Role role)
        {
            String sql = String.Format("delete from  Role_tb  where rid='{0}'", role.RID);
            bool result = new DBhelper().ExecuteNonQuery(sql);
            return result;
        }
        //添加角色信息
        public bool AddRole(Role role)
        {
            String sql = String.Format("insert into role_tb(ROLENAME) values('{0}')", role.RoleName);
            bool result = new DBhelper().ExecuteNonQuery(sql);
            return result;
        }
        //根据角色ID获取角色名
        public string GetRolename(int RID) {
            string sql = "select ROLENAME from role_tb where RID=" + RID;
            SqlDataReader reader= new DBhelper().GetSqlDataReader(sql);
            String rolename = "";
            while (reader.Read()) {
                rolename = reader["rolename"].ToString();
            }
            return rolename;
        }

        //获取系部信息
        public List<Dept> GetDept(Dept dept)
        {
            string sql = string.Format("select * from Dept_tb,Teacher_tb where Dept_tb.TID=Teacher_tb.TID");
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            List<Dept> depts = new List<Dept>();
            while (reader.Read())
            {
                Dept d = new Dept();
                d.DID = (int)reader["DID"];
                d.DeptName = reader["DeptName"].ToString();
                d.ClassType = reader["ClassType"].ToString();
                d.ClassName = reader["ClassName"].ToString();
                Teacher t = new Teacher();
                t.TID = (int)reader["TID"];
                t.TeacherName = reader["TeacherName"].ToString();
                d.TID = t;
                depts.Add(d);
            }
            reader.Close();
            return depts;
        }

        //获取单个班级信息
        public Dept GetDept(int DID)
        {
            string sql = string.Format("select * from Dept_tb,Teacher_tb where Dept_tb.TID=Teacher_tb.TID where DID='{0}'",DID);
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            Dept d = new Dept();
            while (reader.Read())
            {
               
                d.DID = (int)reader["DID"];
                d.DeptName = reader["DeptName"].ToString();
                d.ClassType = reader["ClassType"].ToString();
                d.ClassName = reader["ClassName"].ToString();
                Teacher t = new Teacher();
                t.TID = (int)reader["TID"];
                t.TeacherName = reader["TeacherName"].ToString();
                d.TID = t;
            }
            reader.Close();
            return d;
        }
        //修改单个班级信息
        public bool UpdateDept(Dept dept)
        {
            String sql = String.Format("Update dept_tb set Deptname='{0},ClassName='{1}',ClassType='{2}',TID='{3}' where DID='{4}'", dept.DeptName, dept.ClassName,dept.ClassType,dept.TID.TID);
            bool result = new DBhelper().ExecuteNonQuery(sql);
            return result;
        }
        //删除班级信息
        public bool DelDept(Dept dept)
        {
            String sql = String.Format("delete from dept_tb where DID='{0}'", dept.DID);
            bool result = new DBhelper().ExecuteNonQuery(sql);
            return result;
        }

        public bool isExistAccount(OriginStu originStu) {
            string sql = "select count(*) from OriginStuInfo_tb where SNO='"+originStu.SNO+"' and Email='"+originStu.Email+"'";
            int result = (int)new DBhelper().GetScalar(sql);
            return result > 0;
        }

        public bool insertCode(OriginStu origin)
        {
            String sql = String.Format("update OriginStuInfo_tb set vcode='{0}' where SNO='{1}' and Email='{2}'", origin.Vcode
                ,origin.SNO,origin.Email);
            bool result = new DBhelper().ExecuteNonQuery(sql);
            return result;
        }

        public String getCode(OriginStu origin)
        {
            String sql = String.Format("select * from dbo.OriginStuInfo_tb where SNO='{0}' AND EMAIL='{1}'", origin.SNO
                , origin.Email);
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            String Vcode = "";
            while (reader.Read()) {
                Vcode = reader["Vcode"].ToString();
            }
            reader.Close();
            return Vcode;
        }

        //根据学号获取ClassID
        public String getClassID(OriginStu origin)
        {
            String sql = String.Format("select * from dbo.OriginStuInfo_tb where SNO='{0}'", origin.SNO);
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            String Vcode = "";
            while (reader.Read())
            {
                Vcode = reader["ClassID"].ToString();
            }
            reader.Close();
            return Vcode;
        }


        public bool insertStu(StuUser stu)
        {
            String sql = String.Format("insert into UserStu_tb(Username,Password,RID,RegisterTime,ClassID) values('{0}', '{1}', '{2}', '{3}', '{4}')", stu.Username
                , stu.Password, 1,System.DateTime.Now,stu.ClassID.DID);
            bool result = new DBhelper().ExecuteNonQuery(sql);
            return result;
        }
        //获取userid
        public String getUserID(StuUser stu)
        {
            String sql = String.Format("select UID from dbo.UserStu_tb where username='{0}' and password='{1}'", stu.Username,stu.Password);
            SqlDataReader reader = new DBhelper().GetSqlDataReader(sql);
            String UID = "";
            while (reader.Read())
            {
                UID = reader["UID"].ToString();
            }
            reader.Close();
            return UID;
        }
        //select * from dbo.OriginStuInfo_tb where SNO='' AND EMAIL=''
        //注意级联删除 老师 ，学生，外出申请记录


    }
}