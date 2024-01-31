
namespace Test.Pop
{
    partial class EmployeeDeletePop
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.label_code = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 47);
            this.panel1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 47);
            this.label3.TabIndex = 1;
            this.label3.Text = "사원 삭제";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "삭제하시겠습니까?";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(12, 88);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(53, 12);
            this.label_name.TabIndex = 10;
            this.label_name.Text = "사원명 : ";
            // 
            // label_code
            // 
            this.label_code.AutoSize = true;
            this.label_code.Location = new System.Drawing.Point(12, 67);
            this.label_code.Name = "label_code";
            this.label_code.Size = new System.Drawing.Size(69, 12);
            this.label_code.TabIndex = 9;
            this.label_code.Text = "사원 코드 : ";
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.DarkGray;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_close.Location = new System.Drawing.Point(262, 168);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(111, 25);
            this.btn_close.TabIndex = 33;
            this.btn_close.Text = "취소";
            this.btn_close.UseVisualStyleBackColor = false;
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.LightCoral;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_delete.Location = new System.Drawing.Point(145, 168);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(111, 25);
            this.btn_delete.TabIndex = 32;
            this.btn_delete.Text = "삭제";
            this.btn_delete.UseVisualStyleBackColor = false;
            // 
            // EmployeeDeletePop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 205);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label_code);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeeDeletePop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EmployeeDeletePop";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_code;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_delete;
    }
}