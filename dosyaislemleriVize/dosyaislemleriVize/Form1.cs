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

namespace dosyaislemleriVize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            formBilesenleriniBaslat();
        }

        private void formBilesenleriniBaslat()
        {
            TextBox textbox1 = new TextBox();
            textbox1.Multiline = true;  // Multi-> Çoklu , Line -> Satır     
            textbox1.ScrollBars = ScrollBars.Vertical; //ScrollBars -> Kaydırma Çubuğu, Vertical -> Dikey
            textbox1.Dock = DockStyle.Fill;  // Dock -> Yerleştirmek
            this.Controls.Add(textbox1);


            Button createBtn = new Button();
            createBtn.Dock = DockStyle.Top;
            createBtn.Text = "Dosya Olustur";
            createBtn.Click += (sender, e) => CreateFile("C:\\Users\\Mimy\\Desktop\\deneme.txt", textbox1.Text);
            this.Controls.Add(createBtn);

            Button deleteBtn = new Button();
            deleteBtn.Dock = DockStyle.Top;
            deleteBtn.Text = "Dosyayı Sil";
            deleteBtn.Click += (sender, e) => DeleteFile("C:\\Users\\Mimy\\Desktop\\deneme.txt");
            this.Controls.Add(deleteBtn);


            Button readBtn = new Button();
            readBtn.Text = "Dosyayı Oku";
            readBtn.Dock = DockStyle.Top;
            deleteBtn.Click += (sender, e) => ReadFile("C:\\Users\\Mimy\\Desktop\\deneme.txt");
            this.Controls.Add(readBtn);


        }

        

                /*
                 using bloğu dosya yazma işlemi tamamlandığında StreamWriter örneğini otomatik olarak kapatır 
                 ve kaynakları serbest bırakır. Bu sayede programın daha iyi performans göstermesi 
                 ve kaynakların verimli bir şekilde kullanılması sağlanır.
                */

        private void CreateFile(string FilePath,string textbox1)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    writer.Write(textbox1);
                }
                MessageBox.Show("Dosya olusturuldu!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya olusturulamadı!"+ ex.Message);
                
            }


        }

        private string ReadFile(string FilePath)
        {

            try
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {

                    return reader.ReadToEnd(); // Dosyanın tamamını oku ve döndür

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya okunamadı!" + ex.Message);
                return string.Empty; // Empty -> Boş

            }
        }

        private void DeleteFile(string FilePath)
        {
            try
            {
                if (File.Exists(FilePath)) // Exists -> Var, Var olmak
                {
                    File.Delete(FilePath);
                    MessageBox.Show("Dosya silindi!");
                }
                else
                {
                    MessageBox.Show("Dosya bulunamadı!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata! " + ex.Message);

            }
        }

    }
}
