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
        List<Department> list;
        public EmployeeAddPop()
        {
            InitializeComponent();
            initialize();
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
                            validation.v_string = tbox_email.Text;
                            if (validation.checkEmail() == false)
                            {
                                MessageBox.Show("이메일 형식이 바르지 않습니다.");
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
                                        char gender;
                                        if (rbtn_male.Checked)
                                        {
                                            gender = 'M';
                                        }
                                        else
                                        {
                                            gender = 'F';
                                        }
                                        MessageBox.Show(tbox_memo.Text);
                                        Employee employee = new Employee(list[cbox_Dcode.SelectedIndex].id, tbox_Ecode.Text, tbox_Ename.Text, tbox_loginId.Text, tbox_password.Text,
                                                                tbox_rank.Text, tbox_state.Text, tbox_phone.Text, tbox_email.Text, tbox_messengerId.Text, tbox_memo.Text, gender);
                                        int result = App.Instance().DBConnector.setEmployee(employee);
                                        if (result > 0)
                                        {
                                            MessageBox.Show("성공");
                                            this.DialogResult = DialogResult.OK;
                                        }
                                        else
                                        {
                                            MessageBox.Show("실패");
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
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbox_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbox_Dname.Text = list[cbox_Dcode.SelectedIndex].name;
        }
    }
}
