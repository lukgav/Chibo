using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Chibo.Data;

namespace Chibo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Chibo.Main();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //new chibomain db:
            ChiboMain main = new ChiboMain();
            ChiboDatabase db = ChiboMain.Database;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
