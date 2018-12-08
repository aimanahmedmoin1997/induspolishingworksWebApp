using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Indus_Polishing_System
{
    public partial class PrevOrder : Form
    {
        private SqlConnection conn;
        public PrevOrder()
        {
            InitializeComponent();
            string q = "Data Source=HP-PC;Initial Catalog=IndusPolishing;Integrated Security=True";
            conn = new SqlConnection(q);
            conn.Open();
        }

        private void PrevOrder_Load(object sender, EventArgs e)
        {

        }

        private void fname_TextChanged(object sender, EventArgs e)
        {
            if (fname.Text.Length != 0 && lname.Text.Length != 0)
            {
                cusid.Text = null;
                cusid.Items.Clear();
                ordid.Items.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select customerID from customers where firstname='" + fname.Text + "' and lastname='" + lname.Text + "'";
                cmd.CommandType = CommandType.Text;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cusid.Items.Add(rd[0]);
                }
                rd.Close();
            }
            else if (fname.Text.Length != 0 && lname.Text.Length == 0)
            {
                cusid.Text = null;
                cusid.Items.Clear();
                ordid.Items.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select customerID from customers where firstname='" + fname.Text + "'";
                cmd.CommandType = CommandType.Text;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cusid.Items.Add(rd[0]);
                }
                rd.Close();
            }
        }

        private void lname_TextChanged(object sender, EventArgs e)
        {
            if (fname.Text.Length != 0 && lname.Text.Length != 0)
            {
                cusid.Text = null;
                cusid.Items.Clear();
                ordid.Items.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select customerID from customers where firstname='" + fname.Text + "' and lastname='" + lname.Text + "'";
                cmd.CommandType = CommandType.Text;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cusid.Items.Add(rd[0]);
                }
                rd.Close();
            }
            else if (fname.Text.Length == 0 && lname.Text.Length != 0)
            {
                cusid.Text = null;
                cusid.Items.Clear();
                ordid.Items.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select customerID from customers where lastname='" + lname.Text + "'";
                cmd.CommandType = CommandType.Text;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cusid.Items.Add(rd[0]);
                }
                rd.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mm = new MainMenu();
            mm.Show();
        }

        private void ordid_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ordid.Text.Length == 0)
                {
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Select customerid,companyname,(firstname+' '+lastname)name,phonenumber,address from customers where customerid=" + cusid.Text;
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        listBox1.Items.Add("CustomerID: " + rd[0]);
                        listBox1.Items.Add("Company Name: " + rd[1]);
                        listBox1.Items.Add("Customer Name: " + rd[2]);
                        listBox1.Items.Add("PhoneNumber: " + rd[3]);
                        listBox1.Items.Add("Address: " + rd[4]);
                        listBox1.Items.Add("-------------");
                    }
                    rd.Close();
                }
                else if (cusid.Text.Length != 0 && ordid.Text.Length != 0)
                {
                    listBox1.Items.Clear();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Select customerid,companyname,(firstname+' '+lastname)name,phonenumber,address from customers where customerid=" + cusid.Text;
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        listBox1.Items.Add("CustomerID: " + rd[0]);
                        listBox1.Items.Add("Company Name: " + rd[1]);
                        listBox1.Items.Add("Customer Name: " + rd[2]);
                        listBox1.Items.Add("PhoneNumber: " + rd[3]);
                        listBox1.Items.Add("Address: " + rd[4]);
                        listBox1.Items.Add("-------------");
                    }
                    rd.Close();
                    listBox2.Items.Clear();
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = conn;
                    cmd1.CommandText = "Select * from Orders where Orderid=" + ordid.Text;
                    SqlDataReader rd1 = cmd1.ExecuteReader();
                    while (rd1.Read())
                    {
                        listBox2.Items.Add("OrderID: " + rd1[0]);
                        listBox2.Items.Add("Order Date: " + rd1[2]);
                        listBox2.Items.Add("Weight: " + rd1[4]);
                        listBox2.Items.Add("Total Price: " + rd1[5]);
                        listBox2.Items.Add("-------------");
                    }
                    rd1.Close();

                }
                //cusid.Items.Clear();
                //ordid.Items.Clear();
            }
            catch(Exception)
            {
                MessageBox.Show("Insert Customer ID or/and Order ID");
            }
        }

        private void cusid_SelectedIndexChanged(object sender, EventArgs e)
        {
            ordid.Items.Clear();
            try
            {
                //ordid.Items.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select orderid from orders where Customers_CustomerID=" + cusid.Text;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ordid.Items.Add(rd[0]);
                }
                rd.Close();
            }
            catch (Exception) { MessageBox.Show("Error"); }
        }
    }
}
