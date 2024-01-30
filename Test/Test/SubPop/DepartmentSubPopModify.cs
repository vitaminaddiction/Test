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
    public partial class DepartmentSubPopModify : Form
    {
        int depID = 0;
        public DepartmentSubPopModify()
        {
            InitializeComponent();
        }

        public DepartmentSubPopModify(DataGridViewRow row, int depID) : this()
        {
            tbox_depCode.Text = row.Cells["부서 코드"].Value.ToString();
            tbox_depName.Text = row.Cells["부서명"].Value.ToString();
            tbox_memo.Text = row.Cells["메모"].Value.ToString();
            this.depID = depID;
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
                    Department department = new Department(depID, tbox_depCode.Text, tbox_depName.Text, tbox_memo.Text);
                    int result = App.Instance().DBConnector.updateDepartment(department);
                    if (result < 0)
                    {
                        MessageBox.Show("실패");
                    }
                    else
                    {
                        MessageBox.Show("성공");
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
