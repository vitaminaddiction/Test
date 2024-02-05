using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Test.Manager
{
    public class TokenManager
    {
        public string CompanyToken { get; set; }
        public DateTime CompanyTokenDateTime { get; set; }
        public string EmployeeToken { get; set; }
        public DateTime EmployeeTokenDateTime { get; set; }


        public string GenerateCompanyToken(string companyName)
        {
            //https://vmpo.tistory.com/71
            //https://www.csharpstudy.com/web/article/16-HttpWebRequest-%ED%99%9C%EC%9A%A9
            string responseFromServer = string.Empty;
            string targetURL = "http://test.smartqapis.com:6000/api/Customers/authenticate";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targetURL);
                request.Method = "POST";
                request.Timeout = 30 * 1000;
                request.ContentType = "application/json";

                using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = $"{{\"Brn\":\"{companyName}\"}}";
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        HttpStatusCode status = response.StatusCode;
                        Console.WriteLine(status);

                        Stream responseStream = response.GetResponseStream();
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            responseFromServer = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine(ex);
                Console.WriteLine("---------------------------------------------");

                int statusCode = 0;
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    statusCode = (int)((HttpWebResponse)ex.Response).StatusCode;
                    Console.WriteLine(statusCode);
                }
                switch (statusCode)
                {
                    case 400:
                        //companyName 다를때, 
                        MessageBox.Show("공장명이 올바르지 않습니다.");
                        break;
                    case 401:
                        MessageBox.Show("유효한 인증 자격이 없습니다.");
                        break;
                    case 404:
                        MessageBox.Show("URL호출이 올바르지 않습니다.");
                        break;
                    case 405:
                        //URL주소가 다를때
                        MessageBox.Show("허용되지 않은 요청(메서드)입니다.");
                        break;
                    case 500:
                        MessageBox.Show("필수 요청 변수가 없거나 요청 변수 이름이 잘못된 경우");
                        break;
                }
            }

            JObject jObject = new JObject();
            string result = string.Empty;
            try
            {
                jObject = JObject.Parse(responseFromServer);
                result = jObject["Data"]["Token"].ToString();
            }
            catch {
            }

            return result;
        }

        public string GenerateEmployeeToken(string ID, string password)
        {
            string responseFromServer = string.Empty;
            string targetURL = "http://test.smartqapis.com:5000/api/Login";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targetURL);
                request.Method = "POST";
                request.Timeout = 30 * 1000;
                request.ContentType = "application/json";
                request.Headers.Add("Authorization", $"Bearer {CompanyToken}");
                
                using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = $"{{\"loginId\":\"{ID}\",\"password\":\"{password}\"}}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        HttpStatusCode status = response.StatusCode;
                        Console.WriteLine(status);

                        Stream responseStream = response.GetResponseStream();
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            responseFromServer = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine(ex);
                Console.WriteLine("---------------------------------------------");

                int statusCode = 0;
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    statusCode = (int)((HttpWebResponse)ex.Response).StatusCode;
                    Console.WriteLine(statusCode);
                }
                switch (statusCode)
                {
                    case 400:
                        break;
                    case 401:
                        //companyToken이 다를때
                        MessageBox.Show("유효한 토큰이 아닙니다. 프로그램을 다시 실행 해주세요.");
                        break;
                    case 404:
                        //id, password 다를때//url다를때
                        MessageBox.Show("로그인 정보가 올바르지 않습니다.");
                        break;
                    case 500:
                        MessageBox.Show("필수 요청 변수가 없거나 요청 변수 이름이 잘못된 경우");
                        break;
                }
            }

            JObject jObject = new JObject();
            string result = string.Empty;
            try 
            { 
                jObject = JObject.Parse(responseFromServer);
                result = jObject["Data"].ToString();
            }
            catch {
            }

            return result;
        }

        public void SaveCompanyToken(string companyName)
        {
            CompanyToken = GenerateCompanyToken(companyName);
            if(!(string.IsNullOrEmpty(CompanyToken))) { CompanyTokenDateTime = DateTime.Now; }
        }

        public void SaveEmployeeToken(string ID, string password)
        {
            EmployeeToken = GenerateEmployeeToken(ID, password);
            if(!(string.IsNullOrEmpty(EmployeeToken))) { EmployeeTokenDateTime = DateTime.Now; }
        }

        public bool ValidationCompanyToken()
        {
            TimeSpan timeSpan = DateTime.Now - CompanyTokenDateTime;
            if (timeSpan.TotalHours >= 12) { return false; }
            else { return true; }
        }

        public bool ValidationEmployeeToken()
        {
            TimeSpan timeSpan = DateTime.Now - EmployeeTokenDateTime;
            if (timeSpan.TotalHours >= 12) { return false; }
            else { return true; }
        }
    }
}
