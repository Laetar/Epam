using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal interface IMyList<T>
    {
        void Append(T elem); //добавить элемент в список
        void Delete(int index); //удалить элемент из списка
        T Get(int index); //взять элемент по индексу 
        void Insert(T elem, int index); //вставить элемент в список
        int FindElem(T elem); //найти индекс элемента
    }
}
