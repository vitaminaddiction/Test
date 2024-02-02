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
    public partial class EmployeeModifyPop : Form
    {
        public event EventHandler Reset;

        MoveForm moveForm = new MoveForm();
        int GapX, GapY;

        List<DepartmentForDB> list;
        int employeeID;
        public EmployeeModifyPop()
        {
            InitializeComponent();
            EventRegister();
            initialize();
        }

        public void EventRegister()
        {
            btn_save.Click += btn_save_Click;
            btn_close.Click += btn_close_Click;
            cbox_Dcode.SelectedIndexChanged += cbox_Dcode_SelectedIndexChanged;
            panel1.MouseDown += MainView_MouseDown;
            panel1.MouseUp += MainView_MouseUp;
            panel1.MouseMove += MainView_MouseMove;
        }


        public void initialize()
        {
            DBConnector con = App.Instance().DBConnector;
            list = con.GetDepartments();

            foreach (DepartmentForDB item in list)
            {
                cbox_Dcode.Items.Add(item.code);
            }
        }

        public EmployeeModifyPop(DepEmp depEmP) : this()
        {
            cbox_Dcode.SelectedItem = depEmP.DepCode;
            tbox_Ecode.Text = depEmP.EmpCode;
            tbox_Ename.Text = depEmP.EmpName;
            tbox_rank.Text = depEmP.Rank;
            tbox_state.Text = depEmP.State;
            tbox_phone.Text = depEmP.Phone;
            tbox_email.Text = depEmP.Email;
            tbox_messengerId.Text = depEmP.MessengerID;
            tbox_memo.Text = depEmP.EmpMemo;
            if(depEmP.Gender == 'F')
            {
                rbtn_female.Checked = true;
            }
            employeeID = depEmP.EmpID;
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
                        validation.v_string = tbox_email.Text;
                        if (validation.checkEmail() == false)
                        {
                            MessageBox.Show("이메일 형식이 바르지 않습니다.");
                        }
                        else
                        {
                            char gender = rbtn_male.Checked ? 'M' : 'F';
                            EmployeeForDB employee = new EmployeeForDB(list[cbox_Dcode.SelectedIndex].id, tbox_Ecode.Text, tbox_Ename.Text, tbox_rank.Text, tbox_state.Text,
                                tbox_phone.Text, tbox_email.Text, tbox_messengerId.Text, tbox_memo.Text, gender);
                            employee.id = employeeID;
                            int result = App.Instance().DBConnector.UpdateEmployee(employee);
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
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbox_Dcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbox_Dname.Text = list[cbox_Dcode.SelectedIndex].name;
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
