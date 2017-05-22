//using System;
//using System.Text;
//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Chibo.Models
//{
//    /// <summary>
//    /// Summary description for RecipeTests
//    /// </summary>
//    [TestClass]
//    public class RecipeTests
//    {

//        Recipe Stew = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos", "dinner" }, new string[] { "dinner", "lunch", "stew" });

//        [TestMethod]
//        public void RecipeConstructorName()
//        {
//            Recipe recipe = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos" }, new string[] { "dinner", "lunch", "stew" });

//            Assert.AreEqual(recipe.Name, "potato stew");

//            Assert.AreNotEqual(recipe.Name, "not a potato stew");
//        }

//        [TestMethod]
//        public void RecipeconstructorInstruction()
//        {
//            Recipe recipe = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos" }, new string[] { "dinner", "lunch", "stew" });

//            Assert.AreEqual(2, recipe.Instruction.Length);

//            Assert.AreNotEqual(5, recipe.Instruction.Length);


//            Assert.AreEqual("peel potatos", recipe.Instruction[0]);

//            Assert.AreNotEqual("cut a carrot", recipe.Instruction[0]);


//            Assert.AreEqual("stew potatos", recipe.Instruction[1]);

//            Assert.AreNotEqual("boild celery", recipe.Instruction[1]);
//        }

//        [TestMethod]
//        public void RecipeInstructionSet()
//        {
//            Recipe recipe = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos" }, new string[] { "dinner", "lunch", "stew" });

//            recipe.Instruction = new string[] { "wash potatos", "cut potatos", "light stove" };

//            Assert.AreEqual(3, recipe.Instruction.Length);

//            Assert.AreNotEqual(5, recipe.Instruction.Length);


//            Assert.AreEqual("wash potatos", recipe.Instruction[0]);

//            Assert.AreNotEqual("cut a carrot", recipe.Instruction[0]);


//            Assert.AreEqual("cut potatos", recipe.Instruction[1]);

//            Assert.AreNotEqual("burn potatos", recipe.Instruction[1]);


//            Assert.AreEqual("light stove", recipe.Instruction[2]);

//            Assert.AreNotEqual("nuke potatos", recipe.Instruction[2]);
//        }

//        [TestMethod]
//        public void RecipeconstructorTags()
//        {
//            Recipe recipe = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos" }, new string[] { "dinner", "lunch", "stew" });

//            Assert.AreEqual(3, recipe.Tags.Length);

//            Assert.AreNotEqual(5, recipe.Tags.Length);


//            Assert.AreEqual("dinner", recipe.Tags[0]);

//            Assert.AreNotEqual("cut a carrot", recipe.Tags[0]);


//            Assert.AreEqual("lunch", recipe.Tags[1]);

//            Assert.AreNotEqual("boild celery", recipe.Tags[1]);

//            Assert.AreEqual("stew", recipe.Tags[2]);

//            Assert.AreNotEqual("nuke celery", recipe.Tags[2]);
//        }

//        [TestMethod]
//        public void RecipeTagSet()
//        {
//            Recipe recipe = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos" }, new string[] { "dinner", "lunch", "stew" });

//            recipe.Tags = new string[] { "breakfast", "midnight" };

//            Assert.AreEqual(2, recipe.Tags.Length);

//            Assert.AreNotEqual(5, recipe.Tags.Length);


//            Assert.AreEqual("breakfast", recipe.Tags[0]);

//            Assert.AreNotEqual("cut a carrot", recipe.Tags[0]);


//            Assert.AreEqual("midnight", recipe.Tags[1]);

//            Assert.AreNotEqual("burn potatos", recipe.Tags[1]);
//        }

//        [TestMethod]
//        public void RecipeConstructorIngredients()
//        {
//            Recipe recipe = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos" }, new string[] { "dinner", "lunch", "stew" });

//            Assert.AreEqual(0, recipe.Ingredients.NumberOfIngredients);

//            Assert.AreNotEqual(5, recipe.Ingredients.NumberOfIngredients);
//        }

//        [TestMethod]
//        public void RecipeMethodAdd()
//        {
//            Recipe recipe = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos" }, new string[] { "dinner", "lunch", "stew" });

//            recipe.Add(new Ingredient("potato", "apple of the earth", 0, 0.05f), 0.5f);

//            Assert.AreEqual(1, recipe.Ingredients.NumberOfIngredients);

//            Assert.AreEqual(0.5f, recipe.Ingredients.Ingredients[0].Mass);


//            recipe.Add(new Ingredient("potato", "apple of the earth", 0, 0.05f), 0.5f);

//            Assert.AreEqual(1, recipe.Ingredients.NumberOfIngredients);

//            Assert.AreEqual(1.0f, recipe.Ingredients.Ingredients[0].Mass);


//            recipe.Add(new Ingredient("carrot", "horses love them", 0, 0.01f), 0.7f);

//            Assert.AreEqual(2, recipe.Ingredients.NumberOfIngredients);

//            Assert.AreEqual(0.7f, recipe.Ingredients.Ingredients[1].Mass);


//            recipe.Add(new Ingredient("carrot", "horses love them", 0, 0.01f), 0.7f);

//            Assert.AreEqual(2, recipe.Ingredients.NumberOfIngredients);

//            Assert.AreEqual(1.4f, recipe.Ingredients.Ingredients[1].Mass);
//        }

//        [TestMethod]
//        public void RecipeMethodRemove()
//        {
//            Recipe recipe = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos" }, new string[] { "dinner", "lunch", "stew" });

//            recipe.Add(new Ingredient("potato", "apple of the earth", 0, 0.05f), 0.5f);

//            recipe.Add(new Ingredient("potato", "apple of the earth", 0, 0.05f), 0.5f);

//            recipe.Add(new Ingredient("carrot", "horses love them", 0, 0.01f), 0.7f);

//            recipe.Add(new Ingredient("carrot", "horses love them", 0, 0.01f), 0.7f);


//            Assert.AreEqual(2, recipe.Ingredients.NumberOfIngredients);

//            recipe.Remove(new Ingredient("carrot", "horses love them", 0, 0.01f), 0.7f);

//            Assert.AreEqual(2, recipe.Ingredients.NumberOfIngredients);

//            recipe.Remove(new Ingredient("carrot", "horses love them", 0, 0.01f), 0.7f);

//            Assert.AreEqual(1, recipe.Ingredients.NumberOfIngredients);

//            recipe.Remove(new Ingredient("potato", "apple of the earth", 0, 0.05f), 1.0f);

//            Assert.AreEqual(0, recipe.Ingredients.NumberOfIngredients);
//        }

//        [TestMethod]
//        public void RecipeMethodFitsTags()
//        {
//            Recipe recipe = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos" }, new string[] { "dinner", "lunch", "stew", "potato" });

//            string[] perfectMatchtTags = { "dinner", "lunch", "stew", "potato" };
//            string[] nullTags = { "" };
//            string[] NoMatchTags = { "dessert", "candy", "black" };
//            string[] halfMatchtTags = { "dinner", "dessert" };

//            //test perfect Match
//            double expected = 1;
//            double actual = recipe.FitsTags(perfectMatchtTags);
//            Assert.AreEqual(expected, actual);

//            //test null Match
//            expected = 0;
//            actual = recipe.FitsTags(nullTags);
//            Assert.AreEqual(expected, actual);

//            //test no Match 
//            actual = recipe.FitsTags(NoMatchTags);
//            Assert.AreEqual(expected, actual);

//            //test partial Match
//            expected = 0.5;
//            actual = recipe.FitsTags(halfMatchtTags);
//            Assert.AreEqual(expected, actual);

//        }

//        [TestMethod]
//        public void RecipeMethodRandomRecipe() //this is testing the code without the database
//        {
//            double likenessPercentage = 0.5;
//            double easyLikenessPercentage = 0.2;
//            double hardLikenessPercentage = 0.8;

//            string[] fullTags = { "dinner", "breakfast", "lunch", "dessert", "fruit", "healthy", "tasty" };
//            string[] friedRiceTags = { "dinner", "lunch", "rice" };
//            string[] stewTag = { "stew" };
//            string[] emptyTags = { "" };

//            //These reciprs are to be put in the RandomRecipe class if the database is not working.
//            Recipe placeHolder = new Recipe("stew", new string[] { "peel potatos", "stew potatos", "dinner" }, new string[] { "dinner", "lunch", "stew" });
//            Recipe FruityIceCream = new Recipe("fruity ice cream", new string[] { "fruit", "ice", "cream" }, new string[] { "dessert", "tasty", "fruit" });
//            Recipe FriedRice = new Recipe("fried rice", new string[] { "peas", "rice", "soy sauce" }, new string[] { "dinner", "lunch", "stew", "tasty" });
//            Recipe ImVegan = new Recipe("im vegan", new string[] { "bones", "blood", "contempt" }, new string[] { "healthy", "lunch" });

//            //check if returns null
//            Recipe expected = null;
//            Recipe actual = Recipe.RandomRecipe(emptyTags, likenessPercentage);
//            Assert.AreEqual(expected, actual);

//            //check if returns !null
//            expected = FriedRice;
//            actual = Recipe.RandomRecipe(fullTags, easyLikenessPercentage);
//            Assert.IsNotNull(actual);

//            //check if returns Recipe
//            expected = FriedRice;
//            actual = Recipe.RandomRecipe(fullTags, easyLikenessPercentage);
//            Assert.AreEqual(actual.GetType(), expected.GetType());

//            //Check if returns specific recipe from specific tags
//            expected = placeHolder;
//            actual = Recipe.RandomRecipe(stewTag, easyLikenessPercentage);
//            Assert.AreEqual(expected.Name, actual.Name);

//            //Check if returns specific recipe from specific tags
//            expected = FriedRice;
//            actual = Recipe.RandomRecipe(friedRiceTags, hardLikenessPercentage);
//            Assert.AreEqual(expected.Name, actual.Name);
//        }

//        [TestMethod]
//        public void RecipeMethodHasTag() //this is testing the code without the database
//        {
//            Recipe Stew = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos", "dinner" }, new string[] { "dinner", "lunch", "stew" });
//            string expected = "stew";

//            Assert.IsTrue(Stew.HasTag(expected));
//        }

//        [TestMethod]
//        public void RecipeMethodSameID() //this is testing the code without the database
//        {
//            Recipe Stew = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos", "dinner" }, new string[] { "dinner", "lunch", "stew" });
//            Recipe PumpkinStew = new Recipe("pumpkin stew", new string[] { "peel potatos", "stew potatos", "dinner" }, new string[] { "dinner", "lunch", "stew" });

//            Assert.IsTrue(Stew.SameID(PumpkinStew)); //FIXME: test only works becuase both IDs are null!
//        }
//    }
//}