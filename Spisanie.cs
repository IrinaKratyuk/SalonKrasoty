using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Salon
{
    public partial class Spisanie : Form
    {
        public Spisanie()
        {
            InitializeComponent();
        }
        //назад
        private void button1_Click(object sender, EventArgs e)
        {
            Admin frm = new Admin();
            this.Hide();
            frm.Show();
        }
        //заполнение листбокса при загрузке формы
        private void Spisanie_Load(object sender, EventArgs e)
        {
            
            string query = @"SELECT * FROM Material";
            SqlCommand cmd = new SqlCommand(query, global.conn);
            global.conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                listBox1.Items.Add(reader[1]);
                i++;
            }
            reader.Close();
            global.conn.Close();
        }
        //списание
        private void button2_Click(object sender, EventArgs e)
        {
            global.conn.Open();
            string zapros = "";
            int obyem = 0;
            string nazv = "";    
          
            nazv = (string)listBox1.SelectedItem; obyem = Convert.ToInt32(textBox2.Text);
            zapros += "update Material set Obyem-=" + obyem + " where Nazvanie='" + nazv + "';";
                             
            MessageBox.Show(zapros);
            SqlCommand cmd = new SqlCommand(zapros, global.conn);
            cmd.ExecuteNonQuery();
            zapros = "";
            MessageBox.Show("Данные изменены");
            //очистка полей после внесения
            global.conn.Close();
        }
    }
}
