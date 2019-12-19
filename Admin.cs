using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
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
        bool prosmotrmast = false;
        bool prosmotrmat = false;

        private void button1_Click(object sender, EventArgs e)
        {
            global.conn.Close();
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void добавитьМастераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            global.dob = 1;
            DobavMaster frm = new DobavMaster();
            this.Hide();
            frm.Show();
        }

        //просмотр мастеров
        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;//просмотр
            if (!prosmotrmast)
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
            prosmotrmast = true;
            //удаление
            button2.Visible = true;
            //редактирование
            button3.Visible = true;
            global.conn.Close();
        }
        //измененеи
        private void button3_Click(object sender, EventArgs e)
        {
            global.dob = 0;
            DobavMaster frm = new DobavMaster();
            int RowNum = dataGridView1.CurrentRow.Index;
            
            global.Master_ID= (int)dataGridView1[0, RowNum].Value;
            frm.textBox3.Text = dataGridView1[1, RowNum].Value.ToString();
            frm.textBox4.Text = dataGridView1[2, RowNum].Value.ToString();
            frm.textBox5.Text = dataGridView1[3, RowNum].Value.ToString();
            frm.textBox6.Text = dataGridView1[4, RowNum].Value.ToString();
            this.Hide();
            frm.Show();
        }
        //удаление
        private void button2_Click(object sender, EventArgs e)
        {
            string zapros = "";
            global.conn.Open();
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            zapros += "delete from Master where Master_ID = " + global.Master_ID + "; ";
            SqlCommand command = new SqlCommand(zapros, global.conn);
            SqlDataReader reader = command.ExecuteReader();
            global.conn.Close();
            zapros = "";
            MessageBox.Show("Изменения внесены успешно");
        }

        private void просмотрToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int i = 0;//просмотр
            if (!prosmotrmat)
            {
                for (i = 0; i < 3; i++)
                {
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                }
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "Название";
                dataGridView1.Columns[2].HeaderText = "Остаток";
          

                string query = @"SELECT * FROM Material";
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
                    i++;
                }
                reader.Close();
            }
            prosmotrmat = true;
            global.conn.Close();
        }
        //закупка
        private void закупкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zakupka frm = new Zakupka();
            this.Hide();
            frm.Show();
        }

        private void списаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Spisanie frm = new Spisanie();
            this.Hide();
            frm.Show();
        }
        private void остаткиМатериаловToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            int i = 0;//просмотр
            if (!prosmotrmat)
            {
                for (i = 0; i < 3; i++)
                {
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                }
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "Название";
                dataGridView1.Columns[2].HeaderText = "Остаток";


                string query = @"SELECT * FROM Material";
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
                    i++;
                }
                reader.Close();
            }
            prosmotrmat = true;
            global.conn.Close();
        }
        //печать отчета 
        private void button4_Click(object sender, EventArgs e)
        {
            GridPrintDocument doc = new GridPrintDocument(this.dataGridView1,
                        this.dataGridView1.Font, true);
            doc.DocumentName = "Preview Test";

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.ClientSize = new Size(400, 300);
            printPreviewDialog.Location = new Point(29, 29);
            printPreviewDialog.Name = "Print Preview Dialog";
            printPreviewDialog.UseAntiAlias = true;
            printPreviewDialog.Document = doc;
            printPreviewDialog.ShowDialog();
            doc.Dispose();
            doc = null;
        }
    }
}
