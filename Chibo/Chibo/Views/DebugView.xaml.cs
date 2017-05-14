using Chibo.LiveDebuggers;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Chibo.Services;
using Chibo.Views.Debuggers;

namespace Chibo.Views
{
    /// <summary>
    /// The view that lists live debuggers
    /// </summary>
	public partial class DebugView : ContentPage
	{
        /// <summary>
        /// Gets or sets the debug items.
        /// </summary>
        /// <value>The debug items.</value>
		public List<LiveDebugger> DebugItems { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chibo.Views.DebugView"/> class.
        /// </summary>
		public DebugView()
		{
			InitializeComponent();

            // get all the live debuggers
            DebugItems = LiveDebuggerRegister.GetDebuggers();
			DebugControlItems.ItemsSource = DebugItems;

			DebugControlItems.ItemSelected += async (sender, e) =>
			{
                // quirk of xamarin forms, this fixes some errors
                if (e.SelectedItem == null)
                    return;

                // navigation to the debuggerview
                await Navigation.PushAsync(new DebuggerView() { Debugger = (LiveDebugger)e.SelectedItem });

                // deselect it to unlock the view
                ((ListView)sender).SelectedItem = null;
			};
		}

    }
}
