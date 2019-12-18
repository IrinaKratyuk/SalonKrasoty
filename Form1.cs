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
            comboBox1.SelectedIndex = 0;

        }
        //вход в систему
        private void button1_Click(object sender, EventArgs e)
        {
            String ConnectString = "Integrated Security=true;" + "User Id = " + textBox1.Text + "; Password = " + textBox2.Text + "; " + "Initial Catalog =SalonKrasoty " + "; server =LAPTOP-TKRUUJ4F ";
            SqlConnection conn = new SqlConnection(ConnectString);
            try
            {
                conn.Open();
                string quert = @"use SalonKrasoty; EXEC sp_helpuser'" + textBox1.Text + "';";
                SqlCommand command = new SqlCommand(quert, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[1].ToString() == "db_owner")
                    { admin = true; }
                }
                if (admin)
                {
                    MessageBox.Show("Подключение установлено");
                    Admin frm = new Admin(); //создаем новую форму
                    frm.Show(); //отображаем созданную форму
                    this.Hide();
                    admin = false;
                }
                else
                {
                    MessageBox.Show("Подключение установлено");
                    Master frm = new Master(); //создаем новую форму
                    frm.Show(); //отображаем созданную форму
                    this.Hide();
                    admin = false;
                }
              //  MessageBox.Show("podcluchilis");
            }
            catch(SqlException se)
            {
                MessageBox.Show("Ошибка подключения: " + se.Message);
                return;
            }
              
                
           /* conn.Close();
            MessageBox.Show("otcluchilis");*/
        }
    }
}
