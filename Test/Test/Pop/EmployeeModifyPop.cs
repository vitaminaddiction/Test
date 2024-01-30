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

namespace Test.Pop
{
    public partial class EmployeeModifyPop : Form
    {
        List<Department> list;
        int employeeID;
        public EmployeeModifyPop()
        {
            InitializeComponent();
            initialize();
        }
        public void initialize()
        {
            DBConnector con = App.Instance().DBConnector;
            list = con.getDepartments();
            foreach (Department item in list)
            {
                cbox_Dcode.Items.Add(item.code);
            }
        }

        public EmployeeModifyPop(DataGridViewRow row, int id) : this()
        {
            cbox_Dcode.SelectedItem = row.Cells["부서 코드"].Value.ToString();
            tbox_Ecode.Text = row.Cells["사원 코드"].Value.ToString();
            tbox_Ename.Text = row.Cells["사원명"].Value.ToString();
            tbox_rank.Text = row.Cells["직위"].Value.ToString();
            tbox_state.Text = row.Cells["고용형태"].Value.ToString();
            tbox_phone.Text = row.Cells["휴대전화"].Value.ToString();
            tbox_email.Text = row.Cells["이메일"].Value.ToString();
            tbox_messengerId.Text = row.Cells["메신저ID"].Value.ToString();
            tbox_memo.Text = row.Cells["메모"].Value.ToString();
            if(row.Cells["성별"].Value.ToString() == "F")
            {
                rbtn_female.Checked = true;
            }
            employeeID = id;
        }

        private void btn_save_Click(object sender, EventArgs e)
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
            Employee employee = new Employee(list[cbox_Dcode.SelectedIndex].id, tbox_Ecode.Text, tbox_Ename.Text, tbox_rank.Text, tbox_state.Text,
                tbox_phone.Text, tbox_email.Text, tbox_messengerId.Text, tbox_memo.Text, gender);
            int result = App.Instance().DBConnector.updateEmployee(employee, employeeID);
            if(result < 0)
            {
                MessageBox.Show("실패");
            }
            else
            {
                MessageBox.Show("성공");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cbox_Dcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbox_Dname.Text = list[cbox_Dcode.SelectedIndex].name;
        }
    }
}
