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

namespace OrderManagementUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeComponentOrderManagement();
        }

        Button btnLoadOrders;
        Button btnSaveOrder;
        Button deleteOrder;
        TextBox txtCustomerName;
        TextBox txtProductName;
        NumericUpDown numericQuantity;
        ListBox listBoxOrders;
        private void InitializeComponentOrderManagement()
        {
             btnLoadOrders = new Button();
            btnLoadOrders.Text = "LOAD";
            btnLoadOrders.Dock = DockStyle.Bottom;
            btnLoadOrders.Click += (sender, e) => LoadOrder();
            this.Controls.Add(btnLoadOrders);

             btnSaveOrder = new Button();
            btnSaveOrder.Text = "Save Order";
            btnSaveOrder.Dock = DockStyle.Bottom;
            btnSaveOrder.Click += (sender, e) => SaveOrder();
            this.Controls.Add(btnSaveOrder);

             deleteOrder = new Button();
            deleteOrder.Text = "Delete Order";
            deleteOrder.Dock = DockStyle.Bottom;
            deleteOrder.Click += (sender, e) => DeleteOrder();
            this.Controls.Add(deleteOrder);


             txtCustomerName = new TextBox();
            txtCustomerName.Dock = DockStyle.Bottom;
            SetPlaceHolder(txtCustomerName, "Customer Name"); // Placeholder -> Yer tutucu 
            this.Controls.Add(txtCustomerName);


             txtProductName = new TextBox();
            txtProductName.Dock = DockStyle.Bottom;
            SetPlaceHolder(txtProductName, "Product Name");
            this.Controls.Add(txtProductName);

             numericQuantity = new NumericUpDown();
            numericQuantity.Maximum = 1000;
            numericQuantity.Minimum = 0;
            numericQuantity.Dock = DockStyle.Bottom;
            this.Controls.Add(numericQuantity);

             listBoxOrders = new ListBox();
            listBoxOrders.Dock = DockStyle.Bottom;
            this.Controls.Add(listBoxOrders);

           
            

        }

        private void SetPlaceHolder(TextBox textbox, string placeHolderText)
        {
            /*  
              textbox.Click,textbox.Enter gibi eventlerde :
              textbox.Enter += (sender, e) => ifadesi Enter eventi her tetiklendiğinden
              => ifadesinden sonraki ifadeleri gerçekleştir anlamına geliyor.
            
             */


            textbox.Text = placeHolderText; // Placeholder -> Yer tutucu 
            textbox.ForeColor = System.Drawing.Color.Gray;
            textbox.Enter += (sender, e) =>  //TextBoxa her girildiğinde gerçekleşek olaylar aşağıdaki gibidir.
            {
                if (textbox.Text == placeHolderText)
                {
                    textbox.Text = "";
                    textbox.ForeColor = System.Drawing.Color.Black;
                }
            };
            textbox.Leave += (sender, e) => // Leave -> Ayrılmak ,Eğer texboxtan ayrılırsan aşadığıdakileri yap
            {
                if (string.IsNullOrEmpty(textbox.Text)) // IsNullOrEmpty -> Boşluksuz
                {
                    textbox.Text = placeHolderText;
                    textbox.ForeColor = System.Drawing.Color.Gray;
                }
            };
            
        }

        private void SaveOrder()
        {
            if(txtCustomerName.Text=="Customer Name" || txtProductName.Text=="Product Name")
            {
                MessageBox.Show("Lütfen tüm detayları doldurun!");
                return;          // döngüleri ve switch yapısını sonlardımak için "break;"deyimini kullanıyorduk.
                                 // return ile de metotları sonlandırıyoruz.
            }
            string orderInfo = "Müşteri adı: " + txtCustomerName.Text + " " +
                "Ürün adı: " + txtProductName.Text + " "
                + "Ürün Miktarı: " + numericQuantity.Value.ToString();
            File.AppendAllText("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt", orderInfo + Environment.NewLine);
            listBoxOrders.Items.Add(orderInfo);
        }
        
        private void DeleteOrder()
        {
            if(listBoxOrders.SelectedIndex != -1)
            {
                List<string> lines = new List<string>(File.ReadAllLines("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt"));
                lines.RemoveAt(listBoxOrders.SelectedIndex);
                File.WriteAllLines("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt", lines);
                LoadOrder();
            }
        }

        private void LoadOrder()
        {
            listBoxOrders.Items.Clear();
            if (File.Exists("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt"))
            {
                foreach(var item in File.ReadAllLines("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt"))
                {
                    listBoxOrders.Items.Add(item);
                }
            }
        }

        

    }
}
