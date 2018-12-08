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
    public partial class PrevCustomer : Form
    {
        private SqlConnection conn;
        public PrevCustomer()
        {
            InitializeComponent();
            string q = "Data Source=HP-PC;Initial Catalog=IndusPolishing;Integrated Security=True";
            conn = new SqlConnection(q);
            conn.Open();
        }

        private void PrevCustomer_Load(object sender, EventArgs e)
        {
            
        }

        private void search_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select customerid,companyname,(firstname+' '+lastname)name,phonenumber,address from customers where customerid="+cusid.Text;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                listBox1.Items.Add("CustomerID: "+rd[0]);
                listBox1.Items.Add("Company Name: "+rd[1]);
                listBox1.Items.Add("Customer Name: "+rd[2]);
                listBox1.Items.Add("PhoneNumber: "+rd[3]);
                listBox1.Items.Add("Address: "+rd[4]);
                listBox1.Items.Add("-------------");
            }
            rd.Close();
        }

        private void cusid_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lname_TextChanged(object sender, EventArgs e)
        {
            if (fname.Text.Length!=0 && lname.Text.Length != 0)
            {
                cusid.Text = null;
                cusid.Items.Clear();
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
            else if(fname.Text.Length==0 && lname.Text.Length != 0)
            {
                cusid.Text = null;
                cusid.Items.Clear();
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

        private void fname_TextChanged(object sender, EventArgs e)
        {
            if (fname.Text.Length != 0 && lname.Text.Length != 0)
            {
                cusid.Text = null;
                cusid.Items.Clear();
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
            else if (fname.Text.Length!=0 && lname.Text.Length==0)
            {
                cusid.Text = null;
                cusid.Items.Clear();
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

        private void close_Click(object sender, EventArgs e)
        {
            Searches search = new Searches();
            search.Show();
            this.Close();
        }
    }
}
