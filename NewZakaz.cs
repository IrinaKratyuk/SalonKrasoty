using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Salon
{
    public partial class NewZakaz : Form
    {
        public NewZakaz()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin frm = new Admin();
            frm.Show();
            this.Hide();
        }

        private void NewZakaz_Load(object sender, EventArgs e)
        {
            string zapros = "";
            global.conn.Open();
            zapros = "select _date from Grafik";
            SqlCommand cmd = new SqlCommand(zapros, global.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<DateTime> tmp = new List<DateTime>();
            while (reader.Read())
            {
                tmp.Add((DateTime)reader[0]);
            }
            var unic = tmp.Distinct();
            tmp = unic.ToList();
            for (int i = 0; i < tmp.Count; i++)
            {
                comboBox2.Items.Add(tmp[i]);
            }


            global.conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            string zapros = "";
            global.conn.Open();
            zapros = "select Familia,Vihodnoi from Grafik, Master where Grafik.Master_ID = Master.Master_ID and Grafik._date = '" + comboBox2.Text+"'";
            SqlCommand cmd = new SqlCommand(zapros, global.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<string> tmp = new List<string>();
            while (reader.Read())
            {   if (!(bool)reader[1])
                tmp.Add((string)reader[0]);
            }
            var unic = tmp.Distinct();
            tmp = unic.ToList();
            for (int i = 0; i < tmp.Count; i++)
            {
                comboBox3.Items.Add(tmp[i]);
            }


            global.conn.Close();
        }
        List<mesto> mests = new List<mesto>();
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            mests.Clear();
            string zapros = "";
            global.conn.Open();            
            zapros = "select mesto1,mesto2,mesto3,mesto4 from Grafik, Master where Grafik.Master_ID = Master.Master_ID and Grafik._date = '"+comboBox2.Text+"' and Familia = '"+comboBox3.Text+"'";
            SqlCommand cmd = new SqlCommand(zapros, global.conn);
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
            for (int i = 0; i < mests.Count; i++)
            {
                if (!mests[i].mest1) comboBox1.Items.Add("9:00-11:00");
                if (!mests[i].mest2) comboBox1.Items.Add("11:00-13:00");
                if (!mests[i].mest3) comboBox1.Items.Add("14:00-16:00");
                if (!mests[i].mest4) comboBox1.Items.Add("16:00-18:00");
            }


            global.conn.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string zapros = "";
            global.conn.Open();
            zapros = "insert into Zacaz (Klient, Mesto, Data, Summa, Master_ID,Gotovnost) values('"+textBox1.Text+"', '"+comboBox1.Text+"', '"+comboBox2.Text+"', "+textBox2.Text+", (select Master_ID from Master where Familia = '"+comboBox3.Text+"'),0)";
            SqlCommand cmd = new SqlCommand(zapros, global.conn);
            cmd.ExecuteNonQuery();
            if (comboBox1.Text == "9:00-11:00") mests[0].mest1 = true;
            if (comboBox1.Text == "11:00-13:00") mests[0].mest2 = true;
            if (comboBox1.Text == "14:00-16:00") mests[0].mest3 = true;
            if (comboBox1.Text == "16:00-18:00") mests[0].mest4 = true;            
            zapros = "update Grafik set mesto1 = '"+Convert.ToInt32(mests[0].mest1)+ "', mesto2 = '" + Convert.ToInt32(mests[0].mest2) + "',    mesto3 = '" + Convert.ToInt32(mests[0].mest3) + "',    mesto4 = '" + Convert.ToInt32(mests[0].mest4) + "' where(select Master_ID from Master where Familia = '"+comboBox3.Text+"') = Master_ID and _date = '"+comboBox2.Text+"'";
            cmd = new SqlCommand(zapros, global.conn);
            cmd.ExecuteNonQuery();
            
            global.conn.Close();
            MessageBox.Show("ЗАказ добавлен");
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox3.Items.Clear();
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }
    }
}
class mesto
{
    public bool mest1 { get; set; }
    public bool mest2 { get; set; }
    public bool mest3 { get; set; }
    public bool mest4 { get; set; }

}