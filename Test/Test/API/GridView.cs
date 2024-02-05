using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.APIDTO;
using Test.DB;
using Test.Manager;
using Test.Util;

namespace Test.API
{
    public partial class GridView : Form
    {
        MoveForm moveForm = new MoveForm();
        int GapX, GapY;

        public GridView()
        {
            InitializeComponent();
            EventRegister();
            App.Instance().APIManager.EmployeeToken = App.Instance().TokenManager.EmployeeToken;
        }

        private void EventRegister()
        {
            btn_search.Click += Btn_search_Click;
            btn_close.Click += Btn_close_Click;
            btn_Department.Click += Btn_Department_Click;
            panel1.MouseDown += MainView_MouseDown;
            panel1.MouseMove += MainView_MouseMove;
            panel1.MouseUp += MainView_MouseUp;
        }


        private void Btn_Department_Click(object sender, EventArgs e)
        {
            APIManager aPIManager = App.Instance().APIManager;

            JObject jObject = aPIManager.getDepartment("1");

            List<Department> list = new List<Department>();
            if(!(jObject is null)) { list = jObject["Data"].ToObject<List<Department>>(); }
            
            dGridView.DataSource = list;
        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/4441466/how-to-deserialize-a-jobject-to-net-object
            //https://www.csharpstudy.com/Data/Json-jsonnet.aspx
            //https://www.newtonsoft.com/json/help/html/ToObjectComplex.htm
            //https://stackoverflow.com/questions/25284744/deserialize-a-jobject-to-a-list-of-net-objects
            //GPT
            APIManager aPIManager = App.Instance().APIManager;
            JObject jObject = aPIManager.getEmployee("1");

            List<Employee> list = new List<Employee>();

            if (!(jObject is null)) 
            {
                foreach (var item in jObject["Data"])
                {
                    Employee employee = item.ToObject<Employee>();
                    employee.Permission = item["Permissions"].ToObject<List<Permission>>();

                    list.Add(employee);
                }
            }
            

            dGridView.DataSource = list;
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #region 마우스 이동 //https://424485.tistory.com/57
        private void MainView_MouseDown(object sender, MouseEventArgs e)
        {
            GapX = Cursor.Position.X - this.Location.X;
            GapY = Cursor.Position.Y - this.Location.Y;

            moveForm.Size = new Size(this.Width, this.Height);

            moveForm.Location = new Point(Cursor.Position.X - GapX, Cursor.Position.Y - GapY);

            moveForm.Show();
        }
        private void MainView_MouseUp(object sender, MouseEventArgs e)
        {
            this.Location = new Point(moveForm.Location.X, moveForm.Location.Y);

            moveForm.Hide();
        }
        private void MainView_MouseMove(object sender, MouseEventArgs e)
        {
            moveForm.Location = new Point(Cursor.Position.X - GapX, Cursor.Position.Y - GapY);
        }
        #endregion
    }
}
