using Chibo.LiveDebuggers;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Chibo.Views
{
	public partial class DebugView : ContentPage
	{
		public List<LiveDebugger> DebugItems { get; set; }
		public DebugView()
		{
			InitializeComponent();

			DebugItems = LiveDebuggerRegister.GetDebuggers();
			DebugControlItems.ItemsSource = DebugItems;          
		}
	}
}
