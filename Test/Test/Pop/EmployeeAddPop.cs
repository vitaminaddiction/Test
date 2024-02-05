using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.DB;
using Test.Util;

namespace Test.Pop
{
    public partial class EmployeeAddPop : Form
    {
        public event EventHandler Reset;

        MoveForm moveForm = new MoveForm();
        int GapX, GapY;

        List<DepartmentForDB> list;
        public EmployeeAddPop()
        {
            InitializeComponent();
            EventRegister();
            initialize();
        }

        public void EventRegister()
        {
            btn_save.Click += btn_save_Click;
            btn_close.Click += btn_close_Click;
            cbox_Dcode.SelectedIndexChanged += cbox_code_SelectedIndexChanged;
            panel1.MouseDown += MainView_MouseDown;
            panel1.MouseUp += MainView_MouseUp;
            panel1.MouseMove += MainView_MouseMove;
            btn_image.Click += Btn_image_Click;
        }

        public void initialize()
        {
            DBConnector con = App.Instance().DBConnector;
            list = con.SelectDepartments();
            foreach(DepartmentForDB item in list)
            {
                cbox_Dcode.Items.Add(item.Code);
            }
            cbox_Dcode.SelectedIndex = 0;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Validation validation = new Validation();
            validation.v_string = tbox_Ecode.Text;
            if (cbox_Dcode.SelectedIndex == -1)
            {
                MessageBox.Show("부서 코드를 선택해주세요.");
            }
            else
            {
                if (validation.checkEmpty())
                {
                    MessageBox.Show("사원 코드가 비어있습니다.");
                }
                else
                {
                    validation.v_string = tbox_Ename.Text;
                    if (validation.checkEmpty())
                    {
                        MessageBox.Show("사원명이 비어있습니다.");
                    }
                    else
                    {
                        validation.v_string = tbox_loginId.Text;
                        if (validation.checkEmpty())
                        {
                            MessageBox.Show("로그인ID가 비어있습니다.");
                        }
                        else
                        {
                            validation.v_string = tbox_password.Text;
                            if (validation.checkEmpty())
                            {
                                MessageBox.Show("비밀번호가 비어있습니다.");
                            }
                            else
                            {
                                if (validation.checkPassword())
                                {
                                    validation.v_string = tbox_email.Text;
                                    if (validation.checkEmail() == false)
                                    {
                                        MessageBox.Show("이메일 형식이 바르지 않습니다.");
                                    }
                                    else
                                    {
                                        Gender gender = rbtn_male.Checked ? Gender.male : Gender.female;
                                        EmployeeForDB employee = new EmployeeForDB(list[cbox_Dcode.SelectedIndex].ID, tbox_Ecode.Text, tbox_Ename.Text, tbox_loginId.Text, tbox_password.Text, tbox_rank.Text, tbox_state.Text,
                                            tbox_phone.Text, tbox_email.Text, tbox_messengerId.Text, tbox_memo.Text, gender,pBox.Tag.ToString());
                                        string fileName = App.Instance().DBConnector.InsertEmployeeWithImage(employee);
                                        if (fileName is null)
                                        {
                                            MessageBox.Show("실패");
                                        }
                                        else
                                        {
                                            string saveImage_route = @"C:\ImageForder";
                                            if (!System.IO.Directory.Exists(saveImage_route))
                                            {
                                                System.IO.Directory.CreateDirectory(saveImage_route);
                                            }
                                            pBox.Image.Save(saveImage_route + @"\" + $"{fileName}.png");
                                            MessageBox.Show("성공");
                                            Reset.Invoke(this, EventArgs.Empty);
                                            this.Close();
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("비밀번호는 8자리 이상 영어,숫자,특수문자를 포함해야 합니다.");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbox_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbox_Dname.Text = list[cbox_Dcode.SelectedIndex].Name;
        }

        private void Btn_image_Click(object sender, EventArgs e)
        {
            string image_file = string.Empty;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"D:\";
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image_file = dialog.FileName;
                pBox.Tag = Path.GetFileName(image_file);
            }
            else if(dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            pBox.Image = Bitmap.FromFile(image_file);
            pBox.SizeMode = PictureBoxSizeMode.StretchImage;
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
