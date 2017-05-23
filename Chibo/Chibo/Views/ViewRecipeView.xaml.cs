using Chibo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chibo.Views
{
    /// <summary>
    /// The view to view a specific recipe
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewRecipeView : ContentPage
    {
        /// <summary>
        /// The recipe being viewed
        /// </summary>
        public Recipe Recipe { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chibo.Views.ViewRecipeView"/> class.
        /// </summary>
        /// <param name="recipe"></param>
        public ViewRecipeView(Recipe recipe)
        {
            InitializeComponent();
            // assign the recipe
            Recipe = recipe;

            // set the name label
            RecipeName.Text = recipe.Name;
            Title = String.Format("Recipe ({0})", recipe.Name);

            // iterate through the instructions, generating an ordered list
            int i = 0;
            foreach(string instruction in recipe.Instruction)
            {
                i++;
                InstructionsLabel.Text += String.Format("{0}: {1}\n", i, instruction);
            }

            // assign the ingredients list the recipe's ingredients
            IngredientsList.ItemsSource = recipe.Ingredients.Ingredients;
        }

        private async void IngredientsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // get the tapped ingredient
            Ingredient ingredient = (Ingredient)(e.Item);

            // set the selected item on the list to null so it dosen't prevent future selections
            IngredientsList.SelectedItem = null;

            // change to the view recipe page
            await Navigation.PushAsync(new ViewIngredientView(ingredient));
        }
    }
}
