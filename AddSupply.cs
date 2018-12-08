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
    public partial class AddSupply : Form
    {
        private SqlConnection conn;
        public AddSupply()
        {
            InitializeComponent();
            string q = "Data Source=HP-PC;Initial Catalog=IndusPolishing;Integrated Security=True";
            conn = new SqlConnection(q);
            conn.Open();
        }

        private void AddSupply_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select supplytype from supplies";
            cmd.CommandType = CommandType.Text;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox2.Items.Add(rd[0]);
            }
            rd.Close();

            if (textBox1.Text.Length == 0)
            {
                comboBox1.Items.Clear();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = conn;
                cmd1.CommandText = "Select idvendors from vendors";
                cmd1.CommandType = CommandType.Text;
                SqlDataReader rd1 = cmd1.ExecuteReader();
                while (rd1.Read())
                {
                    comboBox1.Items.Add(rd1[0]);
                }
                rd1.Close();
                /*
                textBox1.Clear();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "Select vendorname from vendors where idvendors=" + comboBox1.Text;
                cmd2.CommandType = CommandType.Text;
                SqlDataReader rd2 = cmd2.ExecuteReader();
                while (rd2.Read())
                {
                    textBox1.Text = rd2.GetString(1).ToString();
                }
                rd2.Close();*/
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            NewVendor nv = new NewVendor();
            nv.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                comboBox1.Items.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select idvendors from vendors where vendorname like '"+textBox1.Text+"%'";
                cmd.CommandType = CommandType.Text;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBox1.Items.Add(rd[0]);
                }
                rd.Close();
            }
            else
            {
                comboBox1.Items.Clear();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = conn;
                cmd1.CommandText = "Select idvendors from vendors";
                cmd1.CommandType = CommandType.Text;
                SqlDataReader rd1 = cmd1.ExecuteReader();
                while (rd1.Read())
                {
                    comboBox1.Items.Add(rd1[0]);
                }
                rd1.Close();
                /*
                textBox1.Clear();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "Select vendorname from vendors where idvendors=" + comboBox1.Text;
                cmd2.CommandType = CommandType.Text;
                SqlDataReader rd2 = cmd2.ExecuteReader();
                while (rd2.Read())
                {
                    textBox1.Text = rd2.GetString(1).ToString();
                }
                rd2.Close();*/
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {/*
            textBox1.Clear();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "Select vendorname from vendors where idvendors=" + comboBox1.Text;
            cmd2.CommandType = CommandType.Text;
            SqlDataReader rd2 = cmd2.ExecuteReader();
            while (rd2.Read())
            {
                textBox1.Text = rd2.GetString(0).ToString();
            }
            rd2.Close();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text.Length == 0 || comboBox2.Text.Length == 0 || dateTimePicker1.Value > DateTime.Today) { MessageBox.Show("Incomplete or Invalid Information", "Error"); }
                else
                {
                    string supid = null;

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = conn;
                    cmd1.CommandText = "Select idsupplies from supplies where supplytype='" + comboBox2.Text + "'";
                    cmd1.CommandType = CommandType.Text;
                    SqlDataReader rd1 = cmd1.ExecuteReader();
                    while (rd1.Read())
                    {
                        supid = rd1[0].ToString();
                    }
                    rd1.Close();
                    /*
                    if (comboBox2.Text == "Thinner") { supid = "1"; }
                    if (comboBox2.Text == "Varnish") { supid = "2"; }
                    if (comboBox2.Text == "Lacquer") { supid = "3"; }
                    if (comboBox2.Text == "Thinner") { supid = "4"; }
                    if (comboBox2.Text == "Thinner") { supid = "5"; }
                    if (comboBox2.Text == "Thinner") { supid = "6"; }
                    if (comboBox2.Text == "Thinner") { supid = "7"; }
                    if (comboBox2.Text == "Thinner") { supid = "8"; }*/
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandText = "insert into Vendors_has_Supplies(Vendors_idVendors,Supplies_idSupplies,QuantityBought,Amount,SupplyDate)values(" + comboBox1.Text + "," + supid + "," + textBox2.Text + "," + textBox3.Text + ",'" + dateTimePicker1.Value + "')";
                    cmd2.CommandType = CommandType.Text;
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Supply from Vendor Added", "Success");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Supply Addition Failed", "Failed");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            AddSupply adsup = new AddSupply();
            adsup.Show();
        }
    }
}
