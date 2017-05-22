using System;
using System.Collections.Generic;
using SQLite;
namespace Chibo.Models
{
    public class Day : ICanSaveLoad<Day>, ISearch<Recipe>, ISearchDB<Recipe>
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        private string _name;
        private List<Recipe> _recipes;
        //private static List<Day> allDays;

        private List<string[]> _tags;

        public List<Recipe> Recipes
        {
            get { return _recipes; }
        }

        /// <summary>
        /// Gets or sets a list of array strings. These strings act as tag to say what type of recipe each days recipes should be.
        /// </summary>
        public List<string[]> Tags
        {
            get
            {
                return _tags;
            }

            set
            {
                _tags = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public Day()
        {
            _recipes = new List<Recipe>();
            _tags = new List<string[]>();
        }

        public Day(string name)
        {
            _recipes = new List<Recipe>();
            _tags = new List<string[]>();
            _name = Name;
        }

        public Day(int id, string name)
        {
            _recipes = new List<Recipe>();
            _tags = new List<string[]>();
            ID = id;
            _name = Name;
        }

        public Day(List<Recipe> recipes, List<string[]> tags)
        {
            _recipes = recipes;
            _tags = tags;
        }

        public Day(List<Recipe> recipes, List<string[]> tags, int id)
        {
            _recipes = recipes;
            _tags = tags;
            ID = id;

        }
        public List<Recipe> RandomiseAll()
        {
            int i = 0;
            List<Recipe> randRecipes = new List<Recipe>();
            while (i < _recipes.Count)
            {
                try
                {
                    randRecipes.Add(this.SearchDayTagsIndexForRandomiseRecipe(i));
                }

                catch (Exception randError)
                {
                    throw new Exception("Randomise All Failure");
                }

                i += 1;
            }
            return _recipes;
        }

        public Recipe SearchDayTagsIndexForRandomiseRecipe(int index)
        {
            double minimumLikeness = 0.8;

            Recipe randRecipe = Recipe.RandomRecipe(_tags[index], minimumLikeness);

            if (randRecipe == null)
            {
                string exM = "There were no valid recipes which fitted\n";

                foreach (string s in _tags[index]) //couldn't this overload the tags variable and be out of range?
                {
                    exM += s + "\n";
                }

                exM += "To within " + (100 * minimumLikeness) + "%";

                throw new Exception(exM);
            }

            //_recipes[index] = randRecipe;
            return randRecipe;
        }

        public void AddRecipe(string[] wantedTags) // tags are within the recipe so why have a second parameter at all?
        {
            _tags.Add(wantedTags);
            Recipe placeHolder = new Recipe("stew", new string[] { "peel potatos", "stew potatos", "dinner" }, new string[] { "dinner", "lunch", "stew" });
            _recipes.Add(placeHolder);
            this.CheckAllignment();
        }

        public void AddRecipe(Recipe inputRecipe)
        {
            _recipes.Add(inputRecipe);
        }

        public void Remove(Recipe toRemove)
        {
            int i = 0;

            while (i < _recipes.Count)
            {
                if (_recipes[i].Name == toRemove.Name)
                {
                    this.RemoveAt(i);
                }
                else
                {
                    i += 1;
                }
            }
        }
       
      

        public void RemoveAt(int index)
        {
            _recipes.RemoveAt(index);
            _tags.RemoveAt(index);

            this.CheckAllignment();
        }

        public void CheckAllignment()
        {
            //Checks the two lists haven't suffered any misallignment
            if (_recipes.Count != _tags.Count)
            {
                throw new IndexOutOfRangeException(String.Format("The Recipes and Tags lists have misalligned by Recipes length:{0}, Tags length:{1}, Total misallighment: {2}", _recipes.Count, _tags.Count, Math.Abs(_recipes.Count - _tags.Count)));
            }
        }

        Recipe ISearch<Recipe>.Search(string name) //
        {
            foreach (Recipe r in _recipes)
            {
                if (r.Name == name)
                {
                    if (r == null)
                    {
                        string exM = "This recipe is null";
                        throw new Exception(exM);
                    }
                    return r;
                }
            }
            return null;
        }
        
        Recipe ISearch<Recipe>.Search(string[] tags)
        {
            double minimumLikeness = 0.8;
            return SearchForRecipe(tags, minimumLikeness);
        }

        Recipe SearchForRecipe(string[] tags, double tagMatchProbability)
        {
            Recipe searchedRecipe = Recipe.RandomRecipe(tags, tagMatchProbability);

            if (searchedRecipe == null)
            {
                string exM = "There were no valid recipes which fitted\n";

                foreach (string s in tags) //couldn't this overload the tags variable and be out of range?
                {
                    exM += s + "\n";
                }

                exM += "To within " + (100 * tagMatchProbability) + "%";

                throw new Exception(exM);
            }
            return searchedRecipe;
        }


        Recipe ISearch<Recipe>.Search(int requestedId)
        {
            foreach (Recipe r in _recipes)
            {
                if (r.ID == requestedId)
                {
                    if (r == null)
                    {
                        string exM = "This recipe is null";
                        throw new Exception(exM);
                    }
                    return r;
                }
            }
            return null;
        }

        Recipe ISearchDB<Recipe>.SearchDB(int requestedId)
        {
            return new Recipe();

            //search through database
        }

        Recipe ISearchDB<Recipe>.SearchDB(string name)
        {
            return new Recipe();

            //search through database
        }

        Recipe ISearchDB<Recipe>.SearchDB(string[] tags)
        {
            return new Recipe();
            //search through database
        }

        bool ICanSaveLoad<Day>.Save(Day saveMe)
        {
            //return myDB.saveDay(saveMe);
            return false;
        }

        bool ICanSaveLoad<Day>.Save()
        {
            //return myDB.saveDay(this);
            return false;
        }


        Day ICanSaveLoad<Day>.Load(int requestedID)
        {
            Day loadedDay = new Models.Day(); //uncomment the other code if needed. 

            //loadedDay = myDB.getDay(requestedID);

            if (loadedDay == null)
            {
                throw new Exception("Day Load Null Exception");
            }
            return loadedDay;
            //return myDB.getDay(requestedID);
        }

        List<Day> ICanSaveLoad<Day>.LoadAll()
        {
            allDays =  new List<Day>(); //all allLoadedDays  wil equal what is in the database. 
            return allDays;
            //return database of Recipe into this LIst
        }


    }
}