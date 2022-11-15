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
    public partial class Ekran_Yakalayıcı : Form
    {
        public Graphics ressam;
        public Bitmap kagit;
        public Ekran_Yakalayıcı()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            timer1.Enabled = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Bitmap arka=new Bitmap("back.jpg");
            pictureBox1.Image = arka;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string yol = openFileDialog1.FileName.ToString();
                Bitmap arka = new Bitmap(yol);
                pictureBox1.Image = arka;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string yol = saveFileDialog1.FileName.ToString();
                pictureBox1.Image.Save(yol);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            kagit = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            ressam = Graphics.FromImage(kagit);
            ressam.CopyFromScreen(0, 0, 0, 0, new Size(kagit.Width, kagit.Height));
            pictureBox1.Image = kagit;
            System.Threading.Thread.Sleep(100);
            timer1.Enabled = false;
            this.Show();
        }
    }
}
