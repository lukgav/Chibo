using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Chibo.Data
{
    public class ChiboDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ChiboDatabase(string dbpath)
        {
            //the constructor for the database
            database = new SQLiteAsyncConnection(dbpath);
            //database.CreateTableAsync<>().Wait();
        }
    }
}
