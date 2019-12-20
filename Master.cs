using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salon
{
    public partial class Master : Form
    {
        public Master()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            global.conn.Close();
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void Master_Load(object sender, EventArgs e)
        {
            string zapros = "";
            global.conn.Open();
            zapros = "select Klient,Mesto,Data,Gotovnost from Zacaz, Master where Zacaz.Master_ID = Master.Master_ID and Master.login = '"+global.login+"'";
            SqlCommand cmd = new SqlCommand(zapros, global.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = reader[0];
                dataGridView1[1, i].Value = reader[1];
                dataGridView1[2, i].Value = reader[2];
                if ((bool)reader[3])
                {
                    dataGridView1[3, i].Value = "Выполнен";
                    dataGridView1.Rows[i].Visible = false;
                }
                else dataGridView1[3, i].Value = "Ожидание";
                i++;
            }


            global.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int RowNum = dataGridView1.CurrentRow.Index;
           

            string zapros = "update Zacaz set Gotovnost = 1 where Data = '"+dataGridView1[2,RowNum].Value+"' and Mesto = '"+dataGridView1[1,RowNum].Value+"'";
            global.conn.Open();
            SqlCommand cmd = new SqlCommand(zapros, global.conn);
            cmd.ExecuteNonQuery();
            zapros = "select Klient,Mesto,Data,Gotovnost from Zacaz, Master where Zacaz.Master_ID = Master.Master_ID and Master.login = '" + global.login + "'";
            cmd = new SqlCommand(zapros, global.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();
            int i = 0;
            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = reader[0];
                dataGridView1[1, i].Value = reader[1];
                dataGridView1[2, i].Value = reader[2];
                if ((bool)reader[3])
                {
                    dataGridView1[3, i].Value = "Выполнен";
                    dataGridView1.Rows[i].Visible = false;
                }
                else dataGridView1[3, i].Value = "Ожидание";
                i++;
            }
            global.conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Spisanie frm = new Spisanie();
            this.Hide();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Otpusk frm = new Otpusk();
            frm.ShowDialog();
        }
    }
}
