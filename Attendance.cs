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
    public partial class Attendance : Form
    {
        private SqlConnection conn;
        public Attendance()
        {
            InitializeComponent();
            string q = "Data Source=HP-PC;Initial Catalog=IndusPolishing;Integrated Security=True";
            conn = new SqlConnection(q);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into Attendance(Employees_EmployeeId,CheckInDate,CheckInTime)values(" + textBox1.Text + ",convert(DATE,GETDATE()),convert(Time,GETDATE()))";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Checked In");
            }
            catch (Exception)
            {
                MessageBox.Show("Already Check In");
            }
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select Employees_EmployeeId, convert(DATE,CheckInDate), CheckInTime from Attendance where Employees_EmployeeId=" + textBox1.Text + " and CheckInDate=CONVERT(date,GETDATE())";
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    listBox1.Items.Add("Employee ID:   "+read[0]);
                    listBox1.Items.Add("Date:          "+read[1]);
                    listBox1.Items.Add("Check-In Time: "+read[2]);
                }
                read.Close();                
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to show Attendance");
            }
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update Attendance set CheckOutDate= GETDATE(),CheckOutTime=GETDATE() where CheckInDate=CONVERT(DATE, GETDATE()) and Employees_EmployeeId=" + textBox1.Text;
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Checked Out");
            }
            catch (Exception)
            {
                MessageBox.Show("Not Checked In");
            }
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update Attendance set TotalTime= convert(varchar(20),DATEDIFF(HOUR,checkintime,checkouttime)) where CheckInDate=CONVERT(DATE, GETDATE()) and Employees_EmployeeId=" + textBox1.Text;
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Checked Out");
            }
            catch (Exception)
            {
                MessageBox.Show("Not Checked In");
            }
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update Attendance set TotalWage= TotalTime*250 where CheckInDate=CONVERT(DATE, GETDATE()) and Employees_EmployeeId=" + textBox1.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Checked Out");
            }
            catch (Exception)
            {
                MessageBox.Show("Not Checked In");
            }
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from Attendance where Employees_EmployeeId=" + textBox1.Text + " and CheckInDate=CONVERT(date,GETDATE())";
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    listBox1.Items.Add("Employee ID:            " + read[0]);
                    listBox1.Items.Add("Date:                   " + read[1]);
                    listBox1.Items.Add("Check-In Time:          " + read[5]);
                    listBox1.Items.Add("Check-Out Time:         " + read[6]);
                    listBox1.Items.Add("Total Time:             " + read[3]);
                    listBox1.Items.Add("Total Wage (PKR) Today: " + read[4]);

                }
                read.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to show Attendance");
            }
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mm = new MainMenu();
            mm.Show();
        }
    }
}
