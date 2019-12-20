using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Salon
{
    public partial class Form1 : Form
    {
     public bool admin = false;
       
        public Form1()
        {
            InitializeComponent();
        }
        //вход в систему
        private void button1_Click(object sender, EventArgs e)
        {
            /* String ConnectString = "Integrated Security=true;" + "User Id = " + textBox1.Text + "; Password = " + textBox2.Text + "; " + "Initial Catalog =SalonKrasoty " + "; server =LAPTOP-TKRUUJ4F ";
             SqlConnection conn = new SqlConnection(ConnectString);*/
            global con = new global(textBox1.Text, textBox2.Text);
            try
            {
                global.conn.Open();
                string quert = @"use SalonKrasoty; EXEC sp_helpuser'" + textBox1.Text + "';";
                SqlCommand command = new SqlCommand(quert, global.conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[1].ToString() == "db_owner")
                    { admin = true; }
                }
                global.conn.Close();
                if (admin)
                {
                    Admin frm = new Admin(); 
                    frm.Show(); 
                    this.Hide();
                    admin = false;
                }
                else
                {
                    Master frm = new Master();
                    global.login = textBox1.Text;
                    frm.Show(); 
                    this.Hide();
                    admin = false;
                }

            }
            catch(SqlException se)
            {
                MessageBox.Show("Ошибка подключения: " + se.Message);
                global.conn.Close();
                return;
            }
           
        }
    }
}
