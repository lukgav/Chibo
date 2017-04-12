using System;
using System.Collections.Generic;
using NUnit.Framework;
using Chibo.Models;

namespace Chibo.UnitTesting
{
    [TestFixture]
    public class MenuTest
    {
        [Test]
        public void MenuConstructorName()
        {
            Menu menu = new Menu("test");

            Assert.AreEqual("test", menu.Name);

            Assert.AreNotEqual("Random stuff", menu.Name);
        }

        [Test]
        public void MenuNameSet()
        {
            Menu menu = new Menu("test");

            Assert.AreEqual("test", menu.Name);

            menu.Name = "workout mix 1";

            Assert.AreEqual("workout mix 1", menu.Name);
        }

        [Test]
        public void MenuConstructorNumberOfDays()
        {
            Menu menu = new Menu("test");

            Assert.AreEqual(0, menu.NumberOfDays);

            Assert.AreNotEqual(1732, menu.NumberOfDays);
        }

        [Test]
        public void MenuMethodAddDay()
        {
            Menu menu = new Menu("test");

            menu.AddDay();

            Assert.AreEqual(1, menu.NumberOfDays);

            menu.AddDay();

            Assert.AreEqual(2, menu.NumberOfDays);

            menu.AddDay();

            Assert.AreEqual(3, menu.NumberOfDays);

            Assert.AreNotEqual(1732, menu.NumberOfDays);
        }

        [Test]
        public void MenuMethodAddDayInputDay()
        {
            Menu menu = new Menu("test");

            Day dayToAdd = new Day();

            menu.AddDay(dayToAdd);

            Assert.AreEqual(1, menu.NumberOfDays);

            menu.AddDay(dayToAdd);

            Assert.AreEqual(2, menu.NumberOfDays);

            menu.AddDay(dayToAdd);

            Assert.AreEqual(3, menu.NumberOfDays);

            Assert.AreNotEqual(1732, menu.NumberOfDays);
        }

        [Test]
        public void MenuMethodRemoveAt()
        {
            Menu menu = new Menu("test");

            menu.AddDay();

            Assert.AreEqual(1, menu.NumberOfDays);

            menu.AddDay();

            Assert.AreEqual(2, menu.NumberOfDays);

            menu.AddDay();

            Assert.AreEqual(3, menu.NumberOfDays);

            menu.RemoveAt(2);

            Assert.AreEqual(2, menu.NumberOfDays);

            menu.RemoveAt(0);

            Assert.AreEqual(1, menu.NumberOfDays);

            menu.RemoveAt(0);

            Assert.AreEqual(0, menu.NumberOfDays);

            menu.RemoveAt(0);

            Assert.AreEqual(0, menu.NumberOfDays);
        }

        [Test]
        public void MenuMethodCompileShoppingList()
        {
            Menu menu = new Menu("test");

            Day dayToAdd = new Day();

            Recipe recipeToAdd = new Recipe("roast potato", new string[] { "peel", "roast" }, new string[] { "dinner", "healthy" });

            recipeToAdd.Add(new Ingredient("potato", "apple of the earth", 0, 5.0f), 0.05f);
            recipeToAdd.Add(new Ingredient("water", "watery", 0, 0.0f), 1.0f);

            dayToAdd.Add(recipeToAdd, new string[] {"dinner", "healthy"});


            recipeToAdd = new Recipe("tomato soup", new string[] { "boil", "simmer" }, new string[] { "dinner", "healthy" });

            recipeToAdd.Add(new Ingredient("tomato", "red and squishy",0, 15.0f), 0.025f);
            recipeToAdd.Add(new Ingredient("water", "watery", 0, 0.0f), 1.0f);

            dayToAdd.Add(recipeToAdd, new string[] { "dinner", "healthy" });

            menu.AddDay(dayToAdd);


            ListIngredients list = menu.CompileShoppingList();

            Assert.AreEqual(3, list.NumberOfIngredients);


            Assert.AreEqual("potato", list.Ingredients[0].Name);

            Assert.AreEqual("water", list.Ingredients[1].Name);

            Assert.AreEqual("tomato", list.Ingredients[2].Name);


            Assert.AreEqual(0.05f, list.Ingredients[0].Mass);

            Assert.AreEqual(2.0f, list.Ingredients[1].Mass);

            Assert.AreEqual(0.25f, list.Ingredients[2].Mass);//failure here


        }
    }
}