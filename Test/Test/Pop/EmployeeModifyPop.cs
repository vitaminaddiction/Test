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
    public partial class EmployeeModifyPop : Form
    {
        public event EventHandler Reset;

        MoveForm moveForm = new MoveForm();
        int GapX, GapY;

        string deleteFileName = string.Empty;

        List<DepartmentForDB> list;
        int employeeID;
        public EmployeeModifyPop()
        {
            InitializeComponent();
            EventRegister();
            initialize();
        }

        public void EventRegister()
        {
            btn_save.Click += btn_save_Click;
            btn_close.Click += btn_close_Click;
            cbox_Dcode.SelectedIndexChanged += cbox_Dcode_SelectedIndexChanged;
            panel1.MouseDown += MainView_MouseDown;
            panel1.MouseUp += MainView_MouseUp;
            panel1.MouseMove += MainView_MouseMove;
            btn_picture.Click += Btn_picture_Click;
        }

        public void initialize()
        {
            DBConnector con = App.Instance().DBConnector;
            list = con.SelectDepartments();

            foreach (DepartmentForDB item in list)
            {
                cbox_Dcode.Items.Add(item.Code);
            }
        }

        public EmployeeModifyPop(DepEmp depEmp) : this()
        {
            cbox_Dcode.SelectedItem = depEmp.DepCode;
            tbox_Ecode.Text = depEmp.EmpCode;
            tbox_Ename.Text = depEmp.EmpName;
            tbox_rank.Text = depEmp.Rank;
            tbox_state.Text = depEmp.State;
            tbox_phone.Text = depEmp.Phone;
            tbox_email.Text = depEmp.Email;
            tbox_messengerId.Text = depEmp.MessengerID;
            tbox_memo.Text = depEmp.EmpMemo;
            if(depEmp.Gender == Gender.female)
            {
                rbtn_female.Checked = true;
            }
            employeeID = depEmp.EmpID;
            string saveImage_route = @"C:\ImageForder";
            string imagePath = Path.Combine(saveImage_route, $"{depEmp.FileName}.png");
            if (File.Exists(imagePath))
            {
                //https://stackoverflow.com/questions/8905714/overwrite-existing-image
                using (FileStream fs = new FileStream(imagePath, FileMode.Open))
                {
                    pBox.Image = Image.FromStream(fs);
                    fs.Close();
                }
                pBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            deleteFileName = depEmp.FileName;
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
                        validation.v_string = tbox_email.Text;
                        if (validation.checkEmail() == false)
                        {
                            MessageBox.Show("이메일 형식이 바르지 않습니다.");
                        }
                        else
                        {
                            string fileName = $"{employeeID}_{DateTime.Now.Ticks}";
                            Gender gender = rbtn_male.Checked ? Gender.male : Gender.female;
                            EmployeeForDB employee = new EmployeeForDB(list[cbox_Dcode.SelectedIndex].ID, tbox_Ecode.Text, tbox_Ename.Text, tbox_rank.Text, tbox_state.Text,
                                tbox_phone.Text, tbox_email.Text, tbox_messengerId.Text, tbox_memo.Text, gender, pBox.Tag.ToString(), fileName);
                            employee.ID = employeeID;
                            int result = App.Instance().DBConnector.UpdateEmployee(employee);
                            if (result < 0)
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
                                
                                string filePath = Path.Combine(saveImage_route, $"{deleteFileName}.png");

                                if (System.IO.File.Exists(filePath))
                                {
                                    System.IO.File.Delete(filePath);
                                }

                                pBox.Image.Save(saveImage_route + @"\" + $"{fileName}.png");
                                MessageBox.Show("성공");
                                Reset.Invoke(this, EventArgs.Empty);
                                this.Close();
                            }
                        }
                    }
                }
            }
        }

        private void Btn_picture_Click(object sender, EventArgs e)
        {
            string image_file = string.Empty;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"D:\";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image_file = dialog.FileName;
                pBox.Tag = Path.GetFileName(image_file);
            }
            else if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            pBox.Image = Bitmap.FromFile(image_file);
            pBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbox_Dcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbox_Dname.Text = list[cbox_Dcode.SelectedIndex].Name;
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
