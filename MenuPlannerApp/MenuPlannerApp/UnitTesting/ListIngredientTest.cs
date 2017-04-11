using System;
using System.Collections.Generic;
using NUnit.Framework;
using Chibo.Models;

namespace Chibo.UnitTesting
{
    [TestFixture]
    public class ListIngredientTest
    {
        ListIngredients listIngredient;

        [SetUp]
        public void init()
        {
            listIngredient = new ListIngredients();
        }

        [Test]
        public void ConstructorName()
        {
            Assert.True(true);
        }
    }
}