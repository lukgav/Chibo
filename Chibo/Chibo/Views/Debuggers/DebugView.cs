using Chibo.LiveDebuggers;
using System;

using Xamarin.Forms;

namespace Chibo.Views.Debug
{
	public class DebugView : ContentPage
	{
		public DebugView(LiveDebugger debug)
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = debug.Execute() }
				}
			};
		}
	}
}

