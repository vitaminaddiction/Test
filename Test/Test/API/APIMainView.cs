using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Manager;

namespace Test.API
{
    public partial class APIMainView : Form
    {
        TokenManager tokenManager;


        public APIMainView()
        {
            InitializeComponent();
            EventRegister();
        }
        public APIMainView(TokenManager tokenManager) : this()
        {
            this.tokenManager = tokenManager;
        }

        private void EventRegister()
        {
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            APIManager aPIManager = new APIManager(tokenManager.EmployeeToken);
            JObject jObject = aPIManager.getEmployee("1");
        }
    }
}
