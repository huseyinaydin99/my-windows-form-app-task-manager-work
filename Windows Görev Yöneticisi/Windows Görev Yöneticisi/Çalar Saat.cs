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
    public partial class Çalar_Saat : Form
    {
        public Çalar_Saat()
        {
            InitializeComponent();
        }
        string path = "";
        string ayar = "";
        private void Çalar_Saat_Load(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo dizin = new DirectoryInfo("ses");
                FileInfo[] dosyalar = dizin.GetFiles();
                comboBox1.Items.AddRange(dosyalar);
            }
            catch
            {
                MessageBox.Show("Ses Dizinine Erişilemiyor Lütfen Programı Tekrar Yükleyiniz.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToLongTimeString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName.ToString();
                textBox1.Text = path;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ayar = path;
            MessageBox.Show("Zil sesi ayarlandı.");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            path = comboBox1.Text;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            MessageBox.Show("Çalar saat kuruldu. " + dateTimePicker1.Text + "'da çalacak.");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            caldır();
        }
        void caldır()
        {
            if (label7.Text == dateTimePicker1.Text)
            {
                axWindowsMediaPlayer1.settings.volume = 100;
                axWindowsMediaPlayer1.URL = ayar;
                timer2.Enabled = false;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ayar = "ses\\" + comboBox1.Text;
            MessageBox.Show("Zil sesi ayarlandı.");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = 100;
            axWindowsMediaPlayer1.URL = textBox1.Text;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = 100;
            axWindowsMediaPlayer1.URL = "ses\\"+comboBox1.Text;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = 0;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = 0;
        }

       

        
    }
}
