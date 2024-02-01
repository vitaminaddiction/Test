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
    public partial class DepartmentSubPopAdd : Form
    {
        public event EventHandler Reset;

        MoveForm moveForm = new MoveForm();
        int GapX, GapY;

        public DepartmentSubPopAdd()
        {
            InitializeComponent();
            EventRegister();
        }

        private void EventRegister()
        {
            btn_save.Click += btn_save_Click;
            btn_close.Click += btn_close_Click;
            panel1.MouseDown += MainView_MouseDown;
            panel1.MouseMove += MainView_MouseMove;
            panel1.MouseUp += MainView_MouseUp;
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            Validation validation = new Validation();
            validation.v_string = tbox_depCode.Text;
            if (validation.checkEmpty())
            {
                MessageBox.Show("부서 코드가 입력해주세요.");
            }
            else
            {
                validation.v_string = tbox_depName.Text;
                if (validation.checkEmpty())
                {
                    MessageBox.Show("부서명을 입력해주세요.");
                }
                else
                {
                    Department department = new Department(tbox_depCode.Text, tbox_depName.Text, tbox_memo.Text);
                    int result = App.Instance().DBConnector.SetDepartment(department);
                    if (result < 0)
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
