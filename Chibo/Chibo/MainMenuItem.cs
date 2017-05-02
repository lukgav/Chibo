using Chibo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chibo
{

    public class MainMenuItem
    {
        public MainMenuItem()
        {
            TargetType = typeof(DashboardView);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
