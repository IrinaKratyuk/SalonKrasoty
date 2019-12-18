using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Salon
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            global.conn.Close();
        }
        bool prosmotr = false;

        private void button1_Click(object sender, EventArgs e)
        {
            global.conn.Close();
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void добавитьМастераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DobavMaster frm = new DobavMaster();
            this.Hide();
            frm.Show();
        }

        //отображение в таблице

        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            // DataGridViewTextBoxColumn dgvAge = new DataGridViewTextBoxColumn();
            if (!prosmotr)
            {
                for (i = 0; i < 5; i++)
                {
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                }
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "Фамилия";
                dataGridView1.Columns[2].HeaderText = "Имя";
                dataGridView1.Columns[3].HeaderText = "Отчество";
                dataGridView1.Columns[4].HeaderText = "Опыт";
            
            string query = @"SELECT * FROM Master";
            SqlCommand cmd = new SqlCommand(query, global.conn);
            global.conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            i = 0;
            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = reader[0];
                dataGridView1[1, i].Value = reader[1];
                dataGridView1[2, i].Value = reader[2];
                dataGridView1[3, i].Value = reader[3];
                dataGridView1[4, i].Value = reader[4];
                i++;
            }
                reader.Close();
            }
            prosmotr = true;
            
            global.conn.Close();
        }
    }
}
