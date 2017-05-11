using System;
using System.Collections.Generic;

namespace Chibo.Models
{
    public class Day
    {
        private List<Recipe> _recipes;

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

        public Day()
        {
            _recipes = new List<Recipe>();
            _tags = new List<string[]>();
        }

        public void RandomiseAll()
        {
            int i = 0;
            while (i < _recipes.Count)
            {
                try
                {
                    this.RandomiseRecipe(i);
                }

                catch (Exception e)
                {
                    throw new Exception("Randomise All Failure");
                }

                i += 1;
            }
        }

        public void RandomiseRecipe(int index)
        {
            double minimumLikeness = 0.8;

            Recipe changeTo = Recipe.RandomRecipe(_tags[index], minimumLikeness);

            if (changeTo == null)
            {
                string exM = "There were no valid recipes which fitted\n";

                foreach (string s in _tags[index])
                {
                    exM += s + "\n";
                }

                exM += "To within " + (100 * minimumLikeness) + "%";

                throw new Exception(exM);
            }

            _recipes[index] = changeTo;
        }

        public void Add(Recipe toAdd, string[] tags)
        {
            _recipes.Add(toAdd);
            _tags.Add(tags);

            this.CheckAllignment();
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
    }
}