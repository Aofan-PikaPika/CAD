using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Configuration;


namespace DAL
{
    internal class SQLiteConnectionBase:InterfaceConn
    {
        private string connString = ConfigurationManager.ConnectionStrings["sqlite"].ToString();

        SQLiteConnection conn;

        public SQLiteConnection connectToDatabase() 
        {
            conn = new SQLiteConnection(connString);
            conn.Open();
            return conn;
        }


    }
}
