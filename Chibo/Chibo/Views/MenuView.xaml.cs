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

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : ContentPage
    {
        public MenuView()
        {
            InitializeComponent();
            BindingContext = new MenuViewViewModel();
        }
    }

    class MenuViewViewModel : INotifyPropertyChanged
    {

        public MenuViewViewModel()
        {
            AddDayCommand = new Command(AddDay);
        }

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
