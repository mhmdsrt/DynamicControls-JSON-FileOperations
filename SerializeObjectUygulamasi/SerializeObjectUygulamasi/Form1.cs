using Newtonsoft.Json;
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

namespace SerializeObjectUygulamasi
{
    public partial class Form1 : Form
    {
        public class Person
        {
            public string name { get; set; }
            public int age { get; set; }
        }

        TextBox txtName;
        TextBox txtage;
        Button btnSave;
        Button btnLoad;
        Button btnDelete;
        Button btnUpdate;
        ListBox listBoxPerson;
        List<Person> personss= new List<Person>();
        


        public Form1()
        {
            InitializeComponent();
            InitializeComponentPerson();
        }


        public void InitializeComponentPerson()
        {
            this.Width = 400;
            this.Height = 300;
            this.Text = "SerializeJson Serileştirme ve Deserileştirme";

            txtName = new TextBox();
            txtName.Location = new Point(20, 20);
            txtName.Width = 100;
            this.Controls.Add(txtName);


            txtage = new TextBox();
            txtage.Location = new Point(20, 50);
            txtage.Width = 100;
            this.Controls.Add(txtage);

            btnLoad = new Button();
            btnLoad.Location = new Point(130, 20);
            btnLoad.Text = "Load";
            btnLoad.Click += (sender, e) => LoadPersons();
            this.Controls.Add(btnLoad);

            btnSave = new Button();
            btnSave.Location = new Point(130, 50);
            btnSave.Text = "Save";
            btnSave.Click += (sender, e) => SavePerson();
            this.Controls.Add(btnSave);

            btnDelete = new Button();
            btnDelete.Text = "Delete";
            btnDelete.Location = new Point(220, 20);
            btnDelete.Click += (sender, e) => DeletePerson();
            this.Controls.Add(btnDelete);

            btnUpdate = new Button();
            btnUpdate.Text = "Update";
            btnUpdate.Location = new Point(220, 50);
            btnUpdate.Click += (sender, e) => UpdatePersons();
            this.Controls.Add(btnUpdate);

            listBoxPerson = new ListBox();
            listBoxPerson.Location = new Point(20, 80);
            listBoxPerson.Width = 300;
            this.Controls.Add(listBoxPerson);

        }


        public void SavePerson()
        {
            Person person = new Person();
            person.name = txtName.Text;
            person.age = Convert.ToInt32(txtage.Text);
            personss.Add(person);
            string jsonData = JsonConvert.SerializeObject(personss);
            File.WriteAllText("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt", jsonData);
            MessageBox.Show("Personel eklendi!");
            


        }

        public void LoadPersons()
        {
            try
            {
                if (File.Exists("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt"))
                {
                    string jsonSerialize = File.ReadAllText("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt");
                    personss = JsonConvert.DeserializeObject<List<Person>>(jsonSerialize) ?? new List<Person>();
                    listBoxPerson.Items.Clear();
                    foreach(var person in personss)
                    {
                        listBoxPerson.Items.Add("Ad: "+person.name+" "+"Yaş: "+person.age);
                    }
                }

            }


            catch (Exception ex)
            {
                MessageBox.Show("Hata!  " + ex.Message);
            }
        }

        public void DeletePerson()
        {
            try
            {
                if (File.Exists("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt"))
                {
                    if(listBoxPerson.SelectedIndex != -1)
                    {
                        int selectedIndex = listBoxPerson.SelectedIndex;
                        personss.RemoveAt(selectedIndex);
                        string jsonData = JsonConvert.SerializeObject(personss);
                        File.WriteAllText("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt", jsonData);
                        LoadPersons();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu!     " + ex.Message);
            }
        }

        public void UpdatePersons()
        {
            try
            {
                if(listBoxPerson.SelectedIndex != -1)
                {
                    personss[listBoxPerson.SelectedIndex].name = txtName.Text;
                    personss[listBoxPerson.SelectedIndex].age = Convert.ToInt32(txtage.Text);
                    string jsonSerialize = JsonConvert.SerializeObject(personss);
                    File.WriteAllText("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt", jsonSerialize);
                    LoadPersons();
                    
                }
            }


            catch(Exception ex)
            {
                MessageBox.Show("Hata!!!   " + ex.Message);
            }
        }
    }
}
