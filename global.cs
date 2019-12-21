using System;
using System.Data.SqlClient;


namespace Salon 
{
    class global
    {
        public static string login;
       public static String ConnectString;
        public static SqlConnection conn;
        public static int dob;
        public static int Master_ID;
        public static string nach_otch, konec_otch;
        public global(string log, string pas)
        {
            ConnectString = "Integrated Security=true;" + "User Id = " + log + "; Password = " + pas + "; " + "Initial Catalog =SalonKrasoty " + "; server =LAPTOP-TKRUUJ4F ";
            conn = new SqlConnection(ConnectString);
        }
       
    }
    class mesto
    {
        public bool mest1 { get; set; }
        public bool mest2 { get; set; }
        public bool mest3 { get; set; }
        public bool mest4 { get; set; }

    }
}
