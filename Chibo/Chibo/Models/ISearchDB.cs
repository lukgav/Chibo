using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chibo.Models
{
    public interface ISearchDB<T>
        where T : class
    {
        T SearchDB(string name);

        T SearchDB(string[] tags);

        T SearchDB(int id);
    }
}
