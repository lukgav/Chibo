using System;
using System.Collections.Generic;
using NUnit.Framework;
using Chibo.Models;

namespace Chibo.UnitTesting
{
    [TestFixture]
    public class TestsSample
    {
        Ingredient ingredient;
        [SetUp]
        public void init()
        {
            ingredient = new Ingredient();
        }
        
        [TearDown]  //what is a teardown???
        public void Tear() { }
        
        [Test]
        public void IngredientConstructor()
        {
            //Console.WriteLine("test1");
            
            Assert.True(ingredient.IngName.Equals("potatoe"));
            Assert.True(ingredient.IngDescrip.Equals("Known as 'apple of the earth' in French it is an earthy vegetable found in the ground. Considered healthy although its calorie content is rather high for ever gram."));
            Assert.True(ingredient.IngMass.Equals(300.3));
            Assert.True(ingredient.IngCaloriesPerGram.Equals(20));
        }
    }
}