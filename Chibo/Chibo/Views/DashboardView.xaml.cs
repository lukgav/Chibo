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
        public DashboardView()
        {
            InitializeComponent();
            BindingContext = new DashboardViewViewModel();
            RecipeList.SelectedItem = null;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView list = (ListView)sender;
            Recipe recipe = (Recipe)list.SelectedItem;
            await Navigation.PushAsync(new ViewRecipeView(recipe)); // todo: fix deselecting
        }
    }

    class DashboardViewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Day today;
        public Menu Menu { get; set; } = new Menu("");
        public Day Today {
            get { return today; }
            set
            {
                today = value;

                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Today"));
                }
            }
        }
        public bool IsNoDays { get => Menu.Days.Count() == 0; }
        public bool HasToday { get => Today != null; }


        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chibo.Views.DashboardViewViewModel"/> class.
        /// </summary>
        public DashboardViewViewModel()
        {
            GetStartedCommand = new Command(GetStarted);

            if (Application.Current == null) return;

            Menu = (Application.Current as App).Menu;

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
		Command GetStartedCommand { get; }

        /// <summary>
        /// Change the view to the add day view
        /// </summary>
		public void GetStarted()
        {
            PageService.ChangeView(new AddDayView(), "Add Day");
        }

		//void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
			//PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
