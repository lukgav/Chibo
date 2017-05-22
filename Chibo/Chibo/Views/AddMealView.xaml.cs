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
        /// Whether or not the day is being edited, used to pass between AddDay instances
        /// </summary>
        public bool IsEditing;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chibo.Views.AddMealView"/> class.
        /// </summary>
        public AddMealView(Day day, bool isEditing)
        {
            InitializeComponent();

            // setup the day
            Day = day;

            // todo: add call to get stored recipes
            string[] testInstructions = new string[] { "Test", "Another Test", "This is a much longer instruction. Hopefully this will be able to test multiline support." };
            Recipes.Add(new Recipe("Example One", testInstructions, new string[] { }));
            Recipes.Add(new Recipe("Example Two", testInstructions, new string[] { }));
            Recipes.Add(new Recipe("Another One", testInstructions, new string[] { }));
            Recipes.Add(new Recipe("Lorum", testInstructions, new string[] { }));
            Recipes.Add(new Recipe("Ipsum", testInstructions, new string[] { }));
            Recipes[0].Ingredients.Add(new Ingredient("Apple", "This is an apple.", 420, 12));

            // assign recipes to list
            MealItems.ItemsSource = Recipes;
            IsEditing = isEditing;

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
            // prevent inserting null entries
            if (MealItems.SelectedItem == null)
                return;

            // add the recipe to the day
            Day.Recipes.Add((Recipe)MealItems.SelectedItem);

            // go back to the add day view
            Navigation.PushAsync(new AddDayView(Day, IsEditing));
        }
    }

}