using System;
using System.Collections.Generic;

namespace Chibo.Models
{
    public class Menu : ICanSaveLoad<List<Day>>, ISearch<Day>, ISearchDB<Day>
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

        public List<Day> Days()
        {
            return _days;
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
        //search by name or ID  or tag
        Day ISearch<Day>.Search(string name) //search for the Day by name
        {
            foreach(Day d in _days)
            {
                if(d.Name == name)
                {
                    return d;
                }
            }
            return null;
        }

        Day ISearch<Day>.Search(string[] tags) //
        {
            foreach (Day d in _days)
            {
                int count = 0;
                foreach(string[] t in d.Tags)
                {
                    if(tags == d.Tags[count])
                    {
                        if (d == null)
                        {
                            string exM = "This ingredient is null";
                            throw new Exception(exM);
                        }
                        return d;
                    }
                    count++;
                }
                //if (d.Name == name)
                //{
                //    return d;
                //}
            }
            return null;
        }

        Day ISearch<Day>.Search(int requestedID)
        {
            foreach (Day d in _days)
            {
                if (d.ID == requestedID)
                {
                    if (d == null)
                    {
                        string exM = "This ingredient is null";
                        throw new Exception(exM);
                    }
                    return d;
                }
            }
            return null;
        }

        Day ISearchDB<Day>.SearchDB(int requestedID)
        {
            return new Day();
            //search through database
        }

        Day ISearchDB<Day>.SearchDB(string name)
        {
            return new Day();
            //search through database
        }

        Day ISearchDB<Day>.SearchDB(string[] tags)
        {
            return new Day();
            //search through database
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
        //`myDB.savedays(myListOfDaysToSaveToTheDB)`, similarly `myDB.getRecipe(int IDOfRecipeToGet)`.

        bool ICanSaveLoad<List<Day>>.Save(List<Day> saveDays)
        {
            //save nput days
            //if succesfully saved
            foreach (Day d in saveDays)
            {
                //myDB.saveday(d);
            }
            return true;
        }

        bool ICanSaveLoad<List<Day>>.Save()
        {
            foreach (Day d in _days)
            {
                //myDB.saveday(d);
            }
            return true;
        }

        List<Day> ICanSaveLoad<List<Day>>.Load(int requestedID)
        {
            List<Day> loadedDays = new List<Day>();

            //loadedDays.Add(myDB.getDay(requestedID));
            //OR//
            //_days.Add(myDB.getDay(requestedID));

            if (loadedDays.Count == 0)
            {
                throw new Exception("No Days have been loaded");
            }
            return loadedDays;
        }

        List<List<Day>> ICanSaveLoad<List<Day>>.LoadAll()
        {
            return new List<List<Day>>();
            //ret
        }

        }
    }