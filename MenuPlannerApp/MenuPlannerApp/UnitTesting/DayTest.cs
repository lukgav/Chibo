using System;
using System.Collections.Generic;
using NUnit.Framework;
using Chibo.Models;

namespace Chibo.UnitTesting
{
    [TestFixture]
    public class DayTest
    {
        [Test]
        public void DayConstructorTags()
        {
            Day day = new Day();

            Assert.AreEqual(0, day.Tags.Count);

            Assert.AreNotEqual(3, day.Tags.Count);
        }

        [Test]
        public void DayTagsSet()
        {
            Day day = new Day();

            day.Tags = new List<string[]>() { new string[] { "breakfast", "soup", "main" }, new string[] { "lunch", "sandwhich" } };

            Assert.AreEqual(2, day.Tags.Count);

            Assert.AreNotEqual(7, day.Tags.Count);


            Assert.AreEqual(3, day.Tags[0].Length);

            Assert.AreEqual("breakfast", day.Tags[0][0]);

            Assert.AreEqual("soup", day.Tags[0][1]);

            Assert.AreEqual("main", day.Tags[0][2]);


            Assert.AreEqual(2, day.Tags[1].Length);

            Assert.AreEqual("lunch", day.Tags[1][0]);

            Assert.AreEqual("sandwhich", day.Tags[1][1]);
        }

        [Test]
        public void DayConstructorRecipes()
        {
            Day day = new Day();

            Assert.AreEqual(0, day.Recipes.Count);

            Assert.AreNotEqual(6, day.Recipes.Count);
        }

        [Test]
        public void DayMethodAdd()
        {
            Day day = new Day();

            day.Add(new Recipe("taco", new string[] { "do stuff", "other stuff" }, new string[] { "early?", "late?" }), new string[] { "breakfast", "mexican" });

            Assert.AreEqual(1, day.Recipes.Count);

            Assert.AreNotEqual(6, day.Recipes.Count);

            Assert.DoesNotThrow(day.CheckAllignment);
        }

        [Test]
        public void DayMethodRemoveRecipe()
        {
            Day day = new Day();
            Recipe recipe = new Recipe("taco", new string[] { "do stuff", "other stuff" }, new string[] { "early?", "late?" });

            day.Add(recipe, new string[] { "breakfast", "mexican" });

            Assert.AreEqual(1, day.Recipes.Count);

            day.Remove(recipe);

            Assert.AreEqual(0, day.Recipes.Count);
        }

        [Test]
        public void DayMethodRemoveIndex()
        {
            Day day = new Day();
            Recipe recipe = new Recipe("taco", new string[] { "do stuff", "other stuff" }, new string[] { "early?", "late?" });

            day.Add(recipe, new string[] { "breakfast", "mexican" });

            Assert.AreEqual(1, day.Recipes.Count);

            day.RemoveAt(0);

            Assert.AreEqual(0, day.Recipes.Count);
        }
    }
}