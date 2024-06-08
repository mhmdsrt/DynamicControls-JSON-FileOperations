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

namespace FileSinavaHazirlik1
{
    public partial class Form1 : Form
    {
        TextBox txtFilePath1;
        TextBox txtFilePath2;
        Button btnBrowse1;
        Button btnBrowse2;
        Button btnCompare;
        RichTextBox rictTxtBoxResult;

        public Form1()
        {
            InitializeComponent();
            InitializeComponentFileCompare();
        }

        public void InitializeComponentFileCompare()
        {
            this.Text = "Dosya karşılaştırma uygulaması";
            this.Size = new Size(600,400);

            txtFilePath1 = new TextBox();
            txtFilePath1.Location = new Point(20, 20);
            txtFilePath1.Width = 200;
            this.Controls.Add(txtFilePath1);

            txtFilePath2 = new TextBox();
            txtFilePath2.Location = new Point(20, 60);
            txtFilePath2.Width = 200;
            this.Controls.Add(txtFilePath2);

            btnBrowse1 = new Button();
            btnBrowse1.Text = "Gözat";
            btnBrowse1.Location = new Point(260, 20);
            btnBrowse1.Click += (sender, e) => Button1();
            this.Controls.Add(btnBrowse1);

            btnBrowse2 = new Button();
            btnBrowse2.Text = "Gözat";
            btnBrowse2.Location = new Point(260, 60);
            btnBrowse2.Click += (sender, e) => Button2();
            this.Controls.Add(btnBrowse2);

            btnCompare = new Button();
            btnCompare.Text = "Karşılaştır";
            btnCompare.Location = new Point(73, 90);
            btnCompare.Click += (sender, e) => ButtonCompare();
            this.Controls.Add(btnCompare);

            rictTxtBoxResult = new RichTextBox();
            rictTxtBoxResult.Location = new Point(20, 120);
            rictTxtBoxResult.Width = 400;
            rictTxtBoxResult.Height = 200;
            this.Controls.Add(rictTxtBoxResult);
        }

        public void Button1()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath1.Text = openFileDialog.FileName;
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir dosya adı giriniz!");
            }
        }

        public void Button2()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath2.Text = openFileDialog.FileName;
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir dosya adı giriniz!");
            }
        }


        public void ButtonCompare()
        {
            string contentFile1 = File.ReadAllText(txtFilePath1.Text);
            string contentFile2 = File.ReadAllText(txtFilePath2.Text);

            if(File.Exists(txtFilePath1.Text) && File.Exists(txtFilePath2.Text))
            {
                if (contentFile1 == contentFile2)
                {
                    MessageBox.Show("Dosyanın içerikleri aynı :)))))");
                    rictTxtBoxResult.Text = contentFile1 +"\n"+"Dosya İçerikleri aynıdır :)";
                }

                else
                {
                    MessageBox.Show("Dosyanın içerikleri aynı değil!");
                    rictTxtBoxResult.Text =  "Dosya İçerikleri aynıdı değildir :(";
                }
            }

            else
            {
                MessageBox.Show("Dosya bulunamadı!");
            }
        }
    }
}
