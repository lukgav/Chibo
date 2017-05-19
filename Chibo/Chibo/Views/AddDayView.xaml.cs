﻿using Chibo.Models;

using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Chibo.Views
{
    /// <summary>
    /// The view for adding days
    /// </summary>
	public partial class AddDayView : ContentPage
	{
        /// <summary>
        /// The day.
        /// </summary>
        public Day Day = new Day();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chibo.Views.AddDayView"/> class.
        /// </summary>
		public AddDayView()
		{
			InitializeComponent();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chibo.Views.AddDayView"/> class.
        /// </summary>
        /// <param name="day">Day.</param>
        public AddDayView(Day day)
        {
            InitializeComponent();

            // if something went terribly wrong..
            if (day == null)
            {
                DisplayAlert("Error!", "Day is null", "Damn.");
                return;
            }
                    
            Day = day;
            MealItems.ItemsSource = day.Recipes;
        }

        /// <summary>
        /// Opens the add meal view
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void AddMeal_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddMealView(Day));
        }

        /// <summary>
        /// Adds the day to the global menu
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void AddDay_Clicked(object sender, System.EventArgs e)
        {
            Day.Date = DateInput.Date;
            (Application.Current as App).Menu.AddDay(Day);
            Navigation.PushAsync(new MenuView());
        }
    }
}
