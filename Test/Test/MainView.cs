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
using Test.DB;

namespace Test
{
    public partial class MainView : Form
    {
        DataSet ds;
        public MainView()
        {
            InitializeComponent();
            setTable();
        }

        public void setTable()
        {
            DBConnector con = App.Instance().DBConnector;
            
            ds = con.getDepartmentDataSet();
            DataTable dt = ds.Tables[0];

            dt.Columns["id"].ColumnMapping = MappingType.Hidden;
            dt.Columns["id1"].ColumnMapping = MappingType.Hidden;
            dt.Columns["memo"].ColumnMapping = MappingType.Hidden;
            dt.Columns["depid"].ColumnMapping = MappingType.Hidden;

            dt.Columns["code"].ColumnName = "부서 코드";
            dt.Columns["name"].ColumnName = "부서명";
            dt.Columns["code1"].ColumnName = "사원 코드";
            dt.Columns["name1"].ColumnName = "사원명";
            dt.Columns["loginId"].ColumnName = "로그인ID";
            dt.Columns["password"].ColumnName = "비밀번호";
            dt.Columns["rank"].ColumnName = "직위";
            dt.Columns["state"].ColumnName = "고용형태";
            dt.Columns["phone"].ColumnName = "휴대전화";
            dt.Columns["email"].ColumnName = "이메일";
            dt.Columns["messengerId"].ColumnName = "메신저ID";
            dt.Columns["memo1"].ColumnName = "메모";
            dt.Columns["gender"].ColumnName = "성별";


            
            dGridView.DataSource = dt;
        }

        private void btn_department_Click(object sender, EventArgs e)
        {
            DepartmentPop pop = new DepartmentPop();
            pop.ShowDialog();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            setTable();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            EmployeeAddPop pop = new EmployeeAddPop();
            pop.ShowDialog();
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            if (dGridView.SelectedRows.Count > 0)
            {
                int employeeID = 0;
                DataGridViewRow row = dGridView.SelectedRows[0];
                DataRowView dataRowView = row.DataBoundItem as DataRowView;
                if (dataRowView != null)
                {
                    string ID = dataRowView["id1"].ToString();
                    employeeID = Int32.Parse(ID);
                }
                
                EmployeeModifyPop pop = new EmployeeModifyPop(row, employeeID);
                pop.ShowDialog();
            }
            else
            {
                MessageBox.Show("행을 선택 해주세요.");
            }
        }

        private void btn_loginInfo_Click(object sender, EventArgs e)
        {
            LoginInfoPop pop = new LoginInfoPop();
            pop.ShowDialog();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dGridView.SelectedRows.Count > 0)
            {
                int employeeID = 0;
                DataGridViewRow row = dGridView.SelectedRows[0];
                DataRowView dataRowView = row.DataBoundItem as DataRowView;
                if (dataRowView != null)
                {
                    string ID = dataRowView["id1"].ToString();
                    employeeID = Int32.Parse(ID);
                }

                EmployeeDeletePop pop = new EmployeeDeletePop(row, employeeID);
                pop.ShowDialog();
            }
            else
            {
                MessageBox.Show("행을 선택 해주세요.");
            }
            
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
