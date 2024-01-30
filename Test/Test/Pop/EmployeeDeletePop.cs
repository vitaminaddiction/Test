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
    public partial class EmployeeDeletePop : Form
    {
        int employeeID = 0;
        public EmployeeDeletePop()
        {
            InitializeComponent();
        }

        public EmployeeDeletePop(DataGridViewRow row, int employeeID) : this()
        {
            label_code.Text = "사원 코드 : " + row.Cells["사원 코드"].Value.ToString();
            label_name.Text = "사원명 : " + row.Cells["사원명"].Value.ToString();
            this.employeeID = employeeID;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int result = App.Instance().DBConnector.deleteEmployee(employeeID);
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
