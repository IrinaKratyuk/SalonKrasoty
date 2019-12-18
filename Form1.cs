using System;
using System.Windows.Forms;

namespace Salon
{
    public partial class Form1 : Form
    {
        string adminlog = "admin";
        string adminpassvord = "admin";
        bool vhod;
        string[] login = {"master1", "master2","master3"};
        string[] passvord = { "11111", "22222", "33333" };
       

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;

        }
        //вход в систему
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Администратор")
            {
                if (textBox1.Text == adminlog && textBox2.Text == adminpassvord)
                {
                    Admin frm = new Admin();
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует! Проверьте данные!");
                }
            }
            else
            {
                vhod = false;
                for (int i=0;i<login.Length;i++)
                {
                    if(textBox1.Text==login[i]&&textBox2.Text==passvord[i])
                    {
                        Master frm = new Master();
                        this.Hide();
                        frm.Show();
                        vhod = true;
                        break;
                    }
                }
                if(!vhod) MessageBox.Show("Такого пользователя не существует! Проверьте данные!");
            }
        }
    }
}
