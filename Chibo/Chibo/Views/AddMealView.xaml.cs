using System;
using System.Collections.Generic;
using Chibo.Models;
using Xamarin.Forms;

namespace Chibo.Views
{
    /// <summary>
    /// Add meal view.
    /// </summary>
    public partial class AddMealView : ContentPage
    {
        /// <summary>
        /// All the stored recipes 
        /// </summary>
        public List<Recipe> Recipes = new List<Recipe>();

        /// <summary>
        /// The day.
        /// </summary>
        public Day Day;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chibo.Views.AddMealView"/> class.
        /// </summary>
        public AddMealView(Day day)
        {
            InitializeComponent();

            // setup the day
            Day = day;

            // todo: add call to get stored recipes
			Recipes.Add(new Recipe() { Name = "Example One" });
			Recipes.Add(new Recipe() { Name = "Example Two" });
			Recipes.Add(new Recipe() { Name = "Another One" });

            // assign recipes to list
            MealItems.ItemsSource = Recipes;

        }

        /// <summary>
        /// Handles when the search filter changes, updating the list
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            // prepare variables
            List<Recipe> filteredRecipes = new List<Recipe>();
            string filter = SearchFilter.Text;

            // if the filter is empty, just load all the recipes
            if (filter == "")
            {
                MealItems.ItemsSource = Recipes;
                return;
            }

            // generate the filtered list
            foreach(Recipe recipe in Recipes)
            {
                if(recipe.Name.ToLower().Contains(filter.ToLower()))
                {
                    filteredRecipes.Add(recipe);
                }
            }

            // assign the list to the UI
            MealItems.ItemsSource = filteredRecipes;
        }

        /// <summary>
        /// Handles the adding of recipes
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Day.Recipes.Add((Recipe)MealItems.SelectedItem);
            Navigation.PushAsync(new AddDayView(Day));
        }
    }

}