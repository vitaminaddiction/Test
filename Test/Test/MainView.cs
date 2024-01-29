using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Pop;

namespace Test
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void btn_department_Click(object sender, EventArgs e)
        {
            DepartmentPop pop = new DepartmentPop();
            pop.ShowDialog();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            EmployeeAddPop pop = new EmployeeAddPop();
            pop.ShowDialog();
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            EmployeeModifyPop pop = new EmployeeModifyPop();
            pop.ShowDialog();
        }

        private void btn_loginInfo_Click(object sender, EventArgs e)
        {
            LoginInfoPop pop = new LoginInfoPop();
            pop.ShowDialog();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            EmployeeDeletePop pop = new EmployeeDeletePop();
            pop.ShowDialog();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
