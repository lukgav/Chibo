using Chibo.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Chibo.Views
{
    public partial class RecipesView : ContentPage
    {
        public RecipesView()
        {
            InitializeComponent();

            // get recipes
            // todo: replace with db
            List<Recipe> recipes = new List<Recipe>();
            recipes.Add(new Recipe("Test Recipe", new string[] { "Do something", "something else" }, new string[] { "test" }));
            RecipesList.ItemsSource = recipes;

            // show/hide the label
            NoRecipesLabel.IsVisible = recipes.Count == 0;
        }

        /// <summary>
        /// Triggered when a item is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RecipesList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Recipe selectedItem = (Recipe)(e.Item);
            RecipesList.SelectedItem = null;
            await Navigation.PushAsync(new ViewRecipeView(selectedItem));
        }
    }
}
