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
    public partial class PrevVendor : Form
    {
        private SqlConnection conn;
        public PrevVendor()
        {
            InitializeComponent();
            string q = "Data Source=HP-PC;Initial Catalog=IndusPolishing;Integrated Security=True";
            conn = new SqlConnection(q);
            conn.Open();
        }

        private void PrevVendor_Load(object sender, EventArgs e)
        {

        }

        private void fname_TextChanged(object sender, EventArgs e)
        {
            empid.Text = null;
            empid.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from vendors where vendorname='" + fname.Text + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                empid.Items.Add(rd[0]);
            }
            rd.Close();
        }

        private void search_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select idvendors,vendorname,contactnumber from vendors where idVendors=" + empid.Text;
            cmd.CommandType = CommandType.Text;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                listBox1.Items.Add("Vendor ID: " + rd[0]);
                listBox1.Items.Add("Vendor Name: " + rd[1]);
                listBox1.Items.Add("Contact Number: " + rd[2]);
                //listBox1.Items.Add("Supply Type: " + rd[3]);
                //listBox1.Items.Add("Quantity: " + rd[4]);
                //listBox1.Items.Add("Amount: " + rd[5]);
                listBox1.Items.Add("-------------");
            }
            rd.Close();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
            Searches searches = new Searches();
            searches.Show();
        }

        private void empid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
