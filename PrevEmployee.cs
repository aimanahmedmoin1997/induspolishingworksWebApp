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
    public partial class PrevEmployee : Form
    {
        private SqlConnection conn;
        public PrevEmployee()
        {
            InitializeComponent();
            string q = "Data Source=HP-PC;Initial Catalog=IndusPolishing;Integrated Security=True";
            conn = new SqlConnection(q);
            conn.Open();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
            Searches searches = new Searches();
            searches.Show();
        }

        private void search_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from employees where employeeid=" + empid.Text;
            cmd.CommandType = CommandType.Text;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                listBox1.Items.Add("EmployeeID: " + rd[0]);
                listBox1.Items.Add("Reports To: " + rd[1]);
                listBox1.Items.Add("Employee Name: " + rd[2]+" "+rd[3]);
                listBox1.Items.Add("CNIC: " + rd[6]);
                listBox1.Items.Add("Address: " + rd[5]);
                listBox1.Items.Add("Mobile Number: " + rd[7]);
                listBox1.Items.Add("Emergency Contact: " + rd[8]);
                listBox1.Items.Add("Hire Date: " + rd[4]);
                listBox1.Items.Add("Wage: " + rd[9]);
                listBox1.Items.Add("-------------");
            }
            rd.Close();
        }

        private void fname_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lname_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lname_TextChanged_1(object sender, EventArgs e)
        {
            if (fname.Text.Length != 0 && lname.Text.Length != 0)
            {
                empid.Text = null;
                empid.Items.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select employeeid from employees where firstname='" + fname.Text + "' and lastname='" + lname.Text + "'";
                cmd.CommandType = CommandType.Text;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    empid.Items.Add(rd[0]);
                }
                rd.Close();
            }
            else if (fname.Text.Length == 0 && lname.Text.Length != 0)
            {
                empid.Text = null;
                empid.Items.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select employeeid from employees where lastname='" + lname.Text + "'";
                cmd.CommandType = CommandType.Text;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    empid.Items.Add(rd[0]);
                }
                rd.Close();
            }
        }

        private void fname_TextChanged_1(object sender, EventArgs e)
        {
            if (fname.Text.Length != 0 && lname.Text.Length != 0)
            {
                empid.Text = null;
                empid.Items.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select employeeid from employees where firstname='" + fname.Text + "' and lastname='" + lname.Text + "'";
                cmd.CommandType = CommandType.Text;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    empid.Items.Add(rd[0]);
                }
                rd.Close();
            }
            else if (fname.Text.Length != 0 && lname.Text.Length == 0)
            {
                empid.Text = null;
                empid.Items.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select employeeid from employees where firstname='" + fname.Text + "'";
                cmd.CommandType = CommandType.Text;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    empid.Items.Add(rd[0]);
                }
                rd.Close();
            }
        }
    }
}
