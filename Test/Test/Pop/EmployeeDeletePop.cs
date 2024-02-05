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
using Test.DB;
using Test.Util;

namespace Test.Pop
{
    public partial class EmployeeDeletePop : Form
    {
        public event EventHandler Reset;

        MoveForm moveForm = new MoveForm();
        int GapX, GapY;

        string deleteFileName = string.Empty;
        int employeeID = 0;
        public EmployeeDeletePop()
        {
            InitializeComponent();
            EventRegister();
        }

        private void EventRegister()
        {
            btn_delete.Click += btn_delete_Click;
            btn_close.Click += btn_close_Click;
            panel1.MouseDown += MainView_MouseDown;
            panel1.MouseUp += MainView_MouseUp;
            panel1.MouseMove += MainView_MouseMove;
        }

        public EmployeeDeletePop(DepEmp depEmp) : this()
        {
            label_code.Text = "사원 코드 : " + depEmp.EmpCode;
            label_name.Text = "사원명 : " + depEmp.EmpName;
            this.employeeID = depEmp.EmpID;
            deleteFileName = depEmp.FileName;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int result = App.Instance().DBConnector.DeleteEmployee(employeeID);
            if (result < 0)
            {
                MessageBox.Show("실패");
            }
            else
            {
                string saveImage_route = @"C:\ImageForder";
                string filePath = Path.Combine(saveImage_route, $"{deleteFileName}.png");

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                MessageBox.Show("성공");
                Reset.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
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
