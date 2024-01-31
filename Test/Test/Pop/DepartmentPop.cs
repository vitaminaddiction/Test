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
using Test.SubPop;
using Test.Util;

namespace Test.Pop
{
    public partial class DepartmentPop : Form
    {
        public event EventHandler Reset;

        MoveForm moveForm = new MoveForm();
        int GapX, GapY;

        public DepartmentPop()
        {
            InitializeComponent();
            setTable();
            EventRegister();
        }

        public void EventRegister()
        {
            btn_add.Click += btn_add_Click;
            btn_modify.Click += btn_modify_Click;
            btn_delete.Click += btn_delete_Click;
            btn_close.Click += btn_close_Click;
            panel1.MouseDown += MainView_MouseDown;
            panel1.MouseUp += MainView_MouseUp;
            panel1.MouseMove += MainView_MouseMove;
        }

        public void setTable()
        {
            List<Department> list = App.Instance().DBConnector.getDepartments();
            dGridView.DataSource = list;

            dGridView.Columns["id"].Visible = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            DepartmentSubPopAdd pop = new DepartmentSubPopAdd();
            pop.Show();
            pop.Reset += Refresh;
            pop.Reset += Reset;
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            if (dGridView.SelectedRows.Count > 0)
            {
                Department dep = dGridView.SelectedRows[0].DataBoundItem as Department;
                if (dep != null)
                {
                    DepartmentSubPopModify pop = new DepartmentSubPopModify(dep);
                    pop.Show();
                    pop.Reset += Refresh;
                    pop.Reset += Reset;
                }
            }
            else
            {
                MessageBox.Show("행을 선택 해주세요.");
            }
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dGridView.SelectedRows.Count > 0)
            {
                Department dep = dGridView.SelectedRows[0].DataBoundItem as Department;
                if (dep != null)
                {
                    DepartmentSubPopDelete pop = new DepartmentSubPopDelete(dep);
                    pop.Show();
                    pop.Reset += Refresh;
                    pop.Reset += Reset;
                }
            }
            else
            {
                MessageBox.Show("행을 선택 해주세요.");
            }
        }

        private void Refresh(object sender, EventArgs e)
        {
            setTable();
        }


        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 마우스 이동 //https://424485.tistory.com/57
        private void MainView_MouseDown(object sender, MouseEventArgs e)

        {

            // 마우스를 누르면 

            GapX = Cursor.Position.X - this.Location.X;    // Form1 과 마우스의 위치차이를 저장

            GapY = Cursor.Position.Y - this.Location.Y;    // Form1 과 마우스의 위치차이를 저장



            // MoveForm의 사이즈를  Form1과 동일하기 설정

            moveForm.Size = new Size(this.Width, this.Height);



            // MoveForm의 위치를 Form1의 위치와 동일하기

            moveForm.Location = new Point(Cursor.Position.X - GapX, Cursor.Position.Y - GapY);



            // MoveForm를 보입니다

            moveForm.Show();

        }

        private void MainView_MouseUp(object sender, MouseEventArgs e)

        {

            // 마우스를 떼면 Form1의 위치를 변경하고 MoveForm 는 보이지 않게 합니다

            this.Location = new Point(moveForm.Location.X, moveForm.Location.Y);

            moveForm.Hide();

        }
        private void MainView_MouseMove(object sender, MouseEventArgs e)

        {

            // 마우스를 움직이면 MoveForm의 위치를 움직여서 Form1이 옮겨질 위치를 알수있게 합니다

            moveForm.Location = new Point(Cursor.Position.X - GapX, Cursor.Position.Y - GapY);

        }
        #endregion
    }
}
