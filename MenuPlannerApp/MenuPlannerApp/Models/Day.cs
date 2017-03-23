using System;
using System.Collections.Generic;

namespace MenuPlanner.Models
{
	public class Day
	{
		private List<Recipe> _recipes;

		private List<string[]> _tags;

		public List<Recipe> Recipes
		{ 
			get { return _recipes;}
		}

		/// <summary>
		/// Gets or sets a list of arrays of strings. These strings act as tag to say what type of recipe each recipe should be.
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

		public void AddRecipe(Recipe toAdd, string[] tag)
		{
			_recipes.Add(toAdd);
			_tags.Add(tag);
		}
	}
}