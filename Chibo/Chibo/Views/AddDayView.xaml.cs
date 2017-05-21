using Chibo.Models;
using Chibo.Services;
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
        /// Whether or not this is editing or adding
        /// </summary>
        public bool IsEditing = false;

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
                DisplayAlert("Error!", "Day is null!", "Ok");
                return;
            }
                    
            Day = day;
            MealItems.ItemsSource = day.Recipes;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chibo.Views.AddDayView"/> class.
        /// </summary>
        /// <param name="day"></param>
        /// <param name="edit"></param>
        public AddDayView(Day day, bool edit)
        {
            InitializeComponent();

            // if something went terribly wrong..
            if (day == null)
            {
                DisplayAlert("Error!", "Day is null!", "Ok");
                return;
            }

            Day = day;
            MealItems.ItemsSource = day.Recipes;
            IsEditing = edit;
        }

        /// <summary>
        /// Opens the add meal view
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void AddMeal_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddMealView(Day, IsEditing));
        }

        /// <summary>
        /// Adds the day to the global menu
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void AddDay_Clicked(object sender, System.EventArgs e)
        {
            Day.Date = DateInput.Date;

            int index = 0;
            int indexToEdit = 0;
            // prevent adding two menus for one day
            foreach(Day day in (Application.Current as App).Menu.Days)
            {
                if(day.Date == Day.Date)
                {
                    if(IsEditing)
                    {
                        indexToEdit = index;
                    }
                    else
                    {
                        DisplayAlert("Oops!", "You already have a menu for this day planned!", "Okay");
                        return;
                    }
                }
                index++;
            }

            // add the day to the global menu
            if (!IsEditing)
                (Application.Current as App).Menu.AddDay(Day);
            else
                (Application.Current as App).Menu.Days[indexToEdit] = Day;

            // change the view
            PageService.ChangeView(new MenuView(), "Menu");
            Navigation.PopToRootAsync();
        }
    }
}
