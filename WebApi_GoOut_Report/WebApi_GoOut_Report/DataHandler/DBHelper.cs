using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApi_GoOut_Report.DataHandler
{
    public class DBhelper
    {
        private static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        private static SqlConnection SqlConnection = null;
        /// <summary>
        /// 初始化连接
        /// </summary>
        public DBhelper()
        {

            if (SqlConnection == null)
            {
                SqlConnection = new SqlConnection(connStr);
            }
            if (SqlConnection.State == ConnectionState.Closed)
            {
                SqlConnection.Open();
            }
        }

        public DataSet GetDataSet(string sql, params Parameter[] parameters)
        {
            try
            {
                DataSet ds = new DataSet();
                //SqlCommand command = new SqlCommand(sql,SqlConnection);
                //command.Parameters.AddRange(com);
                SqlDataAdapter adapter = null;
                adapter = new SqlDataAdapter(sql, SqlConnection);
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {

                throw new Exception("异常：" + ex.Message);
            }
            finally
            {
                SqlConnection.Close();
            }

        }

        public SqlDataReader GetSqlDataReader(string sql, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, SqlConnection);
            cmd.Parameters.AddRange(parameters);
            SqlDataReader reader = cmd.ExecuteReader();
            //SqlConnection.Close();
            return reader;
        }
        public bool ExecuteNonQuery(string sqlStr)
        {
            SqlCommand cmd = new SqlCommand(sqlStr, SqlConnection);    //new一个数据命令,传入sql语句,和连接对象
            int result = cmd.ExecuteNonQuery();    //int一个结果接收数据命令影响的行数
            SqlConnection.Close();    //关闭数据连接
            return result > 0;    //返回
        }
        public object GetScalar(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, SqlConnection);
            object result = cmd.ExecuteScalar();
            SqlConnection.Close();
            return result;
        }
    }
}