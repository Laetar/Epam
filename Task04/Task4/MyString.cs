using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class MyString
    {
        private char[] _arrChar;

        public int Length
        {
            private set { }
            get { return _arrChar.Length; }
        }

        public char this[int index]
        {
            get
            {
                return _arrChar[index];
            }

            private set
            {
                _arrChar[index] = value;
            }
        }

        public MyString(string a)
        {
            _arrChar = new char[a.Length];
            for (int i = 0; i< a.Length; i++)
            {
                _arrChar[i] = a[i];
            }
        }


        public override bool Equals(object obj)
        {
            return (obj.ToString() == ToString());
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (char i in _arrChar)
            {
                sb.Append(i);
            }

            return sb.ToString();
        }

        public static implicit operator MyString(string str)
        {
            return new MyString(str);
        }

        public static MyString operator +(MyString a, MyString b)
        {
            return new MyString(a.ToString() + b.ToString());
        }

        public static bool operator !=(MyString a, MyString b)
        {
            if (a.ToString() == b.ToString()) return false;
            else return true;
        }

        public static bool operator ==(MyString a, MyString b)
        {
            if (a.ToString() == b.ToString()) return true;
            else return false;
        }

    }
}
