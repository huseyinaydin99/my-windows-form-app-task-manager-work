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
using System.Net;

namespace Windows_Görev_Yöneticisi
{
    public partial class html_source_code : Form
    {
        public html_source_code()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
            {
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
            }
            else if (toolStripTextBox1.Text == "")
            {
                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = false;
            }
            else
            {
                MessageBox.Show("None :D");
            }
        }

        private void html_source_code_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient wb = new WebClient();
                Stream oku = wb.OpenRead(toolStripTextBox1.Text);
                StreamReader reading = new StreamReader(oku);
                string code = reading.ReadToEnd();
                textBox1.Text = code;
            }
            catch
            {
                MessageBox.Show("Hata oluştu internet bağlantınızı ve yazdığınız adresin doğru olup olmadığını kontrol ediniz.");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter yazıcı = new StreamWriter(saveFileDialog1.FileName);
                yazıcı.Write(textBox1.Text);
                yazıcı.Close();
            }
        }
    }
}
