using System;
using System.Collections.Generic;
using SQLite;

namespace Chibo.Models
{
    public class Recipe : IIdentifyable, ICanSaveLoad<Recipe>
    {
    private static Random _RNG = new Random();
    
    
        [PrimaryKey, AutoIncrement]
        private int id { get; set; }
        private ListIngredients _ingredients;

        private string _name;
        private string[] _instruction;
        private string[] _tags;

        private static List<Recipe> AllRecipes;

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

        public string[] Instruction
        {
            get
            {
                return _instruction;
            }

            set
            {
                _instruction = value;
            }
        }

        /// <summary>
        /// Gets or sets an array of strings. These strings act as tags to say what type of recipe this is. 
        /// (e.g. lunch, dinner, brunch)
        /// </summary>
        public string[] Tags
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

        public ListIngredients Ingredients
        {
            // The ListIngredients type should provide functionality to manipulate itself
            // New ListIngredients never need to be assigned
            get
            {
                return _ingredients;
            }
        }

        public int ID //why is this here when it is in the IIdentifiable
        {
            get;

            set;
        }

        public Recipe()
        {
            //databases should be able to add to this list of databases
        }

        public Recipe(string name, string[] instruction, string[] tag)
        {
            _ingredients = new ListIngredients();

            _name = name;

            _instruction = instruction;

            _tags = tag;
        }

        public Recipe(Recipe toCopy)
        {
            _ingredients = new ListIngredients();

            foreach (Ingredient i in toCopy.Ingredients.Ingredients)
            {
                _ingredients.Add(i);
            }

            _name = new string(toCopy.Name.ToCharArray());

            List<string> tempStringArray = new List<string>();

            int j = 0;
            while (j < toCopy.Instruction.Length)
            {
                tempStringArray.Add(new string(toCopy.Instruction[j].ToCharArray()));
                j += 1;
            }

            _instruction = tempStringArray.ToArray();

            tempStringArray = new List<string>();

            j = 0;
            while (j < toCopy.Tags.Length)
            {
                tempStringArray.Add(new string(toCopy.Tags[j].ToCharArray()));

                j += 1;
            }

            _tags = tempStringArray.ToArray();
        }

        public static Recipe RandomRecipe(string[] tags, double likenessPercentage)
        {
            Recipe placeHolder = new Recipe("stew", new string[] { "peel potatos", "stew potatos" , "dinner"}, new string[] { "dinner", "lunch", "stew" });
            Recipe FruityIceCream = new Recipe("fruity ice cream", new string[] { "fruit", "ice", "cream" }, new string[] { "dessert", "tasty", "fruit"});
            Recipe FriedRice = new Recipe("fried rice", new string[] { "peas", "rice", "soy sauce"}, new string[] { "dinner", "lunch", "rice", "tasty"});
            Recipe ImVegan = new Recipe("im vegan", new string[] { "bones", "blood", "contempt" }, new string[] { "healthy", "lunch"});

            Recipe[] toSelectFrom = new Recipe[] {placeHolder, FruityIceCream, FriedRice, ImVegan };//false target, needs to be loaded from database


            if (likenessPercentage > 1.0)
            {
                likenessPercentage = 1.0;
            }

            List<Recipe> validChoices = new List<Recipe>();

            foreach (Recipe r in toSelectFrom)
            {
                if (r.FitsTags(tags) >= likenessPercentage)
                {
                    validChoices.Add(new Recipe(r));
                }
            }

            if (validChoices.Count == 0)
            {
                return null;
            }

            return validChoices[_RNG.Next(validChoices.Count)]; // could this Next also pick zero? Or does Next return floating point values
        }

        public void Add(Ingredient toAdd, float amount)
        {
            Ingredient toPass = new Ingredient(toAdd.Name, toAdd.Descrip, amount, toAdd.CaloriesPerGram);
            _ingredients.Add(toPass);
        }

        public void Remove(Ingredient toRemove, float amount)
        {
            Ingredient toPass = new Ingredient(toRemove.Name, toRemove.Descrip, amount, toRemove.CaloriesPerGram);

            _ingredients.Remove(toPass);
        }

        public bool HasTag(string inputTags)
        {
            foreach (string recipeTags in _tags)
            {

                if (inputTags == recipeTags)
                {
                    return true;
                }
            }
            return false;
        }

        public double FitsTags(string[] tags)
        {
            //Console.WriteLine("Fit Tags");

            int found = 0;


            foreach (string s in tags)
            {
                if (HasTag(s))
                {
                    found += 1;
                }
            }
            double likenessPercentage = Convert.ToDouble(found) / Convert.ToDouble(tags.Length);
            return likenessPercentage;//percentage
        }

        bool IIdentifyable.SameID(IIdentifyable identified)
        {
            bool result = false;

            if (this.GetType() == identified.GetType())
            {
                if (this.ID == identified.ID)
                {
                    result = true;
                }
            }
            return result;
        }

        bool ICanSaveLoad<Recipe>.Save(Recipe saveMe)
        {
            //save nput days
            //if succesfully saved
            //return myDB.saveRecipe(saveMe);
            return false;
        }

        bool ICanSaveLoad<Recipe>.Save()
        {
            //return myDB.saveRecipe(this);
            //if succesfully saved  
            return false;
        }

        List<Recipe> ICanSaveLoad<Recipe>.LoadAll()
        {
            return new List<Recipe>();

            //return database of Recipe into this LIst
        }

        Recipe ICanSaveLoad<Recipe>.Load(int requestedID)
        {
            Recipe loadedRecipe= new Recipe(); //uncomment the other code if needed. 

            //loadedRecipe = myDB.getRecipe(requestedID);

            if (loadedRecipe == null)
            {
                throw new Exception("Day Load Null Exception");
            }
            return loadedRecipe;
            //return myDB.getDay(requestedID);
            //return myDB.getRecipe(requestedID);
        }
    }
}