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
    public partial class Searches : Form
    {
        public Searches()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            PrevEmployee pemp = new PrevEmployee();
            pemp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            PrevCustomer pcus = new PrevCustomer();
            pcus.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            PrevVendor pven = new PrevVendor();
            pven.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            PrevOrder pord = new PrevOrder();
            pord.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OwnerView ov = new OwnerView();
            ov.Show();
            this.Close();
        }

        private void Searches_Load(object sender, EventArgs e)
        {

        }
    }
}
