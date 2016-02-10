using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class ArrList<T> : IMyList<T>,ICloneable ,IEnumerable
    {
        private T[] _arr = new T[0];

        public int collElem
        {
            get { return _arr.Length; }
            private set { }
        }

        public void Append(T elem)
        {
            int i;
            T[] NewArr = new T[_arr.Length + 1];
            for (i = 0; i < _arr.Length; i++)
            {
                NewArr[i] = _arr[i];
            }
            NewArr[NewArr.Length - 1] = elem;
            _arr = NewArr;
        }

        public object Clone()
        {
            T[] newArr = _arr;
            return newArr;
        }

        public void Delete(int index)
        {
            if ((index < _arr.Length) && (index > 0))
            {
                int i;
                int j = 0;
                T[] newArr = new T[_arr.Length - 1];
                for (i = 0; i < _arr.Length; i++)
                {
                    if (i != index)
                    {
                        newArr[j] = _arr[i];
                        j++;
                    }
                }
                _arr = newArr;
            }
        }


        public int FindElem(T elem)
        {
            int i;
            for (i = 0; i < _arr.Length; i++)
            {
                if (_arr[i].Equals(elem)) return i;
            }
            return -1;
        }

        public T Get(int index)
        {
            if ((index < _arr.Length) && (index > 0))
            {
                return _arr[index];
            }
            else throw new IndexOutOfRangeException();
        }

        public IEnumerator GetEnumerator()
        {
            return _arr.GetEnumerator();
        }

        public void Insert(T elem, int index)
        {
            if ((index < _arr.Length) && (index > 0))
            {
                int i = 0;
                int j = 0;
                T[] newArr = new T[_arr.Length + 1];
                while (i != index)
                {
                    newArr[j] = _arr[i];
                    j++;
                    i++;
                }
                newArr[j] = elem;
                for (; i < _arr.Length; i++)
                {
                    newArr[j + 1] = _arr[i];
                }
                _arr = newArr;
            }
            else if ((index == _arr.Length) && (index > 0))
            {
                Append(elem);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

    }
}
