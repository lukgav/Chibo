using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chibo.Models
{
    public interface ICanSaveLoad<T>
        where T : class
    {
        bool Save();

        bool Save(T saveElemet);

        T Load(int i);

        List<T> LoadAll();
    }
}
