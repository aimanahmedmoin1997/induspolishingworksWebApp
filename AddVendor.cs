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
    public partial class AddVendor : Form
    {
        private SqlConnection conn;
        public AddVendor()
        {
            InitializeComponent();
            string q = "Data Source=HP-PC;Initial Catalog=IndusPolishing;Integrated Security=True";
            conn = new SqlConnection(q);
            conn.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            NewVendor nv = new NewVendor();
            nv.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddVendor av = new AddVendor();
            av.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (venname.Text.Length != 0 && cont.Text.Length != 0)
            {
                string query = "Insert into Vendors(VendorName,ContactNumber)values('" + venname.Text + "','" + cont.Text + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Accepted");
                string cus = "select idVendors from Vendors where VendorName='" + venname.Text + "' and ContactNumber='" + cont.Text + "'";
                SqlCommand empl = new SqlCommand(cus, conn);
                SqlDataReader rd = empl.ExecuteReader();
                while (rd.Read() == true)
                {
                    listBox1.Items.Add(rd[0]);
                }
                rd.Close();
            }
            else
            {
                MessageBox.Show("Incomplete Information");
            }
        }
    }
}
