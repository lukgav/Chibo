using Chibo.Models;
using Chibo.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chibo.Views
{
	/// <summary>
	/// Menu view.
	/// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : ContentPage
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Chibo.Views.MenuView"/> class.
		/// </summary>
        public MenuView()
        {
            InitializeComponent();
            BindingContext = new MenuViewViewModel();

			// get the menu and assign to list
			Menu menu = PageService.GetMenu();
			MenuItems.ItemsSource = menu.Days;
            NoDaysLabel.IsVisible = menu.Days.Count() == 0;
		}

        private void MenuItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            PageService.ChangeView(
                new AddDayView((Day)MenuItems.SelectedItem, true), "Edit Day"
            );
        }
    }

    /// <summary>
    /// Menu view view model.
    /// </summary>
    class MenuViewViewModel : INotifyPropertyChanged
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Chibo.Views.MenuViewViewModel"/> class.
		/// </summary>
        public MenuViewViewModel()
        {
            AddDayCommand = new Command(AddDay);
        }

		/// <summary>
		/// Command used to change to the Add Day view
		/// </summary>
		/// <value>The add day command.</value>
        public ICommand AddDayCommand { get; }

        /// <summary>
        /// Changes to the Add Day view
        /// </summary>
        public void AddDay()
		{
			PageService.ChangeView(new AddDayView(), "Add Day");
		}

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
