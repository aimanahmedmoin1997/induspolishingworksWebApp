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
    public partial class NewEmployee : Form
    {
        private SqlConnection conn;
        public NewEmployee()
        {
            InitializeComponent();
            string q = "Data Source=HP-PC;Initial Catalog=IndusPolishing;Integrated Security=True";
            conn = new SqlConnection(q);
            conn.Open();
        }

        private void NewEmployee_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select employeeid from employees";
            cmd.CommandType = CommandType.Text;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd[0]);
            }
            rd.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Adds search = new Adds();
            search.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            empid.Items.Clear();
            string rep;
            if (comboBox1.Text.Length == 0)
            {
                rep = "NULL";
            }
            else
            {
                rep = comboBox1.Text;
            }
            if (fname.Text.Length != 0 && lname.Text.Length != 0 && addr.Text.Length != 0 && cnic.Text.Length != 0 && cont.Text.Length != 0 && emercon.Text.Length != 0 && wage.Text.Length != 0 && hireDate.Value <= DateTime.Today)
            {
                string query = "Insert into Employees(FirstName,Lastname,HireDate,Address,CNIC,MobileNumber,EmergencyContact,Wage,ReportsTo)values('" + fname.Text + "','" + lname.Text + "','" + hireDate.Value + "','" + addr.Text + "','" + cnic.Text + "','" + cont.Text + "','" + emercon.Text + "'," + wage.Text + "," + rep + ")";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                //cmd.ExecuteReader();
                MessageBox.Show("Accepted");
                string emp = "select EmployeeId from Employees where FirstName='" + fname.Text + "' and Lastname='" + lname.Text + "' and CNIC='" + cnic.Text + "'";
                SqlCommand empl = new SqlCommand(emp, conn);
                SqlDataReader rd = empl.ExecuteReader();
                while (rd.Read() == true)
                {
                    empid.Items.Add(rd[0]);
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
