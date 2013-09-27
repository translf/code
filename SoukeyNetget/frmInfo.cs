using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


///���ܣ�MSN��Ϣ��ʽ�����Ѵ���
///���ʱ�䣺2009-3-2
///���ߣ�һ��
///�������⣺��
///�����ƻ�����
///˵������ 
///�汾��01.10.00
///�޶�����
namespace SoukeyNetget
{
    public partial class frmInfo : Form
    {
        //����ͣ��ʱ��Ϊ3��
        public int StayTime = 3000;
        public int m_widthMax=221;
        public int m_heightMax=92;
        public  bool IsShow = true;
        public int m_startForm = 0;

        public int startFrom
        {
            get { return m_startForm; }
            set 
            {
                if (value < 1)
                {
                    m_startForm = 0;
                }
                else
                {
                    m_startForm = value ;
                }
            }
        }

        public int WidthMax
        {
            get { return m_widthMax; }
            set { m_widthMax = value; }
        }

        public int HeightMax
        {
            get { return m_heightMax; }
            set { m_heightMax = value; }
        }

        public frmInfo()
        {
            InitializeComponent();
        }

        public void ScrollShow()
        {
            this.Width = m_widthMax;
            this.Height = 0;
            this.Show();
            this.timer1.Enabled = true;
        }

        private void ScrollUp()
        {
            if (Height < m_heightMax)
            {
                this.Height += 3;
                this.Location = new Point(this.Location.X, this.Location.Y - 3);
            }
            else
            {
                this.timer1.Enabled = false;
                this.timer2.Enabled = true;
            }
        }

        private void ScrollDown()
        {
            if (Height > 4)
            {
                this.Height -= 3;
                this.Location = new Point(this.Location.X, this.Location.Y + 3);
            }
            else
            {
                IsShow = false;
                this.timer3.Enabled = false;
                this.Close();
                this.Dispose();
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ScrollUp();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            timer3.Enabled = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            ScrollDown();
        }

        private void frmInfo_Load(object sender, EventArgs e)
        {

            this.Height = 0;
            Rectangle rScreen = Screen.GetWorkingArea(Screen.PrimaryScreen.Bounds);


            this.Location = new Point(rScreen.Width - m_widthMax - 3, rScreen.Height - (m_heightMax * m_startForm)-2);

            //WorkingAreaΪWindows����Ĺ�����
            this.timer2.Interval = StayTime;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            IsShow = false;
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}