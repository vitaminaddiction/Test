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
            SetTable();
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
            pBox.DoubleClick += PBox_DoubleClick;
        }

        

        public void SetTable()
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
            SetTable();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            EmployeeAddPop pop = new EmployeeAddPop();

            pop.Reset += btn_search_Click;
            pop.Show();
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            if (dGridView.CurrentRow != null)
            {
                if (dGridView.CurrentRow.DataBoundItem is DepEmp depEmp)
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
                if (dGridView.CurrentRow.DataBoundItem is DepEmp depEmp)
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
                if (dGridView.CurrentRow.DataBoundItem is DepEmp depEmp)
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

        private void PBox_DoubleClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

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
