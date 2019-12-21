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
        int[] spec_ind = new int[20];//индексы специализаций
        private void DobavMaster_Load(object sender, EventArgs e)
        {
            if (global.dob == 1) { button1.Visible = true; }
            else
            {   button3.Visible = true;
                textBox1.Visible = false;
                textBox2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                checkedListBox1.Visible = false;
                label7.Visible = false;
            }
            string query = @"SELECT * FROM Specializaciya";
            SqlCommand cmd = new SqlCommand(query, global.conn);
            global.conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                checkedListBox1.Items.Add(reader[1]);
                spec_ind[i] = (int)reader[0];//массив идов специ-ии
                i++;
            }
            reader.Close();
        }
        //добавление
        private void button1_Click(object sender, EventArgs e)
        {
            string dobmast = "", dobuser = "", dobspec = "", poiskindex="";
            string values = ""; int ind_mast=0;
            int n = checkedListBox1.Items.Count;
            // string[] mas_nazv = new string[n];
            bool k = false;
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""&&textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            { 
                dobmast += "insert into Master (Familia,Name,Otchestvo, opyt, login) values ('" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "','"+textBox1.Text+"');";
                dobuser += "EXEC sp_addlogin "+textBox1.Text+","+textBox2.Text+",SalonKrasoty; EXEC sp_adduser " + textBox1.Text + "," + textBox1.Text + ", db_ddladmin; EXEC sp_addrolemember Masters,"+textBox1.Text+";";
                k = true;
            }
            else
            {
                MessageBox.Show("Поля не должны быть пустыми");
                
            }
            if (k)
            {
                //определение отмеченных специальностей
                for (int i = 0; i < n; i++)
                {
                    if (!checkedListBox1.GetItemChecked(i))//если не отмечено то индекс приравняем 0
                    {
                        spec_ind[i] = 0;
                    }
                }
                SqlCommand cmd1 = new SqlCommand(dobmast, global.conn);
                SqlDataReader r1 = cmd1.ExecuteReader();
                r1.Close();
                SqlCommand cmd2 = new SqlCommand(dobuser, global.conn);
                SqlDataReader r2 = cmd2.ExecuteReader();
                r2.Close();
                //поиск индекса добавленного мастера
                poiskindex = "select* from Master";
                SqlCommand cmd3 = new SqlCommand(poiskindex, global.conn);
                SqlDataReader r3 = cmd3.ExecuteReader();
                
                //поиск последнего индекса
                while (r3.Read())
                {
                    ind_mast = (int)r3[0];
                }
                r3.Close();
                //формирование запроса
                for (int i = 0; i < spec_ind.Length; i++)
                {
                    if (spec_ind[i] != 0 && ind_mast != 0)
                    {
                        values += "(" + ind_mast + "," + spec_ind[i] + ")";
                    }
                }
                
                dobspec = "insert into Master_Spec(Master_ID,Specializaciya_ID) values" + values;
                SqlCommand cmd4 = new SqlCommand(dobspec, global.conn);
                SqlDataReader r4 = cmd4.ExecuteReader();
                r4.Close();
                global.conn.Close();

                string zapros = "";
                string maxdat="";
                int maxid=0;

                //максималый ид мастера
                global.conn.Open();
                zapros = "select MAX(Master_ID) from Master";
                SqlCommand cmd = new SqlCommand(zapros, global.conn);
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    maxid=(int)reader[0];
                }
                reader.Close();
                //определение максимальной даты даты
                zapros = "select MAX(_date) from Grafik";
                cmd = new SqlCommand(zapros, global.conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    maxdat = ((DateTime)reader[0]).ToString("dd.MM.yyyy");
                }
                reader.Close();
               DateTime seg= DateTime.Today;
               TimeSpan delta=Convert.ToDateTime(maxdat)-seg;
               int count = Convert.ToInt32(delta.Days.ToString());
               
                    for (int j=0; j <=count ; j++)
                    {
                        zapros = "insert into Grafik (mesto1, mesto2, mesto3, mesto4, _date, Vihodnoi, Master_ID) values (0,0,0,0,(select dateadd(day," + j + ",'" + seg + "')),0," + maxid + ")";
                        cmd = new SqlCommand(zapros, global.conn);
                        reader = cmd.ExecuteReader();
                        reader.Close();
                    }

                global.conn.Close();
                dobmast = ""; dobuser = ""; dobspec = ""; poiskindex = "";
                MessageBox.Show("Изменения внесены успешно");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string zapros = "";
            if (textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                zapros += "update Master set Familia = '" + textBox3.Text + "', Name = '" + textBox4.Text + "', Otchestvo = '" + textBox5.Text + "', Opyt = '" + textBox6.Text + "' where Master_ID = " + global.Master_ID + "; ";
                SqlCommand command = new SqlCommand(zapros, global.conn);
                SqlDataReader reader = command.ExecuteReader();
                global.conn.Close();
                zapros = "";
                MessageBox.Show("Изменения внесены успешно");
             }
            else
            {
                MessageBox.Show("Поля не должны быть пустыми");
            }
        }
    }
}
