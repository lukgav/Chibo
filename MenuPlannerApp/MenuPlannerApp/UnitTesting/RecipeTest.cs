using System;
using System.Collections.Generic;
using NUnit.Framework;
using Chibo.Models;

namespace Chibo.UnitTesting
{
    [TestFixture]
    public class RecipeTest
    {
        [Test]
        public void RecipeConstructorName()
        {
            Recipe recipe = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos" }, new string[] { "dinner", "lunch", "stew" });

            Assert.AreEqual(recipe.Name, "potato stew");

            Assert.AreNotEqual(recipe.Name, "not a potato stew");
        }

        [Test]
        public void RecipeconstructorInstruction()
        {
            Recipe recipe = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos" }, new string[] { "dinner", "lunch", "stew" });

            Assert.AreEqual(2, recipe.Instruction.Length);

            Assert.AreNotEqual(5, recipe.Instruction.Length);


            Assert.AreEqual("peel potatos", recipe.Instruction[0]);

            Assert.AreNotEqual("cut a carrot", recipe.Instruction[0]);


            Assert.AreEqual("stew potatos", recipe.Instruction[1]);

            Assert.AreNotEqual("boild celery", recipe.Instruction[1]);
        }

        [Test]
        public void RecipeInstructionSet()
        {
            Recipe recipe = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos" }, new string[] { "dinner", "lunch", "stew" });

            recipe.Instruction = new string[] { "wash potatos", "cut potatos", "light stove" };

            Assert.AreEqual(3, recipe.Instruction.Length);

            Assert.AreNotEqual(5, recipe.Instruction.Length);


            Assert.AreEqual("wash potatos", recipe.Instruction[0]);

            Assert.AreNotEqual("cut a carrot", recipe.Instruction[0]);


            Assert.AreEqual("cut potatos", recipe.Instruction[1]);

            Assert.AreNotEqual("burn potatos", recipe.Instruction[1]);


            Assert.AreEqual("light stove", recipe.Instruction[2]);

            Assert.AreNotEqual("nuke potatos", recipe.Instruction[2]);
        }

        [Test]
        public void RecipeconstructorTags()
        {
            Recipe recipe = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos" }, new string[] { "dinner", "lunch", "stew" });

            Assert.AreEqual(3, recipe.Tag.Length);

            Assert.AreNotEqual(5, recipe.Tag.Length);


            Assert.AreEqual("dinner", recipe.Tag[0]);

            Assert.AreNotEqual("cut a carrot", recipe.Tag[0]);


            Assert.AreEqual("lunch", recipe.Tag[1]);

            Assert.AreNotEqual("boild celery", recipe.Tag[1]);

            Assert.AreEqual("stew", recipe.Tag[2]);

            Assert.AreNotEqual("nuke celery", recipe.Tag[2]);
        }

        [Test]
        public void RecipeTagSet()
        {
            Recipe recipe = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos" }, new string[] { "dinner", "lunch", "stew" });

            recipe.Tag = new string[] { "breakfast", "midnight" };

            Assert.AreEqual(2, recipe.Tag.Length);

            Assert.AreNotEqual(5, recipe.Tag.Length);


            Assert.AreEqual("breakfast", recipe.Tag[0]);

            Assert.AreNotEqual("cut a carrot", recipe.Tag[0]);


            Assert.AreEqual("midnight", recipe.Tag[1]);

            Assert.AreNotEqual("burn potatos", recipe.Tag[1]);
        }

        [Test]
        public void RecipeConstructorIngredients()
        {
           Recipe recipe = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos" }, new string[] { "dinner", "lunch", "stew" });

           Assert.AreEqual(0, recipe.Ingredients.NumberOfIngredients);

           Assert.AreNotEqual(5, recipe.Ingredients.NumberOfIngredients);
        }

        [Test]
        public void RecipeMethodAdd()
        {
            Recipe recipe = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos" }, new string[] { "dinner", "lunch", "stew" });

            Assert.Fail();//not implemented
        }

        [Test]
        public void RecipeMethodRemove()
        {
            Recipe recipe = new Recipe("potato stew", new string[] { "peel potatos", "stew potatos" }, new string[] { "dinner", "lunch", "stew" });

            Assert.Fail();//not implemented
        }
    }
}