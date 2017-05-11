using System;
using System.Collections.Generic;

namespace Chibo.Models
{
    public class Menu
    {
        private List<Day> _days;
        private string _name;

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

        public int NumberOfDays
        {
            get
            {
                return _days.Count;
            }
        }

        public Menu(string name)
        {
            _name = name;

            _days = new List<Day>();
        }

        public void FillDay(int index)
        {
            this.FillDays(index, index);
        }

        public void FillDays(int indexStart, int indexEnd)
        {
            if (indexStart < 0)
            {
                indexStart = 0;
            }

            if (indexEnd >= _days.Count)
            {
                indexEnd = _days.Count - 1;
            }

            int i = indexStart;
            while (i <= indexEnd)
            {
                _days[i].RandomiseAll();
            }
        }

        public void AddDay()
        {
            this.AddDay(new Day());
        }

        public void AddDay(Day toAdd)
        {
            _days.Add(toAdd);
        }

        public void RemoveAt(int index)
        {
            if ((index > -1) && (index < _days.Count))
            {
                _days.RemoveAt(index);
            }
        }

        public ListIngredients CompileShoppingList()
        {
            ListIngredients result = new ListIngredients();

            foreach (Day d in _days)
            {
                foreach (Recipe r in d.Recipes)
                {
                    result.Merge(r.Ingredients);
                }
            }

            return result;
        }
    }
}