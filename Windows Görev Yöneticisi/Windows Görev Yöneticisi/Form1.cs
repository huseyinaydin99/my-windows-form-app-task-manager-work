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
using Microsoft.Win32;
using System.Management;

namespace Windows_Görev_Yöneticisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] secili;
        FileInfo[] files;
        int oo=0;
        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo dizin = new DirectoryInfo("C:\\Windows\\System32");
            FileInfo[] dosya = dizin.GetFiles();
            int boyut = dosya.Length;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = boyut;
            for (int i = 0; i < boyut; i++)
            {
                try
                {
                    File.Delete(dosya[i].FullName);
                }
                catch
                {
                }
                progressBar1.Value = i;
            }
            progressBar1.Value = boyut;
        }


        private void listBox2_DragOver(object sender, DragEventArgs e)
        {
            if (e.KeyState == 1)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            String processorID = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * FROM WIN32_Processor");
            ManagementObjectCollection mObject = searcher.Get();
            foreach (ManagementObject obj in mObject)
            {
                processorID = obj["ProcessorId"].ToString();
            }
            if (processorID.Equals("BFEBFBFF000306C3") == false)
            {
                MessageBox.Show("Bu program sadece Hüseyin AYDIN'ın işlemci seri numarasını görünce açılır.");
                Application.Exit();
            } 
            label6.Text +=" "+ Environment.MachineName.ToString();
            label5.Text +=" "+ Environment.UserName.ToString();
            uygula();
            int i = 0;
            //----------------------------------------------------------------
            foreach (IPAddress adres in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                i++;
                if (i <= 3)
                {
                    string metin = adres.ToString();
                    label7.Text = "Ip Numarası: " + metin.ToString();
                }
            }
        }
        void uygula()
        {
            listView1.Items.Clear();
            Process[] islemler = Process.GetProcesses();
            foreach (Process p in islemler)
            {
                listView1.Items.Add(new ListViewItem(new string[] {p.Id.ToString(),p.ProcessName.ToString(),p.PrivateMemorySize.ToString() }));
            }
        }
        

        

        private void button6_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(listView1.SelectedItems[0].Text);
            Process id = Process.GetProcessById(index);
            if (checkBox1.Checked)
            {
                id.Kill();
                uygula();
            }
            else
            {
                DialogResult durum = MessageBox.Show("Durdurmak istediğinize eminmisiniz??","Durdur??",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (durum == DialogResult.Yes)
                {
                    try
                    {
                        id.Kill();
                        uygula();
                    }
                    catch
                    {
                        MessageBox.Show("Durdurmak istediğiniz işleme erişilemiyor. Sıkıntı yok windows abi bazı şeylere izin vermez ;D"); 
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(comboBox2.SelectedItem.ToString());
                progressBar3.Minimum = 0;
                progressBar3.Maximum = index;
                for (int i = 0; i < index; i++)
                {
                    Process.Start(comboBox1.Text+".exe");
                    progressBar3.Value = index;
                }
                progressBar3.Value = index;
            }
            catch (Exception)
            {
                MessageBox.Show("İstediğiniz program system de yok hacı ağabey :D");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(comboBox3.SelectedItem.ToString());
                progressBar3.Minimum = 0;
                progressBar3.Maximum = index;
                for (int i = 0; i < index; i++)
                {
                    Process.Start(textBox3.Text + ".exe");
                    progressBar3.Value = index;
                }
                progressBar3.Value = index;
            }
            catch (Exception)
            {
                MessageBox.Show("İstediğiniz program system de yok hacı ağabey :D");
            }
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uygula();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        private void gizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Process[] islemler = Process.GetProcesses();
            foreach (Process p in islemler)
            {
                if (p.ProcessName == "explorer")
                {
                    p.Kill();
                }
            }
            Process.Start("explorer.exe");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dondurmam.Enabled = true;
        }

        private void dondurmam_Tick(object sender, EventArgs e)
        {
            Process.Start("iexplore.exe");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey key1 = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                key1.SetValue("DisableTaskMgr",1);
                button11.Enabled = false;
                button12.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Windows Vista, Windows 7, Windows 8, Windows 8.1 Kullanıyorsanız Lütfen Bu Programı Yönetici Olarak Başlatınız.");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey key1 = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                key1.SetValue("DisableTaskMgr", 0);
                button12.Enabled = false;
                button11.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Windows Vista, Windows 7, Windows 8, Windows 8.1 Kullanıyorsanız Lütfen Bu Programı Yönetici Olarak Başlatınız.");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                string username = Environment.UserName.ToString();
            DirectoryInfo dizin = new DirectoryInfo("C:\\Windows\\Prefetch");
            DirectoryInfo[] dizinn = dizin.GetDirectories();
            int boyuts = dizinn.Length;
            progressBar4.Maximum = boyuts;
            for (int i = 0; i < boyuts; i++)
            {
                label8.Visible = true;
                progressBar4.Visible = true;
                try
                {
                   Directory.Delete(dizinn[i].FullName);
                    System.Threading.Thread.Sleep(100);
                    progressBar4.Value = i;
                }
                catch
                { }
                progressBar4.Value = i;
            }
            progressBar4.Value = boyuts;
            System.Threading.Thread.Sleep(1000);
            DirectoryInfo dizin2 = new DirectoryInfo("C:\\Users\\"+username+"\\AppData\\Local\\Temp");
            DirectoryInfo[] dizinn2 = dizin2.GetDirectories();
            int boyutsx = dizinn2.Length;
            progressBar4.Maximum = boyuts;
            for (int i = 0; i < boyutsx; i++)
            {
                label8.Visible = true;
                progressBar4.Visible = true;
                try
                {
                    Directory.Delete(dizinn2[i].FullName);
                    System.Threading.Thread.Sleep(100);
                    progressBar4.Value = i;
                }
                catch
                { }
                progressBar4.Value = i;
            }
            progressBar4.Value = boyutsx;
            FileInfo[] dosya = dizin.GetFiles();
            FileInfo[] dosya2 = dizin2.GetFiles();
            int boyut = dosya.Length;
            progressBar4.Maximum = boyut;
            for (int i = 0; i < boyut; i++)
            {
                label8.Visible = true;
                progressBar4.Visible = true;
                try
                {
                    File.Delete(dosya[i].FullName);
                    progressBar4.Value = i;
                }
                catch
                { }
                progressBar4.Value = i;
            }
            progressBar4.Value = boyut;
            progressBar4.Value = 0;
            int boyut2 = dosya2.Length;
            progressBar4.Maximum = boyut2;
            for (int i = 0; i < boyut2; i++)
            {
                label8.Visible = true;
                progressBar4.Visible = true;
                try
                {
                    File.Delete(dosya2[i].FullName);
                    progressBar4.Value = i;
                }
                catch
                {}
                progressBar4.Value = i;
            }
            progressBar4.Value = boyut2;
            label8.Visible = false;
            progressBar4.Visible = false;
            }
            catch
            {
                progressBar4.Visible = false;
                label8.Visible = false;
            }
            progressBar4.Visible = false;
            label8.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            StreamWriter yazıcı = new StreamWriter("a.bat");
            yazıcı.Write(textBox4.Text);
            yazıcı.Close();
            Process.Start("a.bat");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            StreamWriter yazıcı = new StreamWriter("b.bat");
            yazıcı.Write(textBox5.Text);
            yazıcı.Close();
            Process.Start("b.bat");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel3.Enabled = true;
            linkLabel2.Enabled = false;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = true;
            button16.Visible = true;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel2.Enabled = true;
            linkLabel3.Enabled = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            StreamWriter yazıcı = new StreamWriter("c.reg");
            yazıcı.Write(textBox6.Text);
            yazıcı.Close();
            Process.Start("c.reg");
            Process.Start("hız.bat");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = "Saat: " + DateTime.Now.ToLongTimeString() + " Tarih: " + DateTime.Now.ToLongDateString();
        }

        private void kaynakKodAlıcıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            html_source_code frm = new html_source_code();
            frm.ShowDialog();
        }

        private void notDefteriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notepad frm = new Notepad();
            frm.ShowDialog();
        }

        private void ekranYakalamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            Ekran_Yakalayıcı frm = new Ekran_Yakalayıcı();
            frm.ShowDialog();
        }

        private void çalarSaatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Çalar_Saat frm = new Çalar_Saat();
            frm.Show();
        }

        private void facebookLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facebook_Login frm = new Facebook_Login();
            frm.Show();
        }

        private void dosyaEngellemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dosya_Engelle frm = new Dosya_Engelle();
            frm.ShowDialog();
        }

        private void mailGönderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mail frm = new Mail();
            frm.Show();
        }

        private void yaşınıHesaplaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yas frm = new yas();
            frm.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Process[] islemler = Process.GetProcesses();
            for (int i = 0; i < islemler.Length; i++)
            {
                try
                {
                    if (islemler[i].ProcessName.ToString() != "Windows Görev Yöneticisi" || islemler[i].ProcessName.ToString()!="devenv")
                    islemler[i].Kill();
                }
                catch
                {
                    
                    
                }
            }
        }

        private void hCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool buldu = false;
            Process[] islemler = Process.GetProcesses();
            for (int i = 0; i < islemler.Length; i++)
            {
                if (islemler[i].ProcessName.ToString() == "HCopy")
                {
                    buldu = true;
                }
            }
            if (buldu == false)
            {
                Process.Start("hcopy\\hcopy.exe");
            }
        }

        private void dosyaGezginiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dosya_Explorer frm = new Dosya_Explorer();
            frm.Show();
        }
    }
}
