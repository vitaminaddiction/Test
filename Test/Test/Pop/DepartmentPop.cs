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
            EventRegister();
            SetTable();
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

        public void SetTable()
        {
            List<DepartmentForDB> list = App.Instance().DBConnector.GetDepartments();
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
            if (dGridView.CurrentRow != null)
            {
                if (dGridView.CurrentRow.DataBoundItem is DepartmentForDB dep)
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
            if (dGridView.CurrentRow != null)
            {
                if (dGridView.CurrentRow.DataBoundItem is DepartmentForDB dep)
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
            SetTable();
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
