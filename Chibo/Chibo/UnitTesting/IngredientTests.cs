//using System;
//using System.Text;
//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Chibo.Models
//{
//    /// <summary>
//    /// Summary description for DayTests
//    /// </summary>
//    [TestClass]
//    public class IngredientTests
//    {
//        public IngredientTests()
//        {
//            Day day = new Day();

//            //
//            // TODO: Add constructor logic herez
//            //
//        }
//        [TestMethod]
//        public void IngredientConstructorName()
//        {
//            Ingredient ingredient = new Ingredient("potato", "The apple of the earth", 0.5f, 0.01f);

//            Assert.AreEqual(ingredient.Name, "potato");

//            Assert.AreNotEqual(ingredient.Name, "not a potato");
//        }

//        [TestMethod]
//        public void IngredientConstructorDescription()
//        {
//            Ingredient ingredient = new Ingredient("potato", "The apple of the earth", 0.5f, 0.01f);

//            Assert.AreEqual(ingredient.Descrip, "The apple of the earth");

//            //lower case t
//            Assert.AreNotEqual(ingredient.Descrip, "the apple of the earth");

//            Assert.AreNotEqual(ingredient.Descrip, "not the descript");
//        }

//        [TestMethod]
//        public void IngredientConstructorMass()
//        {
//            Ingredient ingredient = new Ingredient("potato", "The apple of the earth", 0.5f, 0.01f);

//            Assert.AreEqual(ingredient.Mass, 0.5f);

//            Assert.AreNotEqual(ingredient.Mass, 0.03f);

//            Assert.AreNotEqual(ingredient.Mass, 5);
//        }

//        [TestMethod]
//        public void IngredientMassSet()
//        {
//            Ingredient ingredient = new Ingredient("potato", "The apple of the earth", 0.5f, 0.01f);

//            ingredient.Mass = 1.5f;

//            Assert.AreEqual(ingredient.Mass, 1.5f);

//            Assert.AreNotEqual(ingredient.Mass, 0.03f);

//            Assert.AreNotEqual(ingredient.Mass, 5);
//        }

//        [TestMethod]
//        public void IngredientConstructorCaloriesPerGram()
//        {
//            Ingredient ingredient = new Ingredient("potato", "The apple of the earth", 0.5f, 0.01f);

//            Assert.AreEqual(ingredient.CaloriesPerGram, 0.01f);

//            Assert.AreNotEqual(ingredient.CaloriesPerGram, 0.03f);

//            Assert.AreNotEqual(ingredient.CaloriesPerGram, 5);
//        }

//        [TestMethod]
//        public void IngredientNumberOfGet()
//        {
//            Ingredient ingredient = new Ingredient("potato", "The apple of the earth", 0.5f, 0.01f);

//            Assert.AreEqual(0, ingredient.NumberOfIngredients);

//            Assert.AreNotEqual(5, ingredient.NumberOfIngredients);

//            Assert.AreNotEqual(0.02f, ingredient.NumberOfIngredients);
//        }

//        [TestMethod]
//        public void IngredientNumberOfSet()
//        {
//            Ingredient ingredient = new Ingredient("potato", "The apple of the earth", 0.5f, 0.01f);

//            ingredient.NumberOfIngredients = 400;

//            Assert.AreEqual(400, ingredient.NumberOfIngredients);

//            Assert.AreNotEqual(5, ingredient.NumberOfIngredients);

//            Assert.AreNotEqual(0.02f, ingredient.NumberOfIngredients);
//        }
//    }
//}