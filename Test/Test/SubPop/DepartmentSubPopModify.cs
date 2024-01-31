﻿using System;
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
        public event EventHandler Reset;

        MoveForm moveForm = new MoveForm();
        int GapX, GapY;

        int depID = 0;
        public DepartmentSubPopModify()
        {
            InitializeComponent();
            EventRegister();
        }

        private void EventRegister()
        {
            btn_save.Click += btn_save_Click;
            btn_close.Click += btn_close_Click;
            panel1.MouseDown += MainView_MouseDown;
            panel1.MouseUp += MainView_MouseUp;
            panel1.MouseMove += MainView_MouseMove;
        }

        public DepartmentSubPopModify(Department dep) : this()
        {
            tbox_depCode.Text = dep.code;
            tbox_depName.Text = dep.name;
            tbox_memo.Text = dep.memo;
            depID = dep.id;
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
                        Reset.Invoke(this, EventArgs.Empty);
                        this.Close();
                    }
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 마우스 이동 //https://424485.tistory.com/57
        private void MainView_MouseDown(object sender, MouseEventArgs e)

        {

            // 마우스를 누르면 

            GapX = Cursor.Position.X - this.Location.X;    // Form1 과 마우스의 위치차이를 저장

            GapY = Cursor.Position.Y - this.Location.Y;    // Form1 과 마우스의 위치차이를 저장



            // MoveForm의 사이즈를  Form1과 동일하기 설정

            moveForm.Size = new Size(this.Width, this.Height);



            // MoveForm의 위치를 Form1의 위치와 동일하기

            moveForm.Location = new Point(Cursor.Position.X - GapX, Cursor.Position.Y - GapY);



            // MoveForm를 보입니다

            moveForm.Show();

        }

        private void MainView_MouseUp(object sender, MouseEventArgs e)

        {

            // 마우스를 떼면 Form1의 위치를 변경하고 MoveForm 는 보이지 않게 합니다

            this.Location = new Point(moveForm.Location.X, moveForm.Location.Y);

            moveForm.Hide();

        }
        private void MainView_MouseMove(object sender, MouseEventArgs e)

        {

            // 마우스를 움직이면 MoveForm의 위치를 움직여서 Form1이 옮겨질 위치를 알수있게 합니다

            moveForm.Location = new Point(Cursor.Position.X - GapX, Cursor.Position.Y - GapY);

        }
        #endregion
    }
}
