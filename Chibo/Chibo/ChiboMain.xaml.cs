using Chibo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Chibo.Data;
using System.Diagnostics;

namespace Chibo
{
    public partial class App : Application
    {
        public static ChiboDatabase database;

        public App()
        {
            InitializeComponent();

            MainPage = new Chibo.Main();
			Menu = new Menu("Chibo");
        }

		public Menu Menu { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
            //new chibomain db:
            ChiboMain main = new ChiboMain();

            ChiboDatabase db = ChiboMain.Database;
            Debug.WriteLine("database is created.");
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
