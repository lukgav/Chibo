using System;
using SQLite;
using System.Collections.Generic;

namespace Chibo.Models
{
    public class Ingredient
    {
        [PrimaryKey, AutoIncrement]
        private int id { get; set; }
        private string _name;
        private string _descrip;
        private float _mass;
        private float _quantity;
        private float _caloriesPerGram;
        private int _numberOfIngredients;
        private bool _isMassQuantityMeasured; //this boolean chooses whether the ingredient is measured in quantity or mass

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

            set
            {
                _mass = value;
            }
        }

        public float Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

        public float CaloriesPerGram
        {
            get
            {
                return _caloriesPerGram;
            }
        }

        [Obsolete]
        public int NumberOfIngredients
        {
            get
            {
                return _numberOfIngredients;
            }

            set
            {
                _numberOfIngredients = value;
            }
        }

        public bool IsMassQuantityMeasured
        {
            get
            {
                return _isMassQuantityMeasured;
            }
            set
            {
                _isMassQuantityMeasured = value;
            }
        }
        
        public string Label
        {
            get => String.Format("{0}x {1}", Quantity == 0 ? 1 : Quantity, Name);
        }

        public int ID
        {
            get;

            set;
        }

        public Ingredient(string name, string descrip, float mass, float caloriesPerGram)
        {
            _name = name; //What is naming convention? e.g. Will it be Uppercase for foods or all lower case?
            _descrip = descrip;
            _mass = mass; // Is defult mass in micrograms, grams or kg?
            _caloriesPerGram = caloriesPerGram; //shot in the dark. Research can be done later on specific informaton.
            _isMassQuantityMeasured = true;

            _numberOfIngredients = 0;//default sanity check
        }

        public Ingredient()
        {
            //empty constructor 
        }

        public bool SameID(IIdentifyable identified)
        {
            bool result = false;

            if (this.GetType() == identified.GetType())
            {
                if (this.ID == identified.ID)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}