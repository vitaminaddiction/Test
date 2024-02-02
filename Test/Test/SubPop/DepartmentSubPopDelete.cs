using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.DB;
using Test.Util;

namespace Test.SubPop
{
    public partial class DepartmentSubPopDelete : Form
    {
        public event EventHandler Reset;

        MoveForm moveForm = new MoveForm();
        int GapX, GapY;

        int depID = 0;
        public DepartmentSubPopDelete()
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
        public DepartmentSubPopDelete(DepartmentForDB dep) : this()
        {
            label_code.Text = "부서 코드 : " + dep.code;
            label_name.Text = "부서명 : " + dep.name;
            depID = dep.id;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int result = App.Instance().DBConnector.DeleteDepartment(depID);
            if(result < 0)
            {
                MessageBox.Show("실패");
            }
            else
            {
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
