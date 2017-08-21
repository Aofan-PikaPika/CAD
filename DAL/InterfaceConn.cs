using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace DAL
{
    interface InterfaceConn
    {
        SQLiteConnection connectToDatabase();
    }
}
