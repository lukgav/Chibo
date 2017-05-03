using System;
using Xamarin.Forms;

namespace Chibo.Services
{
	public static class PageService
	{
		/// <summary>
		/// Changes the active detail view of the application
		/// </summary>
		/// <param name="page">The view to be displayed.</param>
		/// <param name="title">The title of the view.</param>
		public static void ChangeView(Page page, string title)
		{
			// get the application context
			var app = Application.Current as App;
			MasterDetailPage mainPage = (MasterDetailPage)app.MainPage;

			// set the page title
			page.Title = title;

			// create the page and make it look pretty
			mainPage.Detail = new NavigationPage(page)
			{
				BarBackgroundColor = Color.FromHex("#3F51B5"),
				BarTextColor = Color.FromHex("#FFF"),
			};
		}
	}
}
