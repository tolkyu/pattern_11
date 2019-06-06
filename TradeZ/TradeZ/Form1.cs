using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TradeZ
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        Stock stock = new Stock();
        Random rnd = new Random();
        List<Client> clients = new List<Client>();


        public Form1()
        {
            InitializeComponent();
            timer.Interval = 10000;
            timer.Tick += Timer_Tick;
            timer.Start();
            comboBox1.DataSource = clients;
            comboBox1.DisplayMember = "Login";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            stock.BTCCourse = rnd.Next(8000, 8600);
            stock.Notify();
            label9.Text = stock.BTCCourse.ToString();
            ShowClientInfo();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double tmp = 0;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("You need to enter name!");
                return;
            }
            Client client = new Client();
            client.Login = textBox1.Text;
            if (double.TryParse(textBox2.Text, out tmp))
            {
                client.BTC = tmp;
            }
            else
            {
                MessageBox.Show("You need to enter summary of BTC!");
                return;
            }
            if (double.TryParse(textBox3.Text, out tmp))
            {
                client.USD = tmp;
            }
            else
            {
                MessageBox.Show("You need to enter summary of USD!");
                return;
            }
            if (double.TryParse(textBox4.Text, out tmp))
            {
                client.CourseForSell = tmp;
            }
            else
            {
                MessageBox.Show("You need to enter course for sell!");
                return;
            }
            if (double.TryParse(textBox5.Text, out tmp))
            {
                client.SummForBuy = tmp;
            }
            else
            {
                MessageBox.Show("You need to enter summary for buy!");
                return;
            }
            if (double.TryParse(textBox6.Text, out tmp))
            {
                client.CourseForBuy = tmp;
            }
            else
            {
                MessageBox.Show("You need to enter course for buy!");
                return;
            }
            if (double.TryParse(textBox7.Text, out tmp))
            {
                client.SummForSell = tmp;
            }
            else
            {
                MessageBox.Show("You need to enter summary for sell!");
                return;
            }

            clients.Add(client);
            stock.AddObserver(client);
            UpdateBinding();
        }
        void UpdateBinding()
        {
            comboBox1.DataSource = null;
            comboBox1.DataSource = clients;
            comboBox1.DisplayMember = "Login";

        }

        void ShowClientInfo()
        {
            if (comboBox1.SelectedIndex != -1)
            {
                Client client = comboBox1.SelectedItem as Client;
                textBox1.Text = client.Login;
                textBox2.Text = client.BTC.ToString();
                textBox3.Text = client.USD.ToString();
                textBox4.Text = client.CourseForBuy.ToString();
                textBox5.Text = client.SummForBuy.ToString();
                textBox6.Text = client.CourseForSell.ToString();
                textBox7.Text = client.SummForSell.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowClientInfo();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                var clients = comboBox1.DataSource as List<Client>;
                clients.Remove(comboBox1.SelectedItem as Client);
                comboBox1.DataSource = null;
                comboBox1.DataSource = clients;
                this.comboBox1.DisplayMember = "Login";
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            {
                Client client = comboBox1.SelectedItem as Client;
                double tmp = 0;
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("You need to enter name!");
                    return;
                }
                client.Login = textBox1.Text;
                if (double.TryParse(textBox2.Text, out tmp))
                {
                    client.BTC = tmp;
                }
                else
                {
                    MessageBox.Show("You need to enter summary of BTC!");
                    return;
                }
                if (double.TryParse(textBox3.Text, out tmp))
                {
                    client.USD = tmp;
                }
                else
                {
                    MessageBox.Show("You need to enter summary of USD!");
                    return;
                }
                if (double.TryParse(textBox4.Text, out tmp))
                {
                    client.CourseForBuy = tmp;
                }
                else
                {
                    MessageBox.Show("You need to enter course for buy!");
                    return;
                }
                if (double.TryParse(textBox5.Text, out tmp))
                {
                    client.CourseForSell = tmp;
                }
                else
                {
                    MessageBox.Show("You need to enter summary for sale!");
                    return;
                }
                if (double.TryParse(textBox6.Text, out tmp))
                {
                    client.SummForBuy = tmp;
                }
                else
                {
                    MessageBox.Show("You need to enter summary for buy");
                    return;
                }
                if (double.TryParse(textBox7.Text, out tmp))
                {
                    client.SummForSell = tmp;
                }
                else
                {
                    MessageBox.Show("You need to enter summary for sale");
                    return;
                }
                clients.Remove(client);
                clients.Add(client);
                stock.RemoveObserver(client);
                stock.AddObserver(client);
                UpdateBinding();
            }
        }
    }
}
