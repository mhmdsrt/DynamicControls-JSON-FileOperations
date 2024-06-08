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
using Newtonsoft.Json;

namespace AdvancedCrudUygulamasi
{
    public partial class Form1 : Form
    {
        public class Person
        {
            public string name { get; set; }
            public int age { get; set; }
        }

        TextBox txtName ;
        TextBox txtAge;
        Button btnSave;
        Button btnLoad;
        Button btnUpdate;
        Button btnDelete;
        ListBox listBoxPerson;
        List<Person> persons= new List<Person>();


        public Form1()
        {
            InitializeComponent();
            InitializeComponentAdvancedCrud();
           
        }

        private void InitializeComponentAdvancedCrud()
        {
            this.Width = 500;
            this.Height = 350;
            this.Text = "Advanced Crud with Serialization";

            txtName = new TextBox();
            txtName.Location = new Point(20, 20);
            txtName.Width = 200;
            this.Controls.Add(txtName);

            txtAge = new TextBox();
            txtAge.Location = new Point(20, 50);
            txtAge.Width = 200;
            this.Controls.Add(txtAge);

            btnSave = new Button();
            btnSave.Location = new Point(230, 20);
            btnSave.Text = "Save";
            btnSave.Click += (sender, e) => SaveLog();
            this.Controls.Add(btnSave);

            btnUpdate = new Button();
            btnUpdate.Text = "Update";
            btnUpdate.Location = new Point(230, 50);
            btnUpdate.Click += (sender, e) => UpdateListBox();
            this.Controls.Add(btnUpdate);

            btnDelete = new Button();
            btnDelete.Text = "Delete";
            btnDelete.Location = new Point(230, 80);
            this.Controls.Add(btnDelete);

            btnLoad = new Button();
            btnLoad.Text = "Load";
            btnLoad.Location = new Point(230, 110);
            this.Controls.Add(btnLoad);

            listBoxPerson = new ListBox();
            listBoxPerson.Location = new Point(20, 137);
            listBoxPerson.Width = 450;
            listBoxPerson.Height = 180;
            this.Controls.Add(listBoxPerson);


           
        }


        public void SaveLog()
        {
            Person person = new Person();
            person.name = txtName.Text;
            person.age = Convert.ToInt32(txtAge.Text);
            persons.Add(person);
            string jsonData = JsonConvert.SerializeObject(persons);
            File.WriteAllText("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt", jsonData);

        }

        public void UpdateListBox()
        {
            listBoxPerson.Items.Clear();
            string jsonData = File.ReadAllText("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt");
            persons = JsonConvert.DeserializeObject<List<Person>>(jsonData) ?? new List<Person>();

            foreach (var item in persons)
            {
                listBoxPerson.Items.Add(item.name+" "+item.age);
            }
        }

       
    }
}
