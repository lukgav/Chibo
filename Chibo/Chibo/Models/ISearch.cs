using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chibo.Models
{
    public interface ISearch<T>
        where T : class
    {
        T Search(string name);

        T Search(string[] tags);

        T Search(int id);
    }
}