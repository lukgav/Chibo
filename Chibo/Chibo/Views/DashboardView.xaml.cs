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

        }
    }

    class DashboardViewViewModel : INotifyPropertyChanged
    {
        public Menu Menu { get; set; } = new Menu("");
        public Day Today { get; set; }
        public bool IsNoDays { get => Menu.Days().Count() == 0; }
        public bool HasToday { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chibo.Views.DashboardViewViewModel"/> class.
        /// </summary>
        public DashboardViewViewModel()
        {
            GetStartedCommand = new Command(GetStarted);

            if (Application.Current == null) return;

            Menu = (Application.Current as App).Menu;

            foreach(Day day in Menu.Days())
            {
                if(day.Date.Day == new DateTime().Day && day.Date.Month == new DateTime().Month)
                {
                    Today = day;
                    HasToday = true;
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


		public event PropertyChangedEventHandler PropertyChanged;
		void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
