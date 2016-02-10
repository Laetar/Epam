using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class ArrStack<T> : IMyStack<T>, ICloneable,IEnumerable
    {
        private T[] _arr;

        public ArrStack()
        {
            _arr = new T[] { };
        }

        public ArrStack(T elem)
        {
            _arr = new T[] { elem };
        }

        public object Clone()
        {
            T[] newArr = _arr;
            return newArr;
        }

        public IEnumerator GetEnumerator()
        {
            return _arr.GetEnumerator();
        }

        public T Pop()
        {
            T CamBack = _arr[_arr.Length - 1];
            T[] nowArr = new T[_arr.Length - 1];
            int i;
            for (i = 0; i < (_arr.Length - 1); i++)
            {
                nowArr[i] = _arr[i];
            }
            _arr = nowArr;
            return CamBack;
        }

        public void Push(T elem)
        {
            T[] nowArr = new T[_arr.Length + 1];
            int i;
            for (i = 0; i < _arr.Length; i++)
            {
                nowArr[i] = _arr[i];
            }
            nowArr[nowArr.Length - 1] = elem;
            _arr = nowArr;
        }
    }
}
