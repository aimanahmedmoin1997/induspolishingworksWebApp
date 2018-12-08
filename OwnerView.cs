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
    public partial class OwnerView : Form
    {
        public OwnerView()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            Searches search = new Searches();
            search.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Adds ad = new Adds();
            ad.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mm = new MainMenu();
            mm.Show();
        }
    }
}
