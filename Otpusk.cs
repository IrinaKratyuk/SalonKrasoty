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
    public partial class Otpusk : Form
    {
        public Otpusk()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd.MM.yyyy";
            global.conn.Open();
            string zapros = "insert into Otpusk (date_nach, date_konec,podtverd,Master_ID) values('"+dateTimePicker1.Text+"', '"+dateTimePicker2.Text+"', 0, (select Master_ID from Master where login = '"+global.login+"'))";
            SqlCommand cmd = new SqlCommand(zapros,global.conn);
            cmd.ExecuteNonQuery();
            global.conn.Close();
            MessageBox.Show("Пиздуй в отпуск гнида");
        }
    }
}
