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
    public partial class NewCustomer : Form
    {
        private SqlConnection conn;
        public NewCustomer()
        {
            InitializeComponent();
            string q = "Data Source=HP-PC;Initial Catalog=IndusPolishing;Integrated Security=True";
            conn = new SqlConnection(q);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if(fname.Text.Length != 0 && comname.Text.Length != 0 && pnum.Text.Length != 0 && add.Text.Length != 0)
            {
                if (lname.Text.Length == 0)
                {
                    lname.Text = null;
                }
                string query = "Insert into Customers(CompanyName,FirstName,LastName,PhoneNumber,Address)values('" + comname.Text + "','" + fname.Text + "','" + lname.Text + "','" + pnum.Text + "','" + add.Text + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Aceepted");
                string cus = "select customerID from Customers where FirstName='" + fname.Text + "' and Lastname='" + lname.Text + "' and companyname='" + comname.Text + "' and phonenumber=" + pnum.Text;
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
            
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //Adds search = new Adds();
            //search.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewCustomer nc = new NewCustomer();
            nc.Show();
            this.Close();
        }
    }
}
