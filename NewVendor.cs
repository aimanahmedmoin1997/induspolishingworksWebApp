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
    public partial class NewVendor : Form
    {
        public NewVendor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddVendor av = new AddVendor();
            av.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddSupply asup = new AddSupply();
            asup.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Adds ov = new Adds();
            ov.Show();
        }
    }
}
