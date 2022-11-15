using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Windows_Görev_Yöneticisi
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string yol = openFileDialog1.FileName.ToString();
                StreamReader oku = new StreamReader(yol,Encoding.GetEncoding("utf-8"));
                textBox1.Text = oku.ReadToEnd();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string metin = textBox1.Text;
                string yol = saveFileDialog1.FileName.ToString();
                StreamWriter yaz = new StreamWriter(yol);
                yaz.Write(metin);
                yaz.Close();
                MessageBox.Show("Kaydedildi :D");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBox1.Font = fontDialog1.Font;
                }
                catch (Exception)
                {
                    MessageBox.Show("Lütfen başka bir font seçiniz. Sistem seçtiğiniz font yok.");
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                saydır();
            }
            catch
            {
            }
        }
        string saydır()
        {
            string deger = "Hello World";
            string boşsayi = "";
            string karaktersayi = "";
            string metin = textBox1.Text;
            int length = metin.Length;
            for (int i = 0; i < length; i++)
            {
                if (metin[i].ToString() == " ")
                {
                    boşsayi += metin[i].ToString();
                }
                else
                {
                    karaktersayi += metin[i].ToString();
                }
            }
            toolStripLabel1.Text = "Karakter Sayi : " + karaktersayi.Length.ToString();
            toolStripLabel2.Text = "Boşluk Sayısı : " + boşsayi.Length.ToString();
            return deger;
        }
    }
}
