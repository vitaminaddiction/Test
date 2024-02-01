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

        public APIManager(string EmployeeToken)
        {
            this.EmployeeToken = EmployeeToken;
        }


        public JObject getEmployee(string factoryId)
        {
            string responseFromServer = string.Empty;
            string targetURL = $"http://test.smartqapis.com:5000/api/Employee?factoryId={factoryId}";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targetURL);
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
            catch (Exception ex)
            {
                Console.WriteLine("오류---------------------------------------------");
                Console.WriteLine(ex);
            }

            JObject jObject = JObject.Parse(responseFromServer);

            Console.WriteLine(jObject);
            return jObject;
        }
    }
}
