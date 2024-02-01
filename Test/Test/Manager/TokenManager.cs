using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Test.Manager
{
    public class TokenManager
    {
        public const string TokenPath = "token.txt";

        public string CompanyToken { get; set; }
        public DateTime CompanyTokenDateTime { get; set; }
        public string EmployeeToken { get; set; }
        public DateTime EmployeeTokenDateTime { get; set; }


        public string GenerateCompanyToken(string companyName)
        {
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
            catch (Exception ex)
            {
                Console.WriteLine("오류-------------------------------------------------");
                Console.WriteLine(ex);
            }

            JObject jObject = JObject.Parse(responseFromServer);
            Console.WriteLine(jObject);

            return jObject["Data"]["Token"].ToString();
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
            catch (Exception ex)
            {
                Console.WriteLine("오류---------------------------------------------");
                Console.WriteLine(ex);
            }

            JObject jObject = JObject.Parse(responseFromServer);

            Console.WriteLine(responseFromServer);
            return jObject["Data"].ToString();
        }

        public void SaveCompanyToken(string companyName)
        {
            string token = GenerateCompanyToken(companyName);
            DateTime currentTime = DateTime.Now;

            string tokenData = $"{token},{currentTime}";
            File.WriteAllText(TokenPath, tokenData);
        }

        public void SaveEmployeeToken(string ID, string password)
        {
            string token = GenerateEmployeeToken(ID, password);
            DateTime currentTime = DateTime.Now;

            string tokenData = $"{CompanyToken},{CompanyTokenDateTime},{token},{currentTime}";
            File.WriteAllText(TokenPath, tokenData);
        }

        public bool ValidationCompanyToken()
        {
            string tokenData = "";
            try { tokenData = File.ReadAllText(TokenPath); }
            catch { return false; }

            string[] list = tokenData.Split(',');
            if(list.Length >= 2)
            {
                CompanyTokenDateTime = DateTime.Parse(list[1]);
                TimeSpan timeSpan = DateTime.Now - CompanyTokenDateTime;
                if(timeSpan.TotalHours >= 12)
                {
                    return false;
                }
                else
                {
                    CompanyToken = list[0];
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ValidationEmployeeToken()
        {
            string tokenData = "";
            try { tokenData = File.ReadAllText(TokenPath); }
            catch { return false; }
            
            string[] list = tokenData.Split(',');
            if(list.Length == 4)
            {
                EmployeeTokenDateTime = DateTime.Parse(list[3]);
                TimeSpan timeSpan = DateTime.Now - EmployeeTokenDateTime;
                if(timeSpan.TotalHours >= 12)
                {
                    return false;
                }
                else
                {
                    EmployeeToken = list[3];
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
