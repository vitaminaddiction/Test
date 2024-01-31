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
                        string loginID = tbox_ID.Text;
                        string password = tbox_password.Text;
                        int result = App.Instance().DBConnector.updateLoginID(loginID, password, employeeID);
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
