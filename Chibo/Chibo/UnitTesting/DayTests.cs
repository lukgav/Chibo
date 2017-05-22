//using System;
//using System.Text;
//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Chibo.Models
//{
//    /// <summary>
//    /// Summary description for DayTests
//    /// </summary>
//    /// 
    
//    [TestClass]
//    public class DayTests
//    {
//        [TestMethod]
//        public void DayConstructorTags()
//        {
//            Day day = new Day();

//            Assert.AreEqual(0, day.Tags.Count);

//            Assert.AreNotEqual(3, day.Tags.Count);
//        }

//        [TestMethod]
//        public void DayTagsSet()
//        {
//            Day day = new Day();

//            day.Tags = new List<string[]>() { new string[] { "breakfast", "soup", "main" }, new string[] { "lunch", "sandwhich" } };

//            Assert.AreEqual(2, day.Tags.Count);

//            Assert.AreNotEqual(7, day.Tags.Count);


//            Assert.AreEqual(3, day.Tags[0].Length);

//            Assert.AreEqual("breakfast", day.Tags[0][0]);

//            Assert.AreEqual("soup", day.Tags[0][1]);

//            Assert.AreEqual("main", day.Tags[0][2]);


//            Assert.AreEqual(2, day.Tags[1].Length);

//            Assert.AreEqual("lunch", day.Tags[1][0]);

//            Assert.AreEqual("sandwhich", day.Tags[1][1]);
//        }

//        [TestMethod]
//        public void DayConstructorRecipes()
//        {
//            Day day = new Day();

//            Assert.AreEqual(0, day.Recipes.Count);

//            Assert.AreNotEqual(6, day.Recipes.Count);
//        }

//        [TestMethod]
//        public void DayMethodAddRecipe()
//        {
//            int index = 0;
//            Day day = new Day();
//            Recipe Taco = new Recipe("taco", new string[] { "do stuff", "other stuff" }, new string[] { "early?", "late?" });
//            string[] preferenceTags = { "dinner", "pancakes", "lunch" };

//            day.AddRecipe(preferenceTags);

//            Assert.AreEqual(1, day.Recipes.Count);

//            Assert.AreNotEqual(6, day.Recipes.Count);

//            //match tags of Day to tags of prefernceTags
//            Assert.AreEqual(day.Tags[index], preferenceTags);

//            //Match one tag of Day to one tag of Recipe Taco
//            Assert.AreEqual(day.Tags[index][index], preferenceTags[index]);

//            //test Non matching indexes 
//            int incorrectIndex = 1;
//            Assert.AreNotEqual(day.Tags[index][index], preferenceTags[incorrectIndex]);
//            //Assert.DoesNotThrow(day.CheckAllignment); //Will have to check this out
//        }

//        [TestMethod]
//        public void DayMethodRemoveRecipe()
//        {
//            Day day = new Day();
//            Recipe recipe = new Recipe("stew", new string[] { "peel potatos", "stew potatos", "dinner" }, new string[] { "dinner", "lunch", "stew" });
//            string[] preferenceTags = { "dinner", "pancakes", "lunch" };

//            day.AddRecipe(preferenceTags);

//            Assert.AreEqual(1, day.Recipes.Count);

//            day.Remove(recipe);

//            Assert.AreEqual(0, day.Recipes.Count);
//        }

//        [TestMethod]
//        public void DayMethodRemoveIndex()
//        {
//            Day day = new Day();
//            Recipe recipe = new Recipe("taco", new string[] { "do stuff", "other stuff" }, new string[] { "early?", "late?" });
//            string[] preferenceTags = { "dinner", "pancakes", "lunch" };

//            day.AddRecipe(preferenceTags);

//            Assert.AreEqual(1, day.Recipes.Count);

//            day.RemoveAt(0);

//            Assert.AreEqual(0, day.Recipes.Count);
//        }

//        [TestMethod]
//        public void DayMethodRandomiseRecipe()
//        {
//            Day day = new Day();

//            //Recipe Stew = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos", "dinner" }, new string[] { "dinner", "lunch", "stew" });
//            string[] preferenceTags = { "dinner", "stew", "lunch" };

//            day.AddRecipe(preferenceTags);
//            int index = 0;
//            day.RandomiseRecipe(index);

//            Recipe foundRecipe = day.Recipes[index];
//            Assert.AreEqual(preferenceTags[index], foundRecipe.Tags[index]);
//            //check next iteration
//            Recipe placeHolder = new Recipe("stew", new string[] { "peel potatos", "stew potatos", "dinner" }, new string[] { "dinner", "lunch", "stew" });

//            day.AddRecipe(preferenceTags);
//            index = 1;
//            day.RandomiseRecipe(index);
//            foundRecipe = day.Recipes[index];
//            Assert.AreEqual(placeHolder.Name, foundRecipe.Name);
//        }

//        [TestMethod]
//        public void DayMethodRandomiseAll()
//        {
//            Day day = new Day();

//            Recipe Stew = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos", "dinner" }, new string[] { "dinner", "lunch", "stew" });
//            Recipe FruityIceCream = new Recipe("fruity ice cream", new string[] { "fruit", "ice", "cream" }, new string[] { "dessert", "tasty", "fruit" });
//            Recipe FriedRice = new Recipe("fried rice", new string[] { "peas", "rice", "soy sauce" }, new string[] { "dinner", "lunch", "stew", "tasty" });
//            Recipe ImVegan = new Recipe("im vegan", new string[] { "bones", "blood", "contempt" }, new string[] { "healthy", "lunch" });
//            Recipe Taco = new Recipe("taco", new string[] { "do stuff", "other stuff" }, new string[] { "breakfast", "mexican" });
//            string[] preferenceTags = { "dinner", "pancakes", "lunch" };

//            Recipe[] recipes = { Stew, FruityIceCream, FriedRice, ImVegan, Taco };
//            foreach (Recipe r in recipes)
//            {
//                day.AddRecipe(preferenceTags);
//            }

//        }
//    }
//}
