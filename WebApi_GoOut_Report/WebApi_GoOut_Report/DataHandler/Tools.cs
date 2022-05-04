using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApi_GoOut_Report.DataHandler
{
    public class Tools
    {
        static HttpClient client = new HttpClient();

        public static string GetHttpResponse(string url, int Timeout)
        {
            //todo：指定请求包的安全协议，因为不知道你当前项目到底是哪个版本所以为了安全保障都加上
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = null;
            request.Timeout = Timeout;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
        public static string CreateValidateChinese(int length)
        {
            /*gb2312中文编码表由区码和位码表示*/
            string randomCode = "";
            Random rand = new Random();
            Encoding encoding = Encoding.GetEncoding("gb2312");//从gb2312中文编码表提取汉字
            for (int i = 0; i < length; i++)
            {
                int regionCode = rand.Next(16, 56); // 获取区码(常用汉字的区码范围为16-55)    
                int locationCode = rand.Next(1, (regionCode == 55 ? 90 : 95));// 获取位码(位码范围为1-94 由于55区的90,91,92,93,94为空,故将其排除)

                randomCode += encoding.GetString(new byte[] { (byte)(regionCode + 160), (byte)(locationCode + 160) });//区码位码分别加上A0H（160）的方法转换为存储码
            }
            return randomCode;
        }
    }
}