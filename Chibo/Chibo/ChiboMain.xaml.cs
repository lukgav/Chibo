using Chibo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Chibo.Data;
using System.Diagnostics;

namespace Chibo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Chibo.Main();
			Menu = new Menu("Chibo");

            Recipes = new List<Recipe>();

            GenerateRecipes();

			string[] testInstructions = new string[] { "This is a sample instruction.", "You can use it to explain how to make a recipe.", "This is a much longer instruction. This instruction can be used to test multiline support on smaller screens." };
            Recipes.Add(new Recipe("Example Recipe (1 Ingredient)", testInstructions, new string[] { }));
            Recipes.Add(new Recipe("Example Recipe (2 Ingredients)", testInstructions, new string[] { }));
            Recipes.Add(new Recipe("Example Recipe (no ingredients)", testInstructions, new string[] { }));
			Recipes.Add(new Recipe("Example 4", testInstructions, new string[] { }));
			Recipes.Add(new Recipe("Example 5", testInstructions, new string[] { }));

			Recipes[0].Ingredients.Add(new Ingredient("Apple", "The round fruit of a tree of the rose family, which typically has thin green or red skin and crisp flesh.", 420, 12));
			Recipes[1].Ingredients.Add(new Ingredient("Orange", "A large round juicy citrus fruit with a tough bright reddish-yellow rind.", 420, 12));
			Recipes[1].Ingredients.Add(new Ingredient("Example Ingredient", "One day this will have a real description, but for now, it's just placeholder text.", 420, 12));
        }


		public Menu Menu { get; set; }
        public List<Recipe> Recipes { get; protected set; }

        public void GenerateRecipes()
        {
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //new chibomain db:
            ChiboMain main = new ChiboMain();


            ChiboDatabase db = ChiboMain.Database;
            Debug.WriteLine("database is created.");
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
