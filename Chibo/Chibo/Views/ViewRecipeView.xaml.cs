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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewRecipeView : ContentPage
    {
        public Recipe Recipe { get; set; }

        public ViewRecipeView(Recipe recipe)
        {
            InitializeComponent();
            Recipe = recipe;

            RecipeName.Text = recipe.Name;
        }
    }
}
