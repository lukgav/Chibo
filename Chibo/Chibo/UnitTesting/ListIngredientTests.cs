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
//    public class ListIngredientTests
//    {
//        public ListIngredientTests()
//        {
//            Day day = new Day();

//            //
//            // TODO: Add constructor logic here
//            //
//        }
//        [TestMethod]
//        public void ListIngredientConstructorNumberOfIngredients()
//        {
//            ListIngredients lsIng = new ListIngredients();

//            Assert.AreEqual(0, lsIng.NumberOfIngredients);

//            lsIng = new ListIngredients(new List<Ingredient>());

//            Assert.AreEqual(0, lsIng.NumberOfIngredients);

//            lsIng = new ListIngredients(new List<Ingredient>() { new Ingredient("spinach", "yuck", 0.04f, 0.01f), new Ingredient("tomato", "yum", 0.64f, 0.51f), new Ingredient("cauliflower", "ehh", 0.00f, 0.12f) });

//            Assert.AreEqual(3, lsIng.NumberOfIngredients);
//        }

//        [TestMethod]
//        public void ListIngredientMethodAdd()
//        {
//            ListIngredients lsIng = new ListIngredients();

//            float a1 = 0.04f, a2 = 0.06f;

//            Assert.AreEqual(0, lsIng.NumberOfIngredients);


//            lsIng.Add(new Ingredient("spinach", "yuck", 0.04f, 0.01f));

//            Assert.AreEqual(1, lsIng.NumberOfIngredients);

//            Assert.AreEqual(a1, lsIng.Ingredients[0].Mass);


//            //test that it combines the two similar ingredients
//            lsIng.Add(new Ingredient("spinach", "yuck", 0.04f, 0.01f));

//            Assert.AreEqual(1, lsIng.NumberOfIngredients);

//            Assert.AreEqual(2*a1, lsIng.Ingredients[0].Mass);


//            lsIng.Add(new Ingredient("brocolli", "yuck", a2, 0.01f));

//            Assert.AreEqual(2, lsIng.NumberOfIngredients);

//            Assert.AreEqual(a2, lsIng.Ingredients[1].Mass);
//        }

//        [TestMethod]
//        public void ListIngredientMethodRemove()
//        {
//            ListIngredients lsIng = new ListIngredients();

//            float a1 = 0.04f, a2 = 0.06f;

//            Assert.AreEqual(0, lsIng.NumberOfIngredients);

//            lsIng.Add(new Ingredient("spinach", "yuck", 2*a1, 0.01f));

//            lsIng.Add(new Ingredient("brocolli", "yuck", a2, 0.01f));


//            Assert.AreEqual(2, lsIng.NumberOfIngredients);

//            lsIng.Remove(new Ingredient("brocolli", "yuck", a2, 0.01f));

//            Assert.AreEqual(1, lsIng.NumberOfIngredients);
            

//            lsIng.Remove(new Ingredient("spinach", "yuck", a1, 0.01f));

//            //should be two spinachs worth of mass to remove
//            Assert.AreEqual(1, lsIng.NumberOfIngredients);

//            lsIng.Remove(new Ingredient("spinach", "yuck", a1, 0.01f));

//            Assert.AreEqual(0, lsIng.NumberOfIngredients);
//        }

//        [TestMethod]
//        public void ListIngredientMethodPurge()
//        {
//            ListIngredients lsIng = new ListIngredients();
//            Ingredient toAdd1 = new Ingredient("spinach", "yuck", 0.00f, 0.01f);
//            Ingredient toAdd2 = new Ingredient("brocolli", "yuck", 0.06f, 0.01f);
//            Ingredient toAdd3 = new Ingredient("cheese", "yum", -0.12f, 0.01f);

//            lsIng.Add(toAdd1);
//            lsIng.Add(toAdd2);
//            lsIng.Add(toAdd3);

//            Assert.AreEqual(3, lsIng.NumberOfIngredients);

//            lsIng.Purge();

//            Assert.AreEqual(1, lsIng.NumberOfIngredients);
//        }

//        [TestMethod]
//        public void ListIngredientMergeListIngredient()
//        {
//            ListIngredients lsIng = new ListIngredients();
//            ListIngredients lsToMerge1 = new ListIngredients(new List<Ingredient>() { new Ingredient("spinach", "yuck", 0.04f, 0.01f), new Ingredient("tomato", "yum", 0.64f, 0.51f), new Ingredient("cauliflower", "ehh", 0.00f, 0.12f) });
//            ListIngredients lsToMerge2 = new ListIngredients(new List<Ingredient>() { new Ingredient("brocolli", "yuck", 0.04f, 0.01f) });

//            Assert.AreEqual(0, lsIng.NumberOfIngredients);

//            lsIng.Merge(lsToMerge1);

//            Assert.AreEqual(3, lsIng.NumberOfIngredients);

//            lsIng.Merge(lsToMerge1);

//            Assert.AreEqual(3, lsIng.NumberOfIngredients);

//            lsIng.Merge(lsToMerge2);

//            Assert.AreEqual(4, lsIng.NumberOfIngredients);
//        }

//        [TestMethod]
//        public void ListIngredientMergeList()
//        {
//            ListIngredients lsIng = new ListIngredients();
//            List<Ingredient> lsToMerge1 = new List<Ingredient>() { new Ingredient("spinach", "yuck", 0.04f, 0.01f), new Ingredient("tomato", "yum", 0.64f, 0.51f), new Ingredient("cauliflower", "ehh", 0.00f, 0.12f) };
//            List<Ingredient> lsToMerge2 = new List<Ingredient>() { new Ingredient("brocolli", "yuck", 0.04f, 0.01f)};

//            Assert.AreEqual(0, lsIng.NumberOfIngredients);

//            lsIng.Merge(lsToMerge1);

//            Assert.AreEqual(3, lsIng.NumberOfIngredients);

//            lsIng.Merge(lsToMerge1);

//            Assert.AreEqual(3, lsIng.NumberOfIngredients);

//            lsIng.Merge(lsToMerge2);

//            Assert.AreEqual(4, lsIng.NumberOfIngredients);
//        }
//    }
//}