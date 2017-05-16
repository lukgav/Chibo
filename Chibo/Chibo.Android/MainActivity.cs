using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Xamarin.Forms;
using Chibo.Droid;

namespace Chibo.Droid
{
    [Activity(Label = "Chibo", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ChiboSQLite.db3");
            try
            {
                //try this
                if (!File.Exists(dbPath))
                {
                    //database doesn't already exist - lets copy it over.
                    using (var br = new BinaryReader(Android.App.Application.Context.Assets.Open("data.db3")))
                    {
                        // opened binary reader. now open writer:
                        using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                        {
                            byte[] buffer = new byte[2048];
                            int length = 0;
                            while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                //file not copied.
                                bw.Write(buffer, 0, length);
                            }
                        }
                    }
                }
            }
            catch
            {
                //????
            }
            
        }

    }


}

