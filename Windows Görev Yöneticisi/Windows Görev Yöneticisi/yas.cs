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
    public partial class yas : Form
    {
        public yas()
        {
            InitializeComponent();
        }

        private void yas_Load(object sender, EventArgs e)
        {
            bugun.Text = Convert.ToString(DateTime.Now.Year + " " + DateTime.Now.Month + " " + DateTime.Now.Day);
        }
        void uygula()
        {
            try
            {
                int pazartesi = 0;
                int salı = 0;
                int çarşamba = 0;
                int perşembe = 0;
                int cuma = 0;
                int cumartesi = 0;
                int pazar = 0;
                int toplam = 0;
                bugun.Text = Convert.ToString(DateTime.Now.Year + " " + DateTime.Now.Month + " " + DateTime.Now.Day);
                DateTime buguni = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                int[] dtarih = new int[3];
                dtarih[0] = int.Parse(yil.Text);
                dtarih[1] = int.Parse(ay.Text);
                dtarih[2] = int.Parse(gun.Text);
                DateTime dttarih = new DateTime(dtarih[0], dtarih[1], dtarih[2]);
                TimeSpan fark = buguni - dttarih;
                for (int i = 0; i < fark.Days; i++)
                {
                    DateTime yedek = dttarih.AddDays(i);
                    if (yedek.DayOfWeek == DayOfWeek.Monday)
                    {
                        pazartesi++;
                    }
                    else if (yedek.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        salı++;
                    }
                    else if (yedek.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        çarşamba++;
                    }
                    else if (yedek.DayOfWeek == DayOfWeek.Thursday)
                    {
                        perşembe++;
                    }
                    else if (yedek.DayOfWeek == DayOfWeek.Friday)
                    {
                        cuma++;
                    }
                    else if (yedek.DayOfWeek == DayOfWeek.Saturday)
                    {
                        cumartesi++;
                    }
                    else if (yedek.DayOfWeek == DayOfWeek.Sunday)
                    {
                        pazar++;
                    }
                    toplam++;
                }
                listBox1.Items.Clear();
                listBox1.Items.Add("Yaşadığın Pazartesi Günleri: " + pazartesi.ToString());
                listBox1.Items.Add("Yaşadığın Salı Günleri: " + salı.ToString());
                listBox1.Items.Add("Yaşadığın Çarşamba Günleri: " + çarşamba.ToString());
                listBox1.Items.Add("Yaşadığın Perşembe Günleri: " + perşembe.ToString());
                listBox1.Items.Add("Yaşadığın Cuma Günleri: " + cuma.ToString());
                listBox1.Items.Add("Yaşadığın Cumartesi Günleri: " + cumartesi.ToString());
                listBox1.Items.Add("Yaşadığın Pazar Günleri: " + pazar.ToString());
                listBox1.Items.Add("Yaşadığın Tüm Günler: " + toplam.ToString());
                listBox1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : "+ex.Message.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uygula();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Visible = false;
            bugun.Text = "";
            yil.Text = "";
            ay.Text = "";
            gun.Text = "";
        }
    }
}
