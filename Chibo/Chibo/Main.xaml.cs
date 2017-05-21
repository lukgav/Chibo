using Chibo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chibo
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : MasterDetailPage
    {
        public Main()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainMenuItem;
			if (item == null)
				return;

			// create a page for the corresponding menu item
            var page = (Page)Activator.CreateInstance(item.TargetType);

			// use the page service to change views
			PageService.ChangeView(page, item.Title);

            MasterPage.ListView.SelectedItem = null;
            IsPresented = false;

        }
    }

}
