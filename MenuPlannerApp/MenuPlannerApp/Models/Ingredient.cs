using System;
using System.Collections.Generic;

namespace Chibo.Models
{
    public class Ingredient
    {
        private string ingName;
        private string ingDescrip;
        private float ingMass;
        private float ingCaloriesPerGram;
        private int num;

        //public string ingName { get; }
        //public string ingDescrip { get; }

        //public float ingMass { get; }

        //public float IngCaloriesPerGram { get; }

        public Ingredient()
        {
            ingName = "potatoe"; //What is naming convention? e.g. Will it be Uppercase for foods or all lower case?
            ingDescrip = "Known as 'apple of the earth' in French it is an earthy vegetable found in the ground. Considered healthy although its calorie content is rather high for ever gram.";
            ingMass = 300.3F; // Is defult mass in micrograms, grams or kg?
            ingCaloriesPerGram = 20; //shot in the dark. Research can be done later on specific informaton.
        }

        public Ingredient(string _ingName, string _ingDescrip, float ingMass,float _ingCaloriesPerGram)
        {
            ingName = _ingName; //What is naming convention? e.g. Will it be Uppercase for foods or all lower case?
            ingDescrip = _ingDescrip;
            ingMass = ingMass; // Is defult mass in micrograms, grams or kg?
            ingCaloriesPerGram = _ingCaloriesPerGram; //shot in the dark. Research can be done later on specific informaton.
        }

        public string IngName
        {
            get
            {
                return ingName;
            } 
        }

        public string IngDescrip
        {
            get
            {
                return ingDescrip;
            }
        }

        public float IngMass
        {
            get
            {
                return ingMass;
            }
        }

        public float IngCaloriesPerGram
        {
            get
            {
                return IngCaloriesPerGram;
            }
        }
    }
}