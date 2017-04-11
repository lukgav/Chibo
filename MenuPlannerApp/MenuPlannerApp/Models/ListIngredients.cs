using System;
using System.Collections.Generic;

namespace Chibo.Models
{
    public class ListIngredients
    {
        private List<Ingredient> ingredients;
        private uint ingNum;
        private Ingredient ingred;
        
        public ListIngredients()
        {
            ingredients = new List<Ingredient>();
            ingNum = 0;
        }

        public ListIngredients(List<Ingredient> _ingredients)
        {
            ingredients = _ingredients;
            ingNum = 0;
        }

        public ListIngredients Merge(ListIngredients ls)
        {
           return this.Merge(ls.Ingredients);
        }

        public ListIngredients Merge(List<Ingredient> ingListFrom)
        {
            bool hasCheck = false;
            ListIngredients lIngreds = new ListIngredients(ingredients);

            foreach (Ingredient newIng in ingListFrom)
            {
                foreach (Ingredient thisIng in Ingredients)
                {
                    if(thisIng.Equals(newIng))
                    {
                        hasCheck = true;
                    }       
                }
                if (hasCheck == true)
                {
                    ingNum++;
                }

                lIngreds.Ingredients.Add(newIng);
               hasCheck = false;
            }
            return lIngreds;
        }

        public List<Ingredient> Ingredients{get; set;}
        public uint IngNum {get; set;}
    }
}