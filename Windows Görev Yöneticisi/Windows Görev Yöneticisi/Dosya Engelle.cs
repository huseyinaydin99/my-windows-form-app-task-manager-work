using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.Security.Principal;
using System.IO;

namespace Windows_Görev_Yöneticisi
{
    public partial class Dosya_Engelle : Form
    {
        public Dosya_Engelle()
        {
            InitializeComponent();
        }

        private void Dosya_Engelle_Load(object sender, EventArgs e)
        {
            label1.Text += SystemInformation.UserName;
        }
        public static void GuvenlikEkle(string DosyaAdi, string hesap,FileSystemRights rights, AccessControlType controlType)
        {


            //İstenilen dosyanın erişim izini durumuna bakıyoruz.
            FileSecurity fSecurity = File.GetAccessControl(DosyaAdi);

            //İstenilen rolu atıyor (yalnızca okuma vs) ve erişim iznini belirliyor.
            fSecurity.AddAccessRule(new FileSystemAccessRule(hesap,
                rights, controlType));

            // Ve ayarlarımızı dosyaya uyguluyoruz.
            File.SetAccessControl(DosyaAdi, fSecurity);

        }
        //Dosyaya ait erişim bilgisini siler.
        public static void ErisimSil(string DosyaAdi, string hesap,FileSystemRights rights, AccessControlType controlType)
        {

            //İstenilen dosyanın erişim izini durumuna bakıyoruz.
            FileSecurity fSecurity = File.GetAccessControl(DosyaAdi);

            //İstenilen rolu  (yalnızca okuma vs) ve belirtilen erişim iznini siliyor.
            fSecurity.RemoveAccessRule(new FileSystemAccessRule(hesap,
                rights, controlType));

            // Ve ayarlarımızı dosyaya uyguluyoruz.
            File.SetAccessControl(DosyaAdi, fSecurity);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Windowstaki aktif hesap bilgilerini alıyoruz.
            NTAccount account = new NTAccount(Environment.MachineName, SystemInformation.UserName);
            try
            {
                //Dosyaya erişim özellini Deny olarak atıyoruz.
                GuvenlikEkle(folderBrowserDialog1.SelectedPath, account.Value, FileSystemRights.ReadData, AccessControlType.Deny);
            }
            catch
            {
                MessageBox.Show("Hata Oluştu");
            }
            //
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Windowstaki aktif hesap bilgilerini alıyoruz.
            NTAccount account = new NTAccount(Environment.MachineName, SystemInformation.UserName);
            try
            {
                //Deny olan erişimi silip onun yerine Allow erişimi atayıyoruz.
                ErisimSil(folderBrowserDialog1.SelectedPath, account.Value, FileSystemRights.ReadData, AccessControlType.Deny);
                GuvenlikEkle(folderBrowserDialog1.SelectedPath, account.Value, FileSystemRights.ReadData, AccessControlType.Allow);
            }
            catch
            {
                MessageBox.Show("Hata oluştu", "Klasor İşlemleri 1.0");
            }
        }
    }
}
