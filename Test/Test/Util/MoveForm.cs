using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.Util
{
    public partial class MoveForm : Form
    {
        public MoveForm()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.DarkSlateGray; // MoveForm 배경을 빨강이 아닌 아무색이나 변경. 테두리로 보일 색입니다

            this.panel1.BackColor = System.Drawing.Color.Red; // panel1 배경을 빨강으로 설정합니다

            this.panel1.Location = new System.Drawing.Point(6, 6); // Location을 6,6으로 설정합니다

            this.panel1.Size = new System.Drawing.Size(848, 452); // MoveForm 크기보다 12,12 작게 설정합니다 860, 464

            this.TransparencyKey = System.Drawing.Color.Red; //MoveForm 투명색깔을 빨강으로 설정합니다
            
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        }
    }
}
