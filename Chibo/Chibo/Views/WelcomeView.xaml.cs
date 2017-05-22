using Chibo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chibo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomeView : ContentPage
    {
        public WelcomeView()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            PageService.ChangeView(new DashboardView(), "Dashboard");
        }
    }
}
