using System;
using System.Collections.Generic;
using Chibo.LiveDebuggers;
using Xamarin.Forms;

namespace Chibo.Views.Debuggers
{
    /// <summary>
    /// The view containing the live debugger
    /// </summary>
    public partial class DebuggerView : ContentPage
    {
        /// <summary>
        /// Gets or sets the live debugger.
        /// </summary>
        /// <value>The debugger.</value>
		public LiveDebugger Debugger { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chibo.Views.Debug.DebuggerView"/> class.
        /// </summary>
        public DebuggerView()
        {
            InitializeComponent();

            // when button is clicked, run the debugger and output into label
            RunDebuggerButton.Clicked += (sender, ea) => {
                DebugOutput.Text = Debugger.Execute();
            };

        }

    }
}
