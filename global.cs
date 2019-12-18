using System;
using System.Data.SqlClient;


namespace Salon 
{
    class global
    {
       public static String ConnectString;
        public static SqlConnection conn;
        public global(string log, string pas)
        {
            ConnectString = "Integrated Security=true;" + "User Id = " + log + "; Password = " + pas + "; " + "Initial Catalog =SalonKrasoty " + "; server =LAPTOP-TKRUUJ4F ";
            conn = new SqlConnection(ConnectString);
        }
       
    }
}
