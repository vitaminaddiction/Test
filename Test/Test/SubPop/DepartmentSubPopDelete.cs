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

namespace Test.SubPop
{
    public partial class DepartmentSubPopDelete : Form
    {
        int depID = 0;
        public DepartmentSubPopDelete()
        {
            InitializeComponent();
        }
        public DepartmentSubPopDelete(DataGridViewRow row, int depID) : this()
        {
            label_code.Text = "부서 코드 : " + row.Cells["부서 코드"].Value.ToString();
            label_name.Text = "부서명 : " + row.Cells["부서명"].Value.ToString();
            this.depID = depID;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int result = App.Instance().DBConnector.deleteDepartment(depID);
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
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
