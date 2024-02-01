using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Manager;

namespace Test.API
{
    public partial class EmployeeLoginView : Form
    {
        TokenManager tokenManager;

        public EmployeeLoginView()
        {
            InitializeComponent();
            EventRegister();
        }

        public EmployeeLoginView(TokenManager tokenManager) : this()
        {
            this.tokenManager = tokenManager;
        }

        private void EventRegister()
        {
            btn_close.Click += Btn_close_Click;
            btn_login.Click += Btn_login_Click;
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            if (tokenManager.ValidationEmployeeToken())
            {
                APIMainView aPIMainView = new APIMainView(tokenManager);
                aPIMainView.Show();
            }
            else
            {
                tokenManager.SaveEmployeeToken(tBox_ID.Text, tBox_Password.Text);
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
