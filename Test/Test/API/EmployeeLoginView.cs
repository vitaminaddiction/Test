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
using Test.Manager;
using Test.Util;

namespace Test.API
{
    public partial class EmployeeLoginView : Form
    {
        MoveForm moveForm = new MoveForm();
        int GapX, GapY;

        public EmployeeLoginView()
        {
            InitializeComponent();
            EventRegister();
        }

        public EmployeeLoginView(TokenManager tokenManager) : this()
        {

        }

        private void EventRegister()
        {
            btn_close.Click += Btn_close_Click;
            btn_login.Click += Btn_login_Click;
            panel1.MouseDown += MainView_MouseDown;
            panel1.MouseMove += MainView_MouseMove;
            panel1.MouseUp += MainView_MouseUp;
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            TokenManager tokenManager = App.Instance().TokenManager;

            if (!tokenManager.ValidationEmployeeToken()) { tokenManager.SaveEmployeeToken(tBox_ID.Text, tBox_Password.Text); }
            if (tokenManager.EmployeeToken == string.Empty) { }
            else
            {
                GridView aPIMainView = new GridView();
                aPIMainView.Show();
                this.Hide();
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region 마우스 이동 //https://424485.tistory.com/57
        private void MainView_MouseDown(object sender, MouseEventArgs e)
        {
            GapX = Cursor.Position.X - this.Location.X;
            GapY = Cursor.Position.Y - this.Location.Y;

            moveForm.Size = new Size(this.Width, this.Height);

            moveForm.Location = new Point(Cursor.Position.X - GapX, Cursor.Position.Y - GapY);

            moveForm.Show();
        }
        private void MainView_MouseUp(object sender, MouseEventArgs e)
        {
            this.Location = new Point(moveForm.Location.X, moveForm.Location.Y);

            moveForm.Hide();
        }
        private void MainView_MouseMove(object sender, MouseEventArgs e)
        {
            moveForm.Location = new Point(Cursor.Position.X - GapX, Cursor.Position.Y - GapY);
        }
        #endregion
    }
}
