using System;
using System.Collections.Generic;

namespace Chibo.Models
{
    public class Ingredient
    {
        private string _name;
        private string _descrip;
        private float _mass;
        private float _caloriesPerGram;
        private int _num;

        //public string ingName { get; }
        //public string ingDescrip { get; }

        //public float ingMass { get; }

        //public float IngCaloriesPerGram { get; }

        public Ingredient(string name, string descrip, float mass,float caloriesPerGram)
        {
            _name = name; //What is naming convention? e.g. Will it be Uppercase for foods or all lower case?
            _descrip = descrip;
            _mass = mass; // Is defult mass in micrograms, grams or kg?
            _caloriesPerGram = caloriesPerGram; //shot in the dark. Research can be done later on specific informaton.
        }

        public string Name
        {
            get
            {
                return _name;
            } 
        }

        public string Descrip
        {
            get
            {
                return _descrip;
            }
        }

        public float Mass
        {
            get
            {
                return _mass;
            }
        }

        public float CaloriesPerGram
        {
            get
            {
                return _caloriesPerGram;
            }
        }
    }
}