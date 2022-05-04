using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_GoOut_Report.DataHandler.DAL;
using WebApi_GoOut_Report.Models;

namespace WebApi_GoOut_Report.DataHandler.BLL
{
    public class UserBLL
    {
        UserDAL userDAL = new UserDAL();
        //学生 
        //学生登录
        public bool StuLogin(StuUser user)
        {
            return userDAL.StuLogin(user);
        }
        //学生注册

        //获取所有学生信息
        public List<StuUser> GetAllStuUser()
        {
            return userDAL.GetAllStuUser();
        }
        //获取单个学生信息
        public StuUser GetOneStuUser()
        {
            return userDAL.GetOneStuUser();
        }
        public StuUser GetStuUserInfo(int UID, int RID)
        {
            return userDAL.GetStuUserInfo(UID,RID);
        }
            //获取学生个数
        public int GetStuCount()
        {
            return userDAL.GetStuCount();
        }

        //修改学生信息
        public bool UpdateStu(StuUser stu)
        {
            return userDAL.UpdateStu(stu);
        }
        //修改学生密码
        public bool UpdateStuPwd(StuUser stu)
        {
            //MD5加密  （未做）
            return userDAL.UpdateStu(stu);
        }
        //删除学生信息
        public bool DelOneStu(int UID)
        {
            return userDAL.DelOneStu(UID);
        }

        //老师
        //老师登录
        public bool TeacherLogin(Teacher teacher)
        {
            return userDAL.TeacherLogin(teacher);
        }
        //获取所有老师信息
        public List<Teacher> GetTeachers()
        {
            return userDAL.GetTeachers();
        }
        //获取单个老师信息
        public Teacher GetOneTeachers(int TID,int RID)
        {
            return userDAL.GetOneTeachers(TID,RID);
        }
        //删除单个老师信息
        public bool DelOneTeacher(int TID)
        {
            return userDAL.DelOneTeacher(TID);
        }
        //编辑单个老师信息
        public bool UpdateOneTeacher(Teacher teacher)
        {
            return userDAL.UpdateOneTeacher(teacher);
        }
        //添加单个老师信息
        public bool InsertOneTeacher(Teacher teacher)
        {
            return userDAL.InsertOneTeacher(teacher);
        }
        //获取老师人数
        public int GetTeacherCount()
        {
            return userDAL.GetTeacherCount();
        }

        //角色
        //获取角色信息
        public List<Role> GetRole()
        {
            return userDAL.GetRole();
        }
        //修改角色信息
        public bool UpdateRole(Role role)
        {
            return userDAL.UpdateRole(role); 
        }
        //删除角色信息
        public bool DelRole(Role role)
        {
            return userDAL.DelRole(role);
        }
        //添加角色信息
        public bool AddRole(Role role)
        {
            return userDAL.AddRole(role);
        }
        //根据角色ID获取角色名
        public string GetRolename(int RID)
        {
            return userDAL.GetRolename(RID);
        }

        //获取系部信息
        public List<Dept> GetDept(Dept dept)
        {
            return userDAL.GetDept(dept);
        }

        //获取单个班级信息
        public Dept GetDept(int DID)
        {
            return userDAL.GetDept(DID);
        }
        //修改单个班级信息
        public bool UpdateDept(Dept dept)
        {
            return userDAL.UpdateDept(dept);
        }
        //删除班级信息
        public bool DelDept(Dept dept)
        {
            return userDAL.DelDept(dept);
        }
        public bool isExistAccount(OriginStu originStu)
        {
            return userDAL.isExistAccount(originStu);
        }
        public bool insertCode(OriginStu origin)
        {
            return userDAL.insertCode(origin);
        }
        public String getCode(OriginStu origin)
        {
            return userDAL.getCode(origin);
        }
        public String getClassID(OriginStu origin)
        {
            return userDAL.getClassID(origin);
        }
        public bool insertStu(StuUser stu)
        {
            return userDAL.insertStu(stu);
        }
        public String getUserID(StuUser stu)
        {
            return userDAL.getUserID(stu);
        }
        }
    }