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
            ingredients = null;
            ingNum = 0;
        }

        public ListIngredients(List<Ingredient> _ingredients)
        {
            ingredients = _ingredients;
            ingNum = 0;
        }


        //JED A. I added this overload to allow simpler functionality
        public ListIngredients Merge(ListIngredients ls)
        {
           return this.Merge(ls.Ingredients);
        }

        public ListIngredients Merge(List<Ingredient> ingListFrom)
        {
            bool hasCheck = false;
            ListIngredients lIngreds = new ListIngredients(ingredients);

            //JED Q. shouldn't ListIngredients have an add function which does this check?
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

                //JED Q. Shouldn't the ListIngredients record the amount of each Ingredient?
                //JED Q. shouldn't ListIngredients have an add function which only adds a new entry to ingredients if a copy doesn't already exist?
                lIngreds.Ingredients.Add(newIng);
               hasCheck = false;
            }
            return lIngreds;
        }

        public List<Ingredient> Ingredients{get; set;}
        public uint IngNum {get; set;}
    }
}