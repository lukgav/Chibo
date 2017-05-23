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
    /// The view to view details about an ingredient
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewIngredientView : ContentPage
    {
        /// <summary>
        /// The ingredient for this page
        /// </summary>
        public Ingredient Ingredient { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chibo.Views.ViewIngredientView"/> class.
        /// </summary>
        public ViewIngredientView(Ingredient ingredient)
        {
            InitializeComponent();

            // set the ingredient
            Ingredient = ingredient;

            // assign labels to the ingredient attributes
            IngredientName.Text = Ingredient.Name;
            IngredientDescription.Text = Ingredient.Descrip;

            // set the page title
            Title = String.Format("Ingredient ({0})", Ingredient.Name);
        }
    }
}
