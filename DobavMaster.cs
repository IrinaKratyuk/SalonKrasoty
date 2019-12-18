using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Salon
{
    public partial class DobavMaster : Form
    {
        public DobavMaster()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin frm = new Admin();
            this.Hide();
            frm.Show();
        }

        private void DobavMaster_Load(object sender, EventArgs e)
        {
            string spec;
            string query = @"SELECT * FROM Specializaciya";
            SqlCommand cmd = new SqlCommand(query, global.conn);
            global.conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
           int i = 0;
            while (reader.Read())
            {
                checkedListBox1.Items.Add(reader[1]);
            }
            reader.Close();
        }
    }
}
