using System;
namespace Chibo.LiveDebuggers
{
	abstract public class LiveDebugger
	{
		public string Name { get; set; } = "A Debugger";
		abstract public string Execute();
	}
}
