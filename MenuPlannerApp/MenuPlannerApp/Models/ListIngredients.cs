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

        public void Add(Ingredient input)
        {
            bool hasCheck = false;

            float inputMass = input.Mass;

            foreach (Ingredient knownIng in Ingredients)
            {
                if (knownIng.Name == input.Name)
                {
                    hasCheck = true;

                    knownIng.Mass += input.Mass;//BUG this was setting input.Mass value

                    break;
                }
            }

            if (hasCheck != true)
            {
                _ingredients.Add(input);
            }

            input.Mass = inputMass;
        }

        public void Remove(Ingredient input)
        {
            //The input ingredient should know the amount to be removed (assumed positive)
            int i = 0;
            while(i < Ingredients.Count)
            {
                if (Ingredients[i].Name == input.Name)
                {
                    Ingredients[i].Mass -= input.Mass;

                    break;
                }

                i += 1;
            }

            if (i >= Ingredients.Count)
            {
                return;
            }

            //this.Purge();//BUG purge is removing the highest index always
        }

        public void Purge()
        {
            int i = 0;

            while (i < _ingredients.Count)
            {
                if (_ingredients[i].Mass <= 0.0f)
                {
                    _ingredients.RemoveAt(i);
                }

                else
                {
                    i += 1;
                }
            }
        }

        public void Merge(List<Ingredient> ingListFrom)
        {
            ListIngredients lIngreds = new ListIngredients(_ingredients);

            foreach (Ingredient newIng in ingListFrom)
            {
                lIngreds.Add(newIng);
            }
        }
    }
}