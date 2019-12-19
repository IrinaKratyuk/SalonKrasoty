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
    public partial class Zakupka : Form
    {
        public Zakupka()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin frm = new Admin();
            this.Hide();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nazv = "", zapros="";
            int obyem=0;
            string[] mas_naz = new string[100];
            int[] mas_ob = new int[100];
            //считывание данных
            zapros = "select* from Material";
            global.conn.Open();
            SqlCommand cmd = new SqlCommand(zapros, global.conn);
            SqlDataReader r = cmd.ExecuteReader();
            int i = 0;
            //поиск последнего индекса
            while (r.Read())
            {
                mas_naz[i] = (string)r[1];
                mas_ob[i] = (int)r[2];
                i++;
            }
            r.Close();
            zapros = ""; int k = 0;
            nazv = textBox1.Text; obyem = Convert.ToInt32(textBox2.Text);
            for(i=0; i<100;i++)
            {
                if(mas_naz[i]!=null)
                {
                    if(mas_naz[i]==nazv)//если такой товар есть в списке
                    {
                       
                        zapros += "update Material set Obyem="+Convert.ToString(mas_ob[i]+obyem) +" where Nazvanie='"+nazv+"';";
                        k = 1;
                        break;
                    }
                }
                else
                {
                    zapros += "insert into Material(Nazvanie,Obyem) values('" + nazv + "'," + obyem + ");";
                    break;
                }
                if (k == 1) break;
            }
            SqlCommand cmd1 = new SqlCommand(zapros, global.conn);
            cmd1.ExecuteNonQuery();
           // r1.Close();
            zapros = "";
            MessageBox.Show("Данные внесены");
            //очистка полей после внесения
            textBox1.Text = "";
            textBox2.Text = "";
            global.conn.Close();
        }
    }
}
