using System;
using System.Collections.Generic;

namespace Chibo.Models
{
    public class ListIngredients
    {
        private List<Ingredient> _ingredients;

        public List<Ingredient> Ingredients
        {
            get
            {
                return _ingredients;
            }

            set
            {
                _ingredients = value;
            }
        }
        public int NumberOfIngredients
        {
            get
            {
                return _ingredients.Count;
            }
        }

        public ListIngredients()
        {
            _ingredients = new List<Ingredient>();
        }

        public ListIngredients(List<Ingredient> ingredients)
        {
            _ingredients = ingredients;
        }

        public void Merge(ListIngredients ls)
        {
           this.Merge(ls.Ingredients);
        }

        public void Merge(List<Ingredient> ingListFrom)
        {
            ListIngredients lIngreds = new ListIngredients(_ingredients);

            foreach (Ingredient newIng in ingListFrom)
            {
                bool hasCheck = false;

                foreach (Ingredient thisIng in Ingredients)
                {
                    if(thisIng.Name == newIng.Name)
                    {
                        hasCheck = true;

                        thisIng.NumberOfIngredients += newIng.NumberOfIngredients;

                        break;
                    }       
                }

                if (hasCheck != true)
                {
                    _ingredients.Add(newIng);
                }
            }
        }
    }
}