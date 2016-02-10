using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class ArrQueue<T> : IMyQueue<T>,ICloneable,IEnumerable
    {
        private T[] _arr = { };
        private bool _isEmpty = true;

        public int CollElem
        {
            private set { }
            get { return _arr.Length; }
        }

        public ArrQueue()
        {

        }

        public ArrQueue(T elem)
        {
            _arr = new T[] { elem };
            _isEmpty = false;
        }

        public void Add(T elem)
        {
            T[] nowArr = new T[_arr.Length + 1];
            int i;
            for (i = 0; i < _arr.Length; i++)
            {
                nowArr[i] = _arr[i];
            }
            nowArr[nowArr.Length-1] = elem;
            _arr = nowArr;
            if (_isEmpty) _isEmpty = false;
        }

        public IEnumerator GetEnumerator()
        {
            return _arr.GetEnumerator();
        }

        public T Take()
        {
            if (!_isEmpty)
            {
                T CamBack = _arr[0];
                T[] nowArr = new T[_arr.Length - 1];
                int i;
                for (i = 0; i < (_arr.Length - 1); i++)
                {
                    nowArr[i] = _arr[i + 1];
                }
                _arr = nowArr;
                if (_arr.Length == 0) _isEmpty = true;
                return CamBack;
            }
            else throw new IndexOutOfRangeException();
        }

        public object Clone()
        {
            T[] newArr = _arr;
            return newArr;
        }
    }
}
