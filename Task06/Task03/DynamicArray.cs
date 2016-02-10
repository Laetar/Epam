using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public class DynamicArray<T>: IEnumerable
    {
        private int _realLength;
        private T[] _arr;

        public int Length
        {
            get { return _arr.Length; }
            private set { }
        }

        public int Capacity
        {
            get { return _realLength; }
            private set { }
        }

        public T this[int index]
        {
            get
            {
                if ((index < _realLength)&&(index >= 0))
                    return _arr[index];
                else throw new IndexOutOfRangeException();
            }
        }

        public DynamicArray()
        {
            _arr = new T[8];
            _realLength = 0;
        }

        public DynamicArray(int Length)
        {
            _arr = new T[Length];
            _realLength = 0;
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            _arr = collection.ToArray();
            _realLength = _arr.Length;
        }

        public void Add(T elem)
        {
            if (_realLength < _arr.Length)
            {
                _arr[_realLength] = elem;
                _realLength++;
            }
            else
            {
                T[] newArr = new T[_arr.Length * 2];
                Array.Copy(_arr, newArr, (_realLength));
                newArr[_realLength] = elem;
                _realLength++;
                _arr = newArr;
            }
        }

        public void AddRange(IEnumerable<T> collection)
        {
            int addCount = collection.Count();
            if (_realLength + addCount < _arr.Length)
            {
                foreach(T elem in collection)
                {
                    _arr[_realLength] = elem;
                    _realLength++;
                }
            }
            else
            {
                T[] newArr = new T[_realLength + addCount];
                Array.Copy(_arr, newArr, _realLength);
                foreach (T elem in collection)
                {
                    newArr[_realLength] = elem;
                    _realLength++;
                }
                _arr = newArr;
            }
        }

        public bool Remove(T elem)
        {
            if (_realLength> 0)
            {
                bool isFind = false;
                int i;
                int findIndex = 0;
                for (i = 0; i < _arr.Length; i++)
                {
                    if (_arr[i].Equals(elem))
                    {
                        findIndex = i;
                        isFind = true;
                    }
                }

                if (isFind)
                {
                    T[] newArr = new T[_realLength - 1];
                    i = 0;
                    while (i != findIndex)
                    {
                        newArr[i] = _arr[i];
                        i++;
                    }
                    for (i = 0; i < _arr.Length - 1; i++)
                    {
                        newArr[i] = _arr[i + 1];
                    }
                    _realLength--;
                    _arr = newArr;
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public bool Insert(T elem, int n)
        {
            int i = 0;

            if (n < _realLength)
            {
                T[] newArr = new T[_realLength + 1];
                while (i != n)
                {
                    newArr[i] = _arr[i];
                    i++;
                }
                newArr[i] = elem;
                for (i = 0; i < _arr.Length - 1; i++)
                {
                    newArr[i] = _arr[i + 1];
                }
                _realLength++;
                _arr = newArr;
                return true;
            }
            else if (n == _realLength)
            {
                Add(elem);
                return true;
            }
            else if (n < 0) throw new IndexOutOfRangeException();
            else return false;
        }

        public IEnumerator GetEnumerator()
        {
            return _arr.GetEnumerator();
        }
    }
}
