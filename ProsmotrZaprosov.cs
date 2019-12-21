using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Salon
{
    public partial class ProsmotrZaprosov : Form
    {
        public ProsmotrZaprosov()
        {
            InitializeComponent();
        }

        private void ProsmotrZaprosov_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            global.conn.Open();
            string zapros = "select date_nach,date_konec,podtverd from Otpusk, Master where Master.Master_ID = Otpusk.Master_ID and login='"+global.login+"'";
            SqlCommand cmd = new SqlCommand(zapros, global.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            for (int c = 0; c < 3; c++)
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            }
            dataGridView1.Columns[0].HeaderText = "Начало";
            dataGridView1.Columns[1].HeaderText = "Конец";
            dataGridView1.Columns[2].HeaderText = "Статус";
            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = reader[0];
                dataGridView1[1, i].Value = reader[1];
                if (!(bool)reader[2]) dataGridView1[2, i].Value = "Ожидается";
                else dataGridView1[2, i].Value = "Подтвержден";
                i++;
            }

            global.conn.Close();
        }
    }
}
