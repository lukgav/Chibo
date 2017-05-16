using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chibo.LiveDebuggers
{
    public class DBDebugger : LiveDebugger
    {
        public DBDebugger()
        {
            Name = "the database debugger object.";
        }

        /// <summary>
        /// Called by the UI, prints the result onto the screen
        /// </summary>
        /// <returns>Test Output</returns>
        override public string Execute()
        {
            return "This is fudge's database debugger object.";
        }
    }
}
