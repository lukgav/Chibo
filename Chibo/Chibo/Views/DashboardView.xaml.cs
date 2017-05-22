﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Chibo.Models;
using Chibo.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace Chibo.Views
{
    /// <summary>
    /// Dashboard view.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardView : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chibo.Views.DashboardView"/> class.
        /// </summary>
        public DashboardView()
        {
            InitializeComponent();
            BindingContext = new DashboardViewViewModel();
            RecipeList.SelectedItem = null;
        }

        /// <summary>
        /// Handles the viewing of recipes for today
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // get the list that sent the event
            ListView list = (ListView)sender;
            Recipe recipe = (Recipe)list.SelectedItem;
            await Navigation.PushAsync(new ViewRecipeView(recipe)); // todo: fix deselecting
        }
    }

    class DashboardViewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// If there is a day set for today, this contains it
        /// </summary>
        private Day today;

        /// <summary>
        /// The menu that contains all the days
        /// </summary>
        public Menu Menu { get; set; } = new Menu("");

        /// <summary>
        /// Today's recipes
        /// </summary>
        public Day Today {
            get { return today; }
            set
            {
                today = value;

                // mvvm property updating
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Today"));
                }
            }
        }

        /// <summary>
        /// Whether or not there is no days stored
        /// </summary>
        public bool IsNoDays { get => Menu.Days.Count() == 0; }

        /// <summary>
        /// Whether or not there is data for today
        /// </summary>
        public bool HasToday { get => Today != null; }

        /// <summary>
        /// Whether or not there are days stored
        /// </summary>
        public bool HasDays { get => Menu.Days.Count() != 0; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chibo.Views.DashboardViewViewModel"/> class.
        /// </summary>
        public DashboardViewViewModel()
        {
            // sometimes the view can be shown before the app initialises, 
            // this check makes sure that it doesn't try to access it
            if (Application.Current == null)
                return;

            // get the global menu
            Menu = (Application.Current as App).Menu;

            // find today (if it exists)
            foreach(Day day in Menu.Days)
            {
                if (day.Date.Day == DateTime.Now.Day && day.Date.Month == DateTime.Now.Month)
                {
                    Today = day;
                }
            }
        }

		/// <summary>
		/// Command used to change to the add day view
		/// </summary>
		/// <value>The get started command.</value>
		public ICommand GetStartedCommand
        {
            get
            {
                return new Command((object obj) =>
                {
                    PageService.ChangeView(new MenuView(), "Menu");
                });
            }
        }
    }
}
