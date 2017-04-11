using System;
using System.Collections.Generic;
using NUnit.Framework;
using Chibo.Models;

namespace Chibo.UnitTesting
{
    [TestFixture]
    public class ListIngredientTest
    {
        [Test]
        public void ListIngredientConstructorNumberOfIngredients()
        {
            ListIngredients lsIng = new ListIngredients();

            Assert.AreEqual(0, lsIng.NumberOfIngredients);

            lsIng = new ListIngredients(new List<Ingredient>());

            Assert.AreEqual(0, lsIng.NumberOfIngredients);

            lsIng = new ListIngredients(new List<Ingredient>() { new Ingredient("spinach", "yuck", 0.04f, 0.01f), new Ingredient("tomato", "yum", 0.64f, 0.51f), new Ingredient("cauliflower", "ehh", 0.00f, 0.12f) });

            Assert.AreEqual(3, lsIng.NumberOfIngredients);
        }

        [Test]
        public void ListIngredientMergeListIngredient()
        {
            ListIngredients lsIng = new ListIngredients();
            ListIngredients lsToMerge1 = new ListIngredients(new List<Ingredient>() { new Ingredient("spinach", "yuck", 0.04f, 0.01f), new Ingredient("tomato", "yum", 0.64f, 0.51f), new Ingredient("cauliflower", "ehh", 0.00f, 0.12f) });
            ListIngredients lsToMerge2 = new ListIngredients(new List<Ingredient>() { new Ingredient("brocolli", "yuck", 0.04f, 0.01f) });

            Assert.AreEqual(0, lsIng.NumberOfIngredients);

            lsIng.Merge(lsToMerge1);

            Assert.AreEqual(3, lsIng.NumberOfIngredients);

            lsIng.Merge(lsToMerge1);

            Assert.AreEqual(3, lsIng.NumberOfIngredients);

            lsIng.Merge(lsToMerge2);

            Assert.AreEqual(4, lsIng.NumberOfIngredients);
        }

        [Test]
        public void ListIngredientMergeList()
        {
            ListIngredients lsIng = new ListIngredients();
            List<Ingredient> lsToMerge1 = new List<Ingredient>() { new Ingredient("spinach", "yuck", 0.04f, 0.01f), new Ingredient("tomato", "yum", 0.64f, 0.51f), new Ingredient("cauliflower", "ehh", 0.00f, 0.12f) };
            List<Ingredient> lsToMerge2 = new List<Ingredient>() { new Ingredient("brocolli", "yuck", 0.04f, 0.01f)};

            Assert.AreEqual(0, lsIng.NumberOfIngredients);

            lsIng.Merge(lsToMerge1);

            Assert.AreEqual(3, lsIng.NumberOfIngredients);

            lsIng.Merge(lsToMerge1);

            Assert.AreEqual(3, lsIng.NumberOfIngredients);

            lsIng.Merge(lsToMerge2);

            Assert.AreEqual(4, lsIng.NumberOfIngredients);
        }
    }
}