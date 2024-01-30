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
using Test.SubPop;


namespace Test.Pop
{
    public partial class DepartmentPop : Form
    {
        public DepartmentPop()
        {
            InitializeComponent();
            setTable();
        }

        public void setTable()
        {
            DataSet ds = App.Instance().DBConnector.getDepartment();
            DataTable dt = ds.Tables[0];

            dt.Columns["id"].ColumnMapping = MappingType.Hidden;

            dt.Columns["code"].ColumnName = "부서 코드";
            dt.Columns["name"].ColumnName = "부서명";
            dt.Columns["memo"].ColumnName = "메모";

            dGridView.DataSource = dt;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            DepartmentSubPopAdd pop = new DepartmentSubPopAdd();
            if(pop.ShowDialog() == DialogResult.OK)
            {
                setTable();
            }
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            if (dGridView.SelectedRows.Count > 0)
            {
                int depID = 0;
                DataGridViewRow row = dGridView.SelectedRows[0];
                DataRowView dataRowView = row.DataBoundItem as DataRowView;
                if (dataRowView != null)
                {
                    string ID = dataRowView["id"].ToString();
                    depID = Int32.Parse(ID);
                }

                DepartmentSubPopModify pop = new DepartmentSubPopModify(row, depID);
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    setTable();
                }
            }
            else
            {
                MessageBox.Show("행을 선택 해주세요.");
            }
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dGridView.SelectedRows.Count > 0)
            {
                int depID = 0;
                DataGridViewRow row = dGridView.SelectedRows[0];
                DataRowView dataRowView = row.DataBoundItem as DataRowView;
                if (dataRowView != null)
                {
                    string ID = dataRowView["id"].ToString();
                    depID = Int32.Parse(ID);
                }

                DepartmentSubPopDelete pop = new DepartmentSubPopDelete(row, depID);
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    setTable();
                }
            }
            else
            {
                MessageBox.Show("행을 선택 해주세요.");
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
