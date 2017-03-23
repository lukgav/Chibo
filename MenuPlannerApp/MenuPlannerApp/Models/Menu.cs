using System;
using System.Collections.Generic;

namespace Menus
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

		public Menu(string name)
		{
			_name = name;

			_days = new List<Day>();
		}

		public void AddDay(Day toAdd)
		{
			_days.Add(toAdd);
		}

		public void AddDay()
		{
			_days.Add(new Day());
		}

		public void RemoveDay(int index)
		{
			_days.RemoveAt(index);
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