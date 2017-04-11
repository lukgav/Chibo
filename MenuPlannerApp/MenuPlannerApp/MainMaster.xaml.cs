using Chibo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chibo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMaster : ContentPage
    {
        public ListView ListView => ListViewMenuItems;

        public MainMaster()
        {
            InitializeComponent();
            BindingContext = new MainMasterViewModel();
        }



        class MainMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainMenuItem> MenuItems { get; }
            public MainMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainMenuItem>(new[]
                {
                    new MainMenuItem { Id = 0, Title = "Dashboard" },
                    new MainMenuItem { Id = 1, Title = "Menu", TargetType = typeof(MenuView) },
                    new MainMenuItem { Id = 2, Title = "Recipes" },
                    new MainMenuItem { Id = 3, Title = "Shopping List" }
                });
            }
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
