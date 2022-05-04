前提：附加数据库（SQL SERVER） ，打卡MSSQLSERVER服务
运行：
方法一：
1. 使用vs2019打开项目直接运行
2. 再运行Web里面的index.html界面
方法二：
1. 使用vs2019打开项目并且发布到文件夹
2. 通过IIS进行部署
3. 修改Web中所有script里面的请求的ip地址

如果数据库不是window身份验证，是sql server身份验证，需要修改WebApi_GoOut_Report_Publish下的web.config中的connectionStrings
  <connectionStrings>
    <add connectionString="Data Source=.;Initial Catalog=StudentDB;Integrated Security=True;MultipleActiveResultSets=true;" name="connStr" />
  </connectionStrings>
改为
< connectionStrings>
   <add  name="connStr" connectionString="server=服务器名;database=数据库名;uid=用户名;password=密码"providerName="System.Data.SqlClient"/>
   </ connectionStrings>

数据库已有账号
管理员ID：10002  Password:12345
辅导员ID：10001  Password:12324
学生ID: 251003     Password:12345
