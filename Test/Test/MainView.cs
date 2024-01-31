using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Pop;
using Test.DB;
using Test.Util;

namespace Test
{
    public partial class MainView : Form
    {
        MoveForm moveForm = new MoveForm();
        int GapX, GapY;

        public MainView()
        {
            InitializeComponent();
            EventRegister();
            setTable();
        }

        public void EventRegister()
        {
            btn_department.Click += btn_department_Click;
            btn_search.Click += btn_search_Click;
            btn_add.Click += btn_add_Click;
            btn_modify.Click += btn_modify_Click;
            btn_loginInfo.Click += btn_loginInfo_Click;
            btn_delete.Click += btn_delete_Click;
            btn_close.Click += btn_close_Click;
            dGridView.CellFormatting += dGridView_CellFormatting;
            panel1.MouseDown += MainView_MouseDown;
            panel1.MouseUp += MainView_MouseUp;
            panel1.MouseMove += MainView_MouseMove;
        }

        
        public void setTable()
        {
            List<DepEmp> list = App.Instance().DBConnector.GetDataSourse();
            dGridView.DataSource = list;

            dGridView.Columns["DepID"].Visible = false;
            dGridView.Columns["EmpID"].Visible = false;
            dGridView.Columns["DepID_FK"].Visible = false;
            dGridView.Columns["Department"].Visible = false;
            dGridView.Columns["Employee"].Visible = false;
            dGridView.Columns["DepMemo"].Visible = false;
        }

        #region 이벤트
        private void btn_department_Click(object sender, EventArgs e)
        {
            DepartmentPop pop = new DepartmentPop();
            pop.Show();
            pop.Reset += btn_search_Click;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            setTable();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            EmployeeAddPop pop = new EmployeeAddPop();
            pop.Show();
            pop.Reset += btn_search_Click;
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            if (dGridView.CurrentRow != null)
            {
                DepEmp depEmp = dGridView.CurrentRow.DataBoundItem as DepEmp;
                if (depEmp != null)
                {
                    EmployeeModifyPop pop = new EmployeeModifyPop(depEmp);
                    pop.Show();
                    pop.Reset += btn_search_Click;
                }
            }
            else
            {
                MessageBox.Show("행을 선택 해주세요.");
            }
        }

        private void btn_loginInfo_Click(object sender, EventArgs e)
        {
            if (dGridView.CurrentRow != null)
            {
                DepEmp depEmp = dGridView.CurrentRow.DataBoundItem as DepEmp;
                if (depEmp != null)
                {
                    LoginInfoPop pop = new LoginInfoPop(depEmp);
                    pop.Show();
                    pop.Reset += btn_search_Click;
                }
            }
            else
            {
                MessageBox.Show("행을 선택 해주세요.");
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dGridView.CurrentRow != null)
            {
                DepEmp depEmp = dGridView.CurrentRow.DataBoundItem as DepEmp;
                if (depEmp != null)
                {
                    EmployeeDeletePop pop = new EmployeeDeletePop(depEmp);
                    pop.Show();
                    pop.Reset += btn_search_Click;
                }
            }
            else
            {
                MessageBox.Show("행을 선택 해주세요.");
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //https://www.youtube.com/watch?v=yrgPyMoHu_8
            if (e.ColumnIndex == 11)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }
        #endregion

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
