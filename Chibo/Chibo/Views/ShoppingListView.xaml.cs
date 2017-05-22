using Chibo.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chibo.Views
{
    /// <summary>
    /// Shopping list view
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingListView : ContentPage
    {    
        public ShoppingListView()
        {
            InitializeComponent();

            // get the shopping list from the menu method
            ListIngredients ingredients = (Application.Current as App).Menu.CompileShoppingList();

            // assign it to the list element
            ShoppingList.ItemsSource = ingredients.Ingredients;

            // set the label accordingly
            ShoppingListCount.Text = String.Format("You have {0} items on your shopping list.", ingredients.Ingredients.Count);
        }
    }
}
