using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAPI
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            //EventRegister();
        }


        public void EventRegister()
        {
            btn_login.Click += Btn_login_Click;
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            //public enum Fruit { };


            //string responseFromServer = string.Empty;
            //string targetURL = "http://test.smartqapis.com:6000/api/Customers/authenticate";
            //try
            //{
            //    //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targetURL);
            //    //request.Method = "POST";
            //    //request.Timeout = 30 * 1000;
            //    ////request.Headers.Add("Authorization", "BASIC SGVsbG8=");
            //    //request.ContentType = "application/json";
            //    ////request.Headers["user-agent"] = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";

            //    //using(StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            //    //{
            //    //    string json = "{\"Brn\":\"debug\"}";
            //    //    streamWriter.Write(json);
            //    //    streamWriter.Flush();
            //    //    streamWriter.Close();

            //    //    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //    //    {
            //    //        HttpStatusCode status = response.StatusCode;
            //    //        Console.WriteLine(status);

            //    //        Stream responseStream = response.GetResponseStream();
            //    //        using (StreamReader reader = new StreamReader(responseStream))
            //    //        {
            //    //            responseFromServer = reader.ReadToEnd();
            //    //        }

            //    //    }
            //    //}






            //    //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //    //{
            //    //    HttpStatusCode status = response.StatusCode;
            //    //    Console.WriteLine(status);

            //    //    Stream responseStream = response.GetResponseStream();
            //    //    using (StreamReader reader = new StreamReader(responseStream))
            //    //    {
            //    //        responseFromServer = reader.ReadToEnd();
            //    //    }

            //    //}

            //    //using (WebResponse response = request.GetResponse())
            //    //using (Stream dataStream = response.GetResponseStream())
            //    //using (StreamReader reader = new StreamReader(dataStream))
            //    //{
            //    //    responseFromServer = reader.ReadToEnd();
            //    //}
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine("오류---------------------------------- ");
            //    Console.WriteLine(ex);
            //}

            //Console.WriteLine(responseFromServer);
        }
        enum Gender
        {
            Male, Female
        }
        private void btn_login_Click_1(object sender, EventArgs e)
        {
            TEst test = new TEst();
            Gender gender = Gender.Male;
            Console.WriteLine(gender);
            
        }
    }
}
