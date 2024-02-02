using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Test.Manager
{
    public class APIManager
    {
        public string EmployeeToken { get; set; }

        public APIManager() { }

        public APIManager(string EmployeeToken)
        {
            this.EmployeeToken = EmployeeToken;
        }

        public JObject RequestAPI(string URL)
        {
            string responseFromServer = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "GET";
                request.Timeout = 30 * 1000;
                request.ContentType = "application/json";
                request.Headers.Add("Authorization", $"Bearer {EmployeeToken}");

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
            catch (WebException ex)
            {
                //Console.WriteLine("오류-----------------------------");
                //Console.WriteLine(ex);
                //Console.WriteLine("-----------------------------------");
                //string response = string.Empty;
                //int statusCode = 0;
                //if (ex.Status == WebExceptionStatus.ProtocolError)
                //{
                //    statusCode = (int)((HttpWebResponse)ex.Response).StatusCode;
                //}
                //using (StreamReader r = new StreamReader(((HttpWebResponse)ex.Response).GetResponseStream()))
                //{
                //    response = r.ReadToEnd();
                //}
                //Console.WriteLine("StatusCode : " + statusCode);
                //Console.WriteLine("response : " + response);



                Console.WriteLine("---------------------------------------------");
                Console.WriteLine(ex);
                Console.WriteLine("---------------------------------------------");

                int statusCode = 0;
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    statusCode = (int)((HttpWebResponse)ex.Response).StatusCode;
                }
                switch (statusCode)
                {
                    case 400:
                        break;
                    case 401:
                        break;
                    case 404:
                        break;
                    case 500:
                        break;
                }
            }

            JObject jObject = JObject.Parse(responseFromServer);

            return jObject;
        }

        public JObject getEmployee(string factoryId)
        {
            string targetURL = $"http://test.smartqapis.com:5000/api/Employee?factoryId={factoryId}";

            return RequestAPI(targetURL);
        }

        public JObject getDepartment(string factoryId)
        {
            string targetURL = $"http://test.smartqapis.com:5000/api/Department?factoryId={factoryId}";

            return RequestAPI(targetURL);
        }
    }
}
