using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Görev_Yöneticisi
{
    public partial class sp : Form
    {
        public Bitmap btm = new Bitmap("a.png");
        public Rectangle sınır = new Rectangle(0, 0, 500, 234);
        public float sayac = 0;
        public sp()
        {
            InitializeComponent();
        }

        private void sp_Load(object sender, EventArgs e)
        {
            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(btm, sınır, 0, 0, sınır.Width, sınır.Height, GraphicsUnit.Pixel);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = 10;
            label1.Text = "%10";
            sayac += 0.03f;
            progressBar1.Value=20;
            label1.Text = "%20";
            this.Opacity = sayac;
            if (sayac > 2.0)
            {
                timer1.Enabled = false;
                timer2.Enabled = true;
                progressBar1.Value= 40;
                label1.Text = "%40";
                progressBar1.Value = 85;
                label1.Text = "%85";
                System.Threading.Thread.Sleep(80);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = 100;
            label1.Text = "%100";
            sayac -= 0.03f;
            this.Opacity = sayac;
            if (this.Opacity==0.0f)
            {
                this.Close();
            }
        }
    }
}
