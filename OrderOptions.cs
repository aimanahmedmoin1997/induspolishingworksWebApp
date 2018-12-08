using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indus_Polishing_System
{
    public partial class OrderOptions : Form
    {
        public OrderOptions()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked == true)
            {
                PrevOrder po = new PrevOrder();
                po.Show();
                this.Close();
            }
            else if (radioButton2.Checked== true)
            {
                PrevOrderEmployee poe = new PrevOrderEmployee();
                poe.Show();
                this.Close();
            }
            
            //groupBox1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewCustomer nc = new NewCustomer();
            nc.Show();
            //this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewOrder no = new NewOrder();
            no.Show();
            //this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mm = new MainMenu();
            mm.Show();
        }
    }
}
