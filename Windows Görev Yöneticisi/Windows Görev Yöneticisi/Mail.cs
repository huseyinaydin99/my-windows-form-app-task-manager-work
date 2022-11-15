using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Windows_Görev_Yöneticisi
{
    public partial class Mail : Form
    {
        public Mail()
        {
            InitializeComponent();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "Mail Gönder");
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button2, "Formu Temizle");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gonder();
        }
        void gonder()
        {
            if(kadi.Text!="" && pass.Text!="" && kisi.Text!="" && konu.Text!="" && msg.Text!="")
            {
                try
                {
                    SmtpClient smtp = new SmtpClient();
                    smtp.Credentials = new NetworkCredential(kadi.Text,pass.Text);
                    if(comboBox1.Text=="gmail")
                    {
                        smtp.Host = "smtp.gmail.com";
                    }
                    else if (comboBox1.Text == "hotmail")
                    {
                        smtp.Host = "smtp.hotmail.com";
                    }
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(kadi.Text);
                    mail.To.Add(kisi.Text);
                    mail.Subject = konu.Text;
                    mail.Body = msg.Text;
                    smtp.Send(mail);
                    MessageBox.Show("Mail başarı ile "+kisi.Text+" adresine gönderildi");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Mail gönderilemedi: "+ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Lütfen Boş Geçme");
            }
        }

        private void Mail_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kadi.Text = "";
            pass.Text = "";
            kisi.Text = "";
            konu.Text = "";
            msg.Text = "";
        }

       
    }
}
