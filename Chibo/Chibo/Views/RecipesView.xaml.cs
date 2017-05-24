using Chibo.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Chibo.Views
{
    /// <summary>
    /// View containing a list of all the recipes
    /// </summary>
    public partial class RecipesView : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chibo.Views.RecipesView"/> class.
        /// </summary>
        public RecipesView()
        {
            InitializeComponent();

            // get the recipes
            List<Recipe> recipes = (Application.Current as App).Recipes;

            // assign the recipes list element with the recipes
            RecipesList.ItemsSource = recipes;

            // show/hide the 'You have no recipes' label
            NoRecipesLabel.IsVisible = recipes.Count == 0;
        }

        /// <summary>
        /// Triggered when a item is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RecipesList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // get the tapped item
            Recipe selectedItem = (Recipe)(e.Item);
            // set the selected item on the list to null so it dosen't prevent future selections
            RecipesList.SelectedItem = null;
            // change to the view recipe page
            await Navigation.PushAsync(new ViewRecipeView(selectedItem));
        }
    }
}
