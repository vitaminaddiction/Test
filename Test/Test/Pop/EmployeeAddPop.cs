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
    public partial class EmployeeAddPop : Form
    {
        public event EventHandler Reset;

        MoveForm moveForm = new MoveForm();
        int GapX, GapY;

        List<Department> list;
        public EmployeeAddPop()
        {
            InitializeComponent();
            EventRegister();
            initialize();
        }

        public void EventRegister()
        {
            btn_save.Click += btn_save_Click;
            btn_close.Click += btn_close_Click;
            cbox_Dcode.SelectedIndexChanged += cbox_code_SelectedIndexChanged;
            panel1.MouseDown += MainView_MouseDown;
            panel1.MouseUp += MainView_MouseUp;
            panel1.MouseMove += MainView_MouseMove;
        }

        public void initialize()
        {
            DBConnector con = App.Instance().DBConnector;
            list = con.getDepartments();
            foreach(Department item in list)
            {
                cbox_Dcode.Items.Add(item.code);
            }
            cbox_Dcode.SelectedIndex = 0;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Validation validation = new Validation();
            validation.v_string = tbox_Ecode.Text;
            if (cbox_Dcode.SelectedIndex == -1)
            {
                MessageBox.Show("부서 코드를 선택해주세요.");
            }
            else
            {
                if (validation.checkEmpty())
                {
                    MessageBox.Show("사원 코드가 비어있습니다.");
                }
                else
                {
                    validation.v_string = tbox_Ename.Text;
                    if (validation.checkEmpty())
                    {
                        MessageBox.Show("사원명이 비어있습니다.");
                    }
                    else
                    {
                        validation.v_string = tbox_loginId.Text;
                        if (validation.checkEmpty())
                        {
                            MessageBox.Show("로그인ID가 비어있습니다.");
                        }
                        else
                        {
                            validation.v_string = tbox_password.Text;
                            if (validation.checkEmpty())
                            {
                                MessageBox.Show("비밀번호가 비어있습니다.");
                            }
                            else
                            {
                                if (validation.checkPassword())
                                {
                                    validation.v_string = tbox_email.Text;
                                    if (validation.checkEmail() == false)
                                    {
                                        MessageBox.Show("이메일 형식이 바르지 않습니다.");
                                    }
                                    else
                                    {
                                        char gender = rbtn_male.Checked ? 'M' : 'F';
                                        Employee employee = new Employee(list[cbox_Dcode.SelectedIndex].id, tbox_Ecode.Text, tbox_Ename.Text, tbox_rank.Text, tbox_state.Text,
                                            tbox_phone.Text, tbox_email.Text, tbox_messengerId.Text, tbox_memo.Text, gender);
                                        int result = App.Instance().DBConnector.setEmployee(employee);
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
                                else
                                {
                                    MessageBox.Show("비밀번호는 8자리 이상 영어,숫자,특수문자를 포함해야 합니다.");
                                }

                            }
                        }
                    }
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbox_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbox_Dname.Text = list[cbox_Dcode.SelectedIndex].name;
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
