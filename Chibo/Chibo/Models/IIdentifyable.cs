using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chibo.Models
{
    public interface IIdentifyable
    {
        int ID
        {
            get;

            set;
        }

        bool SameID(IIdentifyable identified);
    }
}
