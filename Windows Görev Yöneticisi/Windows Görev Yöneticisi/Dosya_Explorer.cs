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
    public partial class Dosya_Explorer : Form
    {
        public Dosya_Explorer()
        {
            InitializeComponent();
        }

        private void Dosya_Explorer_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            comboBox1.Items.AddRange(Directory.GetLogicalDrives());
            DirectoryInfo dizin = new DirectoryInfo(comboBox1.Text);
            DirectoryInfo[] dizinler = dizin.GetDirectories();
            FileInfo[]dosyalar = dizin.GetFiles();
            for (int i = 0; i < dizinler.Length; i++)
			{
			    listView1.Items.Add(dizinler[i].FullName.ToString(),0);
			}
            for (int i = 0; i < dosyalar.Length; i++)
			{
                listView1.Items.Add(dosyalar[i].FullName.ToString(),1);
			}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            DirectoryInfo dizin = new DirectoryInfo(comboBox1.Text);
            DirectoryInfo[] dizinler = dizin.GetDirectories();
            FileInfo[] dosyalar = dizin.GetFiles();
            for (int i = 0; i < dizinler.Length; i++)
            {
                listView1.Items.Add(dizinler[i].FullName.ToString(), 0);
            }
            for (int i = 0; i < dosyalar.Length; i++)
            {
                listView1.Items.Add(dosyalar[i].FullName.ToString(), 1);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string yol = listView1.SelectedItems[0].Text;
                if (File.Exists(yol))
                {
                    açToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    listView1.Items.Clear();
                    comboBox1.Text = yol;
                    DirectoryInfo dizin = new DirectoryInfo(comboBox1.Text);
                    DirectoryInfo[] dizinler = dizin.GetDirectories();
                    FileInfo[] dosyalar = dizin.GetFiles();
                    for (int i = 0; i < dizinler.Length; i++)
                    {
                        listView1.Items.Add(dizinler[i].FullName.ToString(), 0);
                    }
                    for (int i = 0; i < dosyalar.Length; i++)
                    {
                        listView1.Items.Add(dosyalar[i].FullName.ToString(), 1);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); button1_Click(sender, e); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string yol2 = "";
            string mesaj = "";
            string metin = comboBox1.Text;
            for (int i = metin.Length-1; i >=0 ; i--)
            {
                if (metin[i].ToString().Equals("\\") == true)
                {
                    for (int j = i; j >= 0; j--)
                    {
                        mesaj += metin[j].ToString();
                    }
                    break;
                }
            }
            for (int i = mesaj.Length-1; i >= 1; i--)
            {
                yol2 += mesaj[i].ToString();
            }
            if(yol2.Length<2 || yol2.Length<=2)
            {
                yol2 += "\\";
            }
            comboBox1.Text = yol2;
            DirectoryInfo dizin = new DirectoryInfo(comboBox1.Text);
            DirectoryInfo[] dizinler = dizin.GetDirectories();
            FileInfo[] dosyalar = dizin.GetFiles();
            for (int i = 0; i < dizinler.Length; i++)
            {
                listView1.Items.Add(dizinler[i].FullName.ToString(), 0);
            }
            for (int i = 0; i < dosyalar.Length; i++)
            {
                listView1.Items.Add(dosyalar[i].FullName.ToString(), 1);
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string metin = listView1.SelectedItems[0].Text;
            try
            {
                if (Directory.Exists(metin))
                {
                    DialogResult durum = MessageBox.Show(metin + " Klasöürünü silmek istediğinize eminmisiniz?", "Uyarı.!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (durum == DialogResult.Yes)
                    {
                        Directory.Delete(metin);
                        if (Directory.Exists(metin))
                            MessageBox.Show("Klasör Silinemedi");
                        else
                            MessageBox.Show("Dosya Silindi");
                    }
                }
                else if (File.Exists(metin))
                {
                    DialogResult durum = MessageBox.Show(metin + " Dosyasını silmek istediğinize eminmisiniz?", "Uyarı.!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (durum == DialogResult.Yes)
                    {
                        File.Delete(metin);
                        if (File.Exists(metin))
                            MessageBox.Show("Dosya Silinemedi");
                        else
                            MessageBox.Show("Dosya Silindi");
                    }
                }
                listView1.Items.Clear();
                DirectoryInfo dizin = new DirectoryInfo(comboBox1.Text);
                DirectoryInfo[] dizinler = dizin.GetDirectories();
                FileInfo[] dosyalar = dizin.GetFiles();
                for (int i = 0; i < dizinler.Length; i++)
                {
                    listView1.Items.Add(dizinler[i].FullName.ToString(), 0);
                }
                for (int i = 0; i < dosyalar.Length; i++)
                {
                    listView1.Items.Add(dosyalar[i].FullName.ToString(), 1);
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message.ToString()); }
            GC.Collect();
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string metin = listView1.SelectedItems[0].Text;
            try
            {
                System.Diagnostics.Process.Start(metin);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
