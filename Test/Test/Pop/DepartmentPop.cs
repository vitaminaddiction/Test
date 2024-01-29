using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.SubPop;


namespace Test.Pop
{
    public partial class DepartmentPop : Form
    {
        public DepartmentPop()
        {
            InitializeComponent();            
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            DepartmentSubPopAdd pop = new DepartmentSubPopAdd();
            pop.ShowDialog();
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            DepartmentSubPopModify pop = new DepartmentSubPopModify();
            pop.ShowDialog();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DepartmentSubPopDelete pop = new DepartmentSubPopDelete();
            pop.ShowDialog();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
