using System;
using System.Windows.Forms;

namespace Salon
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void добавитьМастераToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
