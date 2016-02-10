using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal interface IMyQueue<T>
    {
        void Add(T elem);
        T Take();
    }
}
