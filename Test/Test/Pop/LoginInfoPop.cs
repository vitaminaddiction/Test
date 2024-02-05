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

namespace Test.Pop
{
    public partial class LoginInfoPop : Form
    {
        public event EventHandler Reset;

        MoveForm moveForm = new MoveForm();
        int GapX, GapY;

        int employeeID = 0;
        public LoginInfoPop()
        {
            InitializeComponent();
            EventRegister();
        }

        private void EventRegister()
        {
            btn_save.Click += btn_save_Click;
            btn_close.Click += btn_close_Click;
            label3.DoubleClick += label3_DoubleClick;
            panel1.MouseDown += MainView_MouseDown;
            panel1.MouseUp += MainView_MouseUp;
            panel1.MouseMove += MainView_MouseMove;
        }

        public LoginInfoPop(DepEmp depEmp) : this()
        {
            tbox_ID.Text = depEmp.LoginID;
            tbox_password.Text = depEmp.Password;
            this.employeeID = depEmp.EmpID;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Validation validation = new Validation();
            validation.v_string = tbox_ID.Text;
            if (validation.checkEmpty())
            {
                MessageBox.Show("ID를 입력해주세요.");
            }
            else
            {
                validation.v_string = tbox_password.Text;
                if (validation.checkEmpty())
                {
                    MessageBox.Show("비밀번호를 입력해주세요.");
                }
                else
                {
                    if (validation.checkPassword())
                    {
                        EmployeeForDB employee = new EmployeeForDB();
                        employee.ID = employeeID;
                        employee.LoginID = tbox_ID.Text;
                        employee.Password = tbox_password.Text;
                        int result = App.Instance().DBConnector.UpdateLoginID(employee);
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
                    else
                    {
                        MessageBox.Show("비밀번호는 8자리 이상 영어,숫자,특수문자를 포함해야 합니다.");
                    }
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_DoubleClick(object sender, EventArgs e)
        {
            tbox_password.PasswordChar = '\0';
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
