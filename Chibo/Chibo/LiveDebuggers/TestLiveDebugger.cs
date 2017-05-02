using System;
namespace Chibo.LiveDebuggers
{
	public class TestLiveDebugger : LiveDebugger
	{
		public TestLiveDebugger()
		{
			Name = "Test Debugger";
		}

		/// <summary>
		/// Called by the UI, prints the result onto the screen
		/// </summary>
		/// <returns>Test Output</returns>
		override public string Execute()
		{
			return "This is an example live debugger.\nUse it a basis for new ones.";
		}
	}
}
