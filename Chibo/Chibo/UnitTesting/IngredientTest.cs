using System;
using System.Collections.Generic;
using NUnit.Framework;
using Chibo.Models;

namespace Chibo.UnitTesting
{
    [TestFixture]
    public class IngredientTest
    {
        [Test]
        public void IngredientConstructorName()
        {
            Ingredient ingredient = new Ingredient("potato", "The apple of the earth", 0.5f, 0.01f);

            Assert.AreEqual(ingredient.Name, "potato");

            Assert.AreNotEqual(ingredient.Name, "not a potato");
        }

        [Test]
        public void IngredientConstructorDescription()
        {
            Ingredient ingredient = new Ingredient("potato", "The apple of the earth", 0.5f, 0.01f);

            Assert.AreEqual(ingredient.Descrip, "The apple of the earth");

            //lower case t
            Assert.AreNotEqual(ingredient.Descrip, "the apple of the earth");

            Assert.AreNotEqual(ingredient.Descrip, "not the descript");
        }

        [Test]
        public void IngredientConstructorMass()
        {
            Ingredient ingredient = new Ingredient("potato", "The apple of the earth", 0.5f, 0.01f);

            Assert.AreEqual(ingredient.Mass, 0.5f);

            Assert.AreNotEqual(ingredient.Mass, 0.03f);

            Assert.AreNotEqual(ingredient.Mass, 5);
        }

        [Test]
        public void IngredientMassSet()
        {
            Ingredient ingredient = new Ingredient("potato", "The apple of the earth", 0.5f, 0.01f);

            ingredient.Mass = 1.5f;

            Assert.AreEqual(ingredient.Mass, 1.5f);

            Assert.AreNotEqual(ingredient.Mass, 0.03f);

            Assert.AreNotEqual(ingredient.Mass, 5);
        }

        [Test]
        public void IngredientConstructorCaloriesPerGram()
        {
            Ingredient ingredient = new Ingredient("potato", "The apple of the earth", 0.5f, 0.01f);

            Assert.AreEqual(ingredient.CaloriesPerGram, 0.01f);

            Assert.AreNotEqual(ingredient.CaloriesPerGram, 0.03f);

            Assert.AreNotEqual(ingredient.CaloriesPerGram, 5);
        }

        [Test]
        public void IngredientNumberOfGet()
        {
            Ingredient ingredient = new Ingredient("potato", "The apple of the earth", 0.5f, 0.01f);

            Assert.AreEqual(0, ingredient.NumberOfIngredients);

            Assert.AreNotEqual(5, ingredient.NumberOfIngredients);

            Assert.AreNotEqual(0.02f, ingredient.NumberOfIngredients);
        }

        [Test]
        public void IngredientNumberOfSet()
        {
            Ingredient ingredient = new Ingredient("potato", "The apple of the earth", 0.5f, 0.01f);

            ingredient.NumberOfIngredients = 400;

            Assert.AreEqual(400, ingredient.NumberOfIngredients);

            Assert.AreNotEqual(5, ingredient.NumberOfIngredients);

            Assert.AreNotEqual(0.02f, ingredient.NumberOfIngredients);
        }
    }
}