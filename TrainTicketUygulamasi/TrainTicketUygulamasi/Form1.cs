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

namespace TrainTicketUygulamasi  //Ticket -> Bilet, Train -> Tren
{
    public partial class Form1 : Form
    {
        Label lblName;
        TextBox txtName;
        Label lblDestination;   // Destination -> Hedef
        TextBox txtDestination;
        Label lblTravelDate;  // Travel -> Seyehat etmek
        DateTimePicker dtpTravelDate;
        Button btnSaveTicket;
        Button btnLoadTicket;
        Button btnDeleteTicet;
        ListBox listBoxTickets;

        public Form1()
        {
            InitializeComponent();
            InitializeComponentTrainTicket();
        }


        private void InitializeComponentTrainTicket()
        {
            lblName = new Label();
            lblName.Text = "Name";
            lblName.Dock = DockStyle.Bottom;
            this.Controls.Add(lblName);

            txtName = new TextBox();
            txtName.Dock = DockStyle.Bottom;
            this.Controls.Add(txtName);

            lblDestination = new Label();
            lblDestination.Text = "Destination";
            lblDestination.Dock = DockStyle.Bottom;
            this.Controls.Add(lblDestination);

            txtDestination = new TextBox();
            txtDestination.Dock = DockStyle.Bottom;
            this.Controls.Add(txtDestination);

            lblTravelDate = new Label();
            lblTravelDate.Text = " Select Travel Date";
            lblTravelDate.Dock = DockStyle.Bottom;
            this.Controls.Add(lblTravelDate);


            dtpTravelDate = new DateTimePicker();
            dtpTravelDate.Dock = DockStyle.Bottom;
            this.Controls.Add(dtpTravelDate);

            btnSaveTicket = new Button();
            btnSaveTicket.Text = "Save Ticket";
            btnSaveTicket.Dock = DockStyle.Bottom;
            btnSaveTicket.Click += (sender, e) => SaveTicket();
            this.Controls.Add(btnSaveTicket);


            btnLoadTicket = new Button();
            btnLoadTicket.Text = "Load Tickets";
            btnLoadTicket.Dock = DockStyle.Bottom;
            btnLoadTicket.Click += (sender, e) => LoadTicket();
            this.Controls.Add(btnLoadTicket);

            btnDeleteTicet = new Button();
            btnDeleteTicet.Text = "Delete Ticket";
            btnDeleteTicet.Dock = DockStyle.Bottom;
            btnDeleteTicet.Click += (sender, e) => DeleteTicket();
            this.Controls.Add(btnDeleteTicet);

            listBoxTickets = new ListBox();
            listBoxTickets.Dock = DockStyle.Bottom;
            this.Controls.Add(listBoxTickets);


        }

        private void SaveTicket()
        {
            string ticketInfo = "AD: " + txtName.Text + " " + "Gidilecek yer: " + txtDestination.Text +
                " " + "Seyehat Tarihi: " + dtpTravelDate.Text;
            listBoxTickets.Items.Add(ticketInfo);
            File.AppendAllText("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt", ticketInfo + Environment.NewLine); //Environment -> Çevre,Ortam
        }

        private void LoadTicket()
        {
            listBoxTickets.Items.Clear();

            try
            {
                if (File.Exists("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt"))
                {
                    foreach (string item in File.ReadAllLines("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt"))
                    {
                        listBoxTickets.Items.Add(item);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata"+ex.Message);
                
            }
        }

        private void DeleteTicket()
        {
            try
            {
                if (listBoxTickets.SelectedIndex != -1)
                {
                    List<string> ticketList = new List<string>(File.ReadAllLines("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt"));
                    ticketList.RemoveAt(listBoxTickets.SelectedIndex);
                    File.WriteAllLines("C:\\Users\\Mimy\\Desktop\\DenemeStockMarket.txt", ticketList);
                    LoadTicket();
                    
                }
            }
            catch (Exception ex )
            {

                MessageBox.Show("Hata " + ex.Message);
            }
        }


    }
}
