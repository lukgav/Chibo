using System;
using System.Collections.Generic;
using NUnit.Framework;
using Chibo.Models;

namespace Chibo.UnitTesting
{
    [TestFixture]
    public class IngredientTest
    {
        Ingredient ingredient;
        [SetUp]
        public void init()
        {
            ingredient = new Ingredient( "potato", "The apple of the earth", 0.5f, 0.01f );
        }

        [Test]
        public void IngredientConstructorName()
        {
            Assert.AreEqual(ingredient.Name, "potato");

            Assert.AreNotEqual(ingredient.Name, "not a potato");
        }

        [Test]
        public void IngredientConstructorDescription()
        {
            Assert.AreEqual(ingredient.Descrip, "The apple of the earth");

            //lower case t
            Assert.AreNotEqual(ingredient.Descrip, "the apple of the earth");

            Assert.AreNotEqual(ingredient.Descrip, "not the descript");
        }

        [Test]
        public void IngredientConstructorMass()
        {
            Assert.AreEqual(ingredient.Mass, 0.5f);

            Assert.AreNotEqual(ingredient.Mass, 0.03f);

            Assert.AreNotEqual(ingredient.Mass, 5);
        }

        [Test]
        public void IngredientConstructorCaloriesPerGram()
        {
            Assert.AreEqual(ingredient.CaloriesPerGram, 0.01f);

            Assert.AreNotEqual(ingredient.CaloriesPerGram, 0.03f);

            Assert.AreNotEqual(ingredient.CaloriesPerGram, 5);
        }
    }
}