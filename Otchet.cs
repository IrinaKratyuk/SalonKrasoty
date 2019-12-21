using System;
using System.Windows.Forms;

namespace Salon
{
    public partial class Otchet : Form
    {
        public Otchet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd.MM.yyyy";
            global.nach_otch = dateTimePicker1.Text;
            global.konec_otch = dateTimePicker2.Text;
            this.Close();
        }
    }
}
