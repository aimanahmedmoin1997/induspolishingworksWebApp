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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text=="owner")
            {
                this.Close();
                OwnerView view = new OwnerView();
                view.Show();
                
                
            }
            else
            {
                MessageBox.Show("Incorrect Password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mm = new MainMenu();
            mm.Show();
        }
    }
}
