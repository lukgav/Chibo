using SQLite;
using Chibo;
using Chibo.Models;

namespace Chibo.Data
{
    public class ChiboDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ChiboDatabase(string dbpath)
        {
            //the constructor for the database
            database = new SQLiteAsyncConnection(dbpath);
            //database.CreateTableAsync<>
            database.CreateTableAsync<Day>().Wait();
            database.CreateTableAsync<Ingredient>().Wait();
        }
    }
}
