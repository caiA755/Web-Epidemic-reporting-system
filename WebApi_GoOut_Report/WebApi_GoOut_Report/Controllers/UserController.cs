using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi_GoOut_Report.DataHandler;
using WebApi_GoOut_Report.DataHandler.BLL;
using WebApi_GoOut_Report.Models;

namespace WebApi_GoOut_Report.Controllers
{
    
    public class UserController : ApiController
    {
        private static string[] ValidateCharArray = new string[] { "2", "3", "4", "5", "6", "8", "9" };
        UserBLL userBLL = new UserBLL();
        // GET api/<controller>
        [HttpPost]
        public IHttpActionResult UserList()
        {
            return Json<List<StuUser>>(userBLL.GetAllStuUser());
        }

        [HttpPost]
        //WebAPI的post 
        public IHttpActionResult UserLogin([FromBody] UserTest u)
        {
            StuUser user = new StuUser();
            user.UID = u.UID;
            user.Password = u.Password;
            Role r = new Role();
            r.RID = u.RID;
            user.RID = r;
            return Json<Boolean>(userBLL.StuLogin(user));
        }
     

         [HttpPost]
        //WebAPI的post 
        public IHttpActionResult TeacherLogin([FromBody] UserTest t)
        {
            Teacher teacher = new Teacher();
            teacher.TID = t.UID;
            teacher.Password = t.Password;
            Role r = new Role();
            r.RID = t.RID;
            teacher.RID = r;
            return Json<Boolean>(userBLL.TeacherLogin(teacher));
        }

        [HttpPost]
        public IHttpActionResult GetOneTeachers([FromBody] UserTest t)
        {
            return Json<Teacher>(userBLL.GetOneTeachers(int.Parse(t.UID.ToString()), int.Parse(t.RID.ToString())));
        }

        [HttpPost]
        public IHttpActionResult GetTeachers()
        {
            return Json<List<Teacher>>(userBLL.GetTeachers());
        }
        [HttpPost]
        //WebAPI的post 
        public IHttpActionResult RoleType()
        {
            return Json<List<Role>>(userBLL.GetRole());
        }

        [HttpPost]
        //WebAPI的post 
        public IHttpActionResult GetUserInfo(UserTest user)
        {

            return Json<StuUser>(userBLL.GetStuUserInfo(int.Parse(user.UID.ToString()), int.Parse(user.RID.ToString())));
        }

        [HttpPost]
        public IHttpActionResult isExistAccount(OriginStu stu)
        {

            return Json<Boolean>(userBLL.isExistAccount(stu));
        }
        [HttpGet] 
        public IHttpActionResult SendEmail(string Useremail,string SNO)
        {
            string username = "2513050851@qq.com";
            string pwd = "qgghgpwguniieaii";
            string youremail= Useremail;
            string title = "您的验证码：";
            var flag = false;
            string result = "";
            System.Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                result += random.Next(10).ToString();
            }

            string url = "https://api.dzzui.com/api/mail?Host=smtp.qq.com&Username="+username+"&Password="+pwd+"&Port=465&SMTPSecure=ssl&addAddress="+youremail+"&title="+title+"&text="+ result;
            string res =Tools.GetHttpResponse(url, 6000);
            if (res == "邮件发送成功")
            {
                OriginStu stu = new OriginStu();
                stu.Email = Useremail;
                stu.SNO = SNO;
                stu.Vcode = result;
                //将验证码插入数据库 
                bool re = userBLL.insertCode(stu);
                flag = true;
            }
            return Json<Boolean>(flag);
        }


        [HttpPost]
        public IHttpActionResult insertCode(OriginStu stu)
        {

            return Json<Boolean>(userBLL.insertCode(stu));
        }

        [HttpPost]
        public IHttpActionResult isRightCode(OriginStu stu)
        {
            string Rcode = userBLL.getCode(stu);
            string Inputcode = stu.Vcode;
            bool flag = false;
            if (Inputcode != Rcode)
            {
                flag = false;
            }
            else {
                flag = true;
            }

            return Json<Boolean>(flag);
        }

        [HttpPost]
        public IHttpActionResult insertStu(StuUser stu)
        {
            OriginStu Ostu = new OriginStu();
            Ostu.SNO = stu.SNO;

            //获取classID
             Dept dept = new Dept();
             dept.DID= int.Parse(userBLL.getClassID(Ostu));
            stu.ClassID = dept;
            //插入数据
            bool result=userBLL.insertStu(stu);
            if (result == false) {
                return Json<Boolean>(result);
            }
            //获取ID
            string uid = userBLL.getUserID(stu);
            return Json<string>(uid);
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