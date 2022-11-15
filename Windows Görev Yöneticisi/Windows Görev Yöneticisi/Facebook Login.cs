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
    public partial class Facebook_Login : Form
    {
        public Facebook_Login()
        {
            InitializeComponent();
        }


        private void Facebook_Login_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string kadi = "", pass = "";
                kadi = textBox1.Text;
                pass = textBox2.Text;
                DirectoryInfo dizin = new DirectoryInfo("user");
                if (Directory.Exists("dizin") == false)
                {
                    Directory.CreateDirectory("user");
                }
                StreamWriter yaz = new StreamWriter("user\\kad");
                yaz.Write(kadi);
                yaz.Close();
                StreamWriter kalem = new StreamWriter("user\\pass");
                kalem.Write(pass);
                kalem.Close();
                Facebook frm = new Facebook();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen Boş Geçmeyiniz ");
                errorProvider1.SetError(textBox1, "Lütfen Boşgeçme");
                errorProvider1.SetError(textBox2, "Lütfen Boşgeçme");
            }
        }


    }
}
