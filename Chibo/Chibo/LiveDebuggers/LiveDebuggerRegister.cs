using System;
using System.Collections.Generic;
namespace Chibo.LiveDebuggers
{
	public static class LiveDebuggerRegister
	{
		public static List<LiveDebugger> GetDebuggers()
		{
			List<LiveDebugger> results = new List<LiveDebugger>();

			// if you add a LiveDebugger, register it below
			results.Add(new TestLiveDebugger());
            results.Add(new DBDebugger());

			return results;
		}
	}
}
