using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Chibo.Data
{
    public static class GlobalDB
    {
        public static SQLiteConnection database_obj { get; set; }

        static GlobalDB()
        {
            //
        }

        public static void setObj(SQLiteConnection conn)
        {
            database_obj = conn;
        }

    }
}
