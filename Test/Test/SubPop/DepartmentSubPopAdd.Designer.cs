
namespace Test.SubPop
{
    partial class DepartmentSubPopAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.tbox_memo = new System.Windows.Forms.TextBox();
            this.tbox_depName = new System.Windows.Forms.TextBox();
            this.tbox_depCode = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 47);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "부서 추가";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.LightCoral;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_close.Location = new System.Drawing.Point(166, 219);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(111, 25);
            this.btn_close.TabIndex = 21;
            this.btn_close.Text = "취소";
            this.btn_close.UseVisualStyleBackColor = false;
            // 
            // tbox_memo
            // 
            this.tbox_memo.Location = new System.Drawing.Point(14, 163);
            this.tbox_memo.Name = "tbox_memo";
            this.tbox_memo.Size = new System.Drawing.Size(263, 21);
            this.tbox_memo.TabIndex = 20;
            // 
            // tbox_depName
            // 
            this.tbox_depName.Location = new System.Drawing.Point(173, 100);
            this.tbox_depName.Name = "tbox_depName";
            this.tbox_depName.Size = new System.Drawing.Size(104, 21);
            this.tbox_depName.TabIndex = 19;
            // 
            // tbox_depCode
            // 
            this.tbox_depCode.Location = new System.Drawing.Point(14, 100);
            this.tbox_depCode.Name = "tbox_depCode";
            this.tbox_depCode.Size = new System.Drawing.Size(104, 21);
            this.tbox_depCode.TabIndex = 18;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_save.Location = new System.Drawing.Point(49, 219);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(111, 25);
            this.btn_save.TabIndex = 17;
            this.btn_save.Text = "저장";
            this.btn_save.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Tomato;
            this.label4.Location = new System.Drawing.Point(171, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "부서명";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Tomato;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "부서 코드";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "메모";
            // 
            // DepartmentSubPopAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 260);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.tbox_memo);
            this.Controls.Add(this.tbox_depName);
            this.Controls.Add(this.tbox_depCode);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DepartmentSubPopAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DepartmentSubPop";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.TextBox tbox_memo;
        private System.Windows.Forms.TextBox tbox_depName;
        private System.Windows.Forms.TextBox tbox_depCode;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}