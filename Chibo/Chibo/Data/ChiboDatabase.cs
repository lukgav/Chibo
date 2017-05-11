using SQLite;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
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

            ////open a non-async db to see if it exists first:
            //SQLiteConnection db = new SQLiteConnection(dbpath);

            ////try to read the recipe table
            //var info = db.GetTableInfo("recipes");
            //if (!info.Any())
            //{
            //    //table doesn't exist. close the DB, delete the created file, and copy over the 
            //    db.Close();
            //    //
            //}

            //see if database exists, if not copy it over from RAW.

            Debug.WriteLine(dbpath);

            Java.IO.File file = new Java.IO.File(dbpath);
            if (file.Exists())
            {
                Debug.WriteLine("file exists!");
            } else
            {
                Debug.WriteLine("nope doesn't exist.");
            }

            

            database = new SQLiteAsyncConnection(dbpath);
            //database.CreateTableAsync<>

            Debug.WriteLine(database.ToString());
        }

        public Task<List<Recipe>> GetRecipesByDay(RecipeDay requestedDay)
        {
            //return the task<list<>> of recipes, based on the enum that you've passed
            //see enum definition in chibo/models/DayEnum.cs

            //TODO: add database code for this class.

            return null;
        }

        public Task<List<Recipe>> GetRecipesByDay(int dayrequested)
        {
            //same as class above, but using integer instead of enum.
            RecipeDay foo = (RecipeDay)dayrequested;

            //call the class above - save rewriting database code.
            return GetRecipesByDay(foo);
        }

        public Task<Recipe> GetRecipeByIdAsync (int id)
        {
            //returns a single recipe based on the supplied ID.

            return database.Table<Recipe>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<ListIngredients> ListIngredientsInRecipeID(int id)
        {
            //returns a list of the ingredients used, based on the supplied recipe ID

            //TODO: add database code.
            return null;
        }

        public Task<Menu> ListMenu ()
        {
            //returns the full menu of recipes.

            //TODO: add database SQL code.
            return null;
        }

        
    }
}
