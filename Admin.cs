using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Salon
{
    public partial class Admin : Form
    {
        int menu = 0;
        public Admin()
        {
            InitializeComponent();
            global.conn.Close();
        }
        //назад
        private void button1_Click(object sender, EventArgs e)
        {
            global.conn.Close();
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void добавитьМастераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            global.dob = 1;
            DobavMaster frm = new DobavMaster();
            this.Hide();
            frm.Show();
        }

        //просмотр мастеров
        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu = 2;
            button4.Visible = false;
            button5.Visible = false;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            int i = 0;
                for (i = 0; i < 6; i++)
                {
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                }
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "Фамилия";
                dataGridView1.Columns[2].HeaderText = "Имя";
                dataGridView1.Columns[3].HeaderText = "Отчество";
                dataGridView1.Columns[4].HeaderText = "Опыт";
                dataGridView1.Columns[5].HeaderText = "Логин";
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
                dataGridView1[5, i].Value = reader[5];
                i++;
            }
                reader.Close();
            //удаление
            button2.Visible = true;
            //редактирование
            button3.Visible = true;
            global.conn.Close();
        }
        //изменение заказао(1) и мастеров(2)
        private void button3_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button5.Visible = false;
            if (menu == 2)//изменение мастеров
            {
                global.dob = 0;
                DobavMaster frm = new DobavMaster();
                int RowNum = dataGridView1.CurrentRow.Index;

                global.Master_ID = (int)dataGridView1[0, RowNum].Value;
                frm.textBox3.Text = dataGridView1[1, RowNum].Value.ToString();
                frm.textBox4.Text = dataGridView1[2, RowNum].Value.ToString();
                frm.textBox5.Text = dataGridView1[3, RowNum].Value.ToString();
                frm.textBox6.Text = dataGridView1[4, RowNum].Value.ToString();
                this.Hide();
                frm.Show();
            }
            else if(menu==1)//изменение заказов
            {
                int RowNum = dataGridView1.CurrentRow.Index;
                if ((string)dataGridView1[3, RowNum].Value == "Ожидание")
                {
                    string zapros = "";
                    global.conn.Open();
                    SqlCommand cmd = new SqlCommand(zapros, global.conn);
                    //заполнение листа местами
                    zapros = "select mesto1,mesto2,mesto3,mesto4 from Grafik, Master where Grafik.Master_ID = (select Master_ID From Master where Familia='" + dataGridView1[4, RowNum].Value + "') and _date='" + dataGridView1[2, RowNum].Value + "'";
                    cmd = new SqlCommand(zapros, global.conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        mesto obj = new mesto();
                        obj.mest1 = (bool)reader[0];
                        obj.mest2 = (bool)reader[1];
                        obj.mest3 = (bool)reader[2];
                        obj.mest4 = (bool)reader[3];
                        mests.Add(obj);
                    }
                    reader.Close();

                    //удаление выделенного заказа
                    zapros = "delete from Zacaz where Master_ID = (select Master_ID From Master where Familia='" + dataGridView1[4, RowNum].Value + "')and Klient='" + dataGridView1[0, RowNum].Value + "' and Mesto='" + dataGridView1[1, RowNum].Value + "' and Data='" + dataGridView1[2, RowNum].Value + "'and Gotovnost=0";
                    cmd = new SqlCommand(zapros, global.conn);
                    cmd.ExecuteNonQuery();

                    //обновление в графике
                    if ((string)dataGridView1[1, RowNum].Value == "9:00-11:00") mests[0].mest1 = false;
                    if ((string)dataGridView1[1, RowNum].Value == "11:00-13:00") mests[0].mest2 = false;
                    if ((string)dataGridView1[1, RowNum].Value == "14:00-16:00") mests[0].mest3 = false;
                    if ((string)dataGridView1[1, RowNum].Value == "16:00-18:00") mests[0].mest4 = false;
                   
                    zapros = "update Grafik set mesto1 = '" + Convert.ToInt32(mests[0].mest1) + "', mesto2 = '" + Convert.ToInt32(mests[0].mest2) + "',    mesto3 = '" + Convert.ToInt32(mests[0].mest3) + "',    mesto4 = '" + Convert.ToInt32(mests[0].mest4) + "' where(select Master_ID from Master where Familia = '" + (string)dataGridView1[4, RowNum].Value + "') = Master_ID and _date = '" + dataGridView1[2, RowNum].Value + "'";
                    cmd = new SqlCommand(zapros, global.conn);
                    cmd.ExecuteNonQuery();
                    global.conn.Close();
                    zapros = "";
                    NewZakaz frm = new NewZakaz();
                    frm.textBox1.Text = (string)dataGridView1[0, RowNum].Value;
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    MessageBox.Show("Заказ отменен, создайте новый заказ!");
                    

                    this.Hide();
                    frm.Show();

                }
                else
                {
                    MessageBox.Show("Заказ выполнен и не может быть изменен!");
                }
            }
        }
        //удаление мастера или заказа
        List<mesto> mests = new List<mesto>();
        private void button2_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button5.Visible = false;
            if (menu == 2)//удаление мастеров
            {
                string zapros = "";
                int RowNum = dataGridView1.CurrentRow.Index;
                global.Master_ID = (int)dataGridView1[0, RowNum].Value;
                global.conn.Open();
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                zapros += "delete from Master where Master_ID = " + global.Master_ID + "; ";
                SqlCommand command = new SqlCommand(zapros, global.conn);
                SqlDataReader reader = command.ExecuteReader();
                global.conn.Close();
                zapros = "";
                MessageBox.Show("Изменения внесены успешно");
            }
            else if(menu==1)//удаление заказа
            {
                int RowNum = dataGridView1.CurrentRow.Index;
                if ((string)dataGridView1[3, RowNum].Value == "Ожидание")
                {
                    string zapros = "";
                    global.conn.Open();
                    SqlCommand cmd = new SqlCommand(zapros, global.conn);
                    //заполнение листа местами
                    zapros = "select mesto1,mesto2,mesto3,mesto4 from Grafik, Master where Grafik.Master_ID = (select Master_ID From Master where Familia='" + dataGridView1[4, RowNum].Value + "') and _date='" + dataGridView1[2, RowNum].Value + "'";
                   
                    cmd = new SqlCommand(zapros, global.conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        mesto obj = new mesto();
                        obj.mest1 = (bool)reader[0];
                        obj.mest2 = (bool)reader[1];
                        obj.mest3 = (bool)reader[2];
                        obj.mest4 = (bool)reader[3];
                        mests.Add(obj);
                    }
                    reader.Close();

                    //удаление выделенного заказа
                    zapros = "delete from Zacaz where Master_ID = (select Master_ID From Master where Familia='" + dataGridView1[4, RowNum].Value + "')and Klient='" + dataGridView1[0, RowNum].Value + "' and Mesto='" + dataGridView1[1, RowNum].Value + "' and Data='" + dataGridView1[2, RowNum].Value + "'and Gotovnost=0";
                    cmd = new SqlCommand(zapros, global.conn);
                    cmd.ExecuteNonQuery();

                    //обновление в графике
                    if ((string)dataGridView1[1, RowNum].Value == "9:00-11:00") mests[0].mest1 = false;
                    if ((string)dataGridView1[1, RowNum].Value == "11:00-13:00") mests[0].mest2 = false;
                    if ((string)dataGridView1[1, RowNum].Value == "14:00-16:00") mests[0].mest3 = false;
                    if ((string)dataGridView1[1, RowNum].Value == "16:00-18:00") mests[0].mest4 = false;
                  
                    zapros = "update Grafik set mesto1 = '" + Convert.ToInt32(mests[0].mest1) + "', mesto2 = '" + Convert.ToInt32(mests[0].mest2) + "',    mesto3 = '" + Convert.ToInt32(mests[0].mest3) + "',    mesto4 = '" + Convert.ToInt32(mests[0].mest4) + "' where(select Master_ID from Master where Familia = '" + (string)dataGridView1[4, RowNum].Value + "') = Master_ID and _date = '" + dataGridView1[2, RowNum].Value + "'";
                    cmd = new SqlCommand(zapros, global.conn);
                    cmd.ExecuteNonQuery();
                    global.conn.Close();
                    zapros = "";
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    MessageBox.Show("Заказ отменен");
                }
                else
                {
                    MessageBox.Show("Заказ выполнен и не может быть отменен!");
                }
                
            }
        }
        //просмотр материалов
        private void просмотрToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            button5.Visible = false;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            int i = 0;//просмотр

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
       
            global.conn.Close();
        }
        //закупка
        private void закупкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            Zakupka frm = new Zakupka();
            this.Hide();
            frm.Show();
        }

        private void списаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            Spisanie frm = new Spisanie();
            frm.ShowDialog();
        }     
        //печать отчета 
        private void button4_Click(object sender, EventArgs e)
        {
                button2.Visible = false;
                button3.Visible = false;
                button5.Visible = false;
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
        //создание заказа
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            NewZakaz frm = new NewZakaz();
            this.Hide();
            frm.Show();
        }
        //просмотр запросов на отпуск
        private void подтверждениеЗапросовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = true;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            global.conn.Open();
            string zapros = "select Familia, date_nach,date_konec,podtverd from Otpusk, Master where Master.Master_ID = Otpusk.Master_ID";
            SqlCommand cmd = new SqlCommand(zapros, global.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            for (int c = 0; c < 4; c++)
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            }
            dataGridView1.Columns[0].HeaderText = "Фамилия";
            dataGridView1.Columns[1].HeaderText = "Начало";
            dataGridView1.Columns[2].HeaderText = "Конец";
            dataGridView1.Columns[3].HeaderText = "Статус";
            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = reader[0];
                dataGridView1[1, i].Value = reader[1];
                dataGridView1[2, i].Value = reader[2];
                if (!(bool)reader[3]) dataGridView1[3, i].Value = "Ожидается";
                else dataGridView1[3, i].Value = "Подтвержден";

                i++;
            }

            global.conn.Close();
        }
        //подтверждение отпусков
        private void button5_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            int RowNum = dataGridView1.CurrentRow.Index;
            global.conn.Open();
            string zapros = "update Otpusk set podtverd = 1 where Master_ID = (select Master_ID from Master where Familia = '"+dataGridView1[0,RowNum].Value+ "');update Grafik set Vihodnoi = 1 where Grafik.Master_ID = (select Master_ID from Master where Familia = '"+dataGridView1[0,RowNum].Value+"') and _date between '"+ ((DateTime)dataGridView1[1, RowNum].Value).ToString("dd.MM.yyyy") + "' and '"+ ((DateTime)dataGridView1[2, RowNum].Value).ToString("dd.MM.yyyy") + "'; ";
            SqlCommand cmd = new SqlCommand(zapros,global.conn);
            cmd.ExecuteNonQuery();
            global.conn.Close();
            dataGridView1.Columns.Clear();
            подтверждениеЗапросовToolStripMenuItem_Click(sender, e);
        }
        //просмотр заказов
        private void просмотрToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            menu = 1;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            string zapros = "";
            int i = 0;
            for (i = 0; i < 5; i++)
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            }
            dataGridView1.Columns[0].HeaderText = "Клиент";
            dataGridView1.Columns[1].HeaderText = "Время";
            dataGridView1.Columns[2].HeaderText = "Дата";
            dataGridView1.Columns[3].HeaderText = "Статус";
            dataGridView1.Columns[4].HeaderText = "Мастер";

            global.conn.Open();
            zapros = "select Klient,Mesto,Data,Gotovnost, Familia from Zacaz, Master where Zacaz.Master_ID = Master.Master_ID";
            SqlCommand cmd = new SqlCommand(zapros, global.conn);
            SqlDataReader reader = cmd.ExecuteReader();
             i = 0;
            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = reader[0];
                dataGridView1[1, i].Value = reader[1];
                dataGridView1[2, i].Value = ((DateTime)reader[2]).ToString("dd.MM.yyyy");
                if ((bool)reader[3])
                {
                    dataGridView1[3, i].Value = "Выполнен";
                    dataGridView1.Rows[i].Visible = false;
                }
                else dataGridView1[3, i].Value = "Ожидание";
                dataGridView1[4, i].Value = reader[4];

                i++;
            }
            global.conn.Close();
        }
        //отчет по заказам
        private void заказыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            button5.Visible = false;
            button4.Visible = true;
            Otchet frm = new Otchet();
            frm.ShowDialog();
            string zapros = "";
            int i = 0;
            for (i = 0; i <4; i++)
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            }
            dataGridView1.Columns[0].HeaderText = "Дата";
            dataGridView1.Columns[1].HeaderText = "Мастер";
            dataGridView1.Columns[2].HeaderText = "Клиент";
            dataGridView1.Columns[3].HeaderText = "Сумма";

            global.conn.Open();
            zapros = "select Data, Familia, Klient, Summa From Zacaz, Master where Gotovnost = 1 and Zacaz.Master_ID = Master.Master_ID and Data between '"+global.nach_otch+"'and '"+global.konec_otch+"'";
            SqlCommand cmd = new SqlCommand(zapros, global.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            i = 0;
            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = ((DateTime)reader[0]).ToString("dd.MM.yyyy"); 
                dataGridView1[1, i].Value = reader[1];
                dataGridView1[2, i].Value = reader[2];
                dataGridView1[3, i].Value = reader[3];

                i++;
            }
            global.conn.Close();

        }

        private void продлитьНа30ДнейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string zapros = "";
            string max="";
            List<int> id_masters = new List<int>();
            //заносим все иды мастеров в лист 
            global.conn.Open();
            zapros = "select Master_ID from Master";
            SqlCommand cmd = new SqlCommand(zapros, global.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                id_masters.Add((int)reader[0]);
                i++;
            }
            reader.Close();
            //определение саксимальной даты
            zapros = "select MAX(_date) from Grafik";
            cmd = new SqlCommand(zapros, global.conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                max = ((DateTime)reader[0]).ToString("dd.MM.yyyy");
            }
            reader.Close();

            for(i=0;i<id_masters.Count;i++)
            {
                for (int j = 1; j <= 31; j++)
                {
                    zapros = "insert into Grafik (mesto1, mesto2, mesto3, mesto4, _date, Vihodnoi, Master_ID) values (0,0,0,0,(select dateadd(day,"+j+",'"+max+"')),0,"+id_masters[i]+")";
                    cmd = new SqlCommand(zapros, global.conn);
                   reader=cmd.ExecuteReader();
                    reader.Close();
                }
            }
           
            global.conn.Close();
            MessageBox.Show("График увеличен");
        }
    }
}

