using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class LinkList<T> : LinkElem<T>, IMyList<T>,ICloneable
    {
        private LinkElem<T> _last = null;
        private LinkElem<T> _head = null;
        private int _collElem = 0;
        private bool _isEmpty = true;

        public int collElem
        {
            get { return _collElem; }
            private set { }
        }

        public LinkList()
        {

        }

        public LinkList(T elem)
        {
            _head = new LinkElem<T>(elem);
            _last = _head;
            _collElem = 1;
            _isEmpty = false;
        }

        public void Append(T elem)
        {
            if (!_isEmpty)
            {
                _last.next = new LinkElem<T>(elem);
                _last = _last.next;
            }
            else
            {
                _head = new LinkElem<T>(elem);
                _last = _head;
                _isEmpty = false;
            }
            _collElem++;
        }

        public void Delete(int index)
        {
            LinkElem<T> now = _head;
            if (_head != null)
            {
                if (index == 0) _head = _head.next;
                else
                {
                    int i = 1;
                    while (now.next != null)
                    {
                        if (index == i)
                        {
                            now.next = now.next.next;
                            _collElem--;
                            break;
                        }
                        else
                        {
                            now = now.next;
                            i++;
                        }
                    }
                }
            }
            else throw new IndexOutOfRangeException();
        }

        public T Get(int index)
        {
            if ((index < _collElem) && (index > 0))
            {
                LinkElem<T> now = _head;
                int i;
                for (i = 0; i < index; i++)
                {
                    now = now.next;
                }
                return now.elem;
            }
            else throw new IndexOutOfRangeException();
        }

        public void Insert(T elem, int index)
        {
            if ((index < _collElem) && (index > 0))
            {
                int i;
                LinkElem<T> now = _head;
                LinkElem<T> nextElem;
                for (i = 1; i < index; i++)
                {
                    now = now.next;
                }
                nextElem = now.next;
                now.next = new LinkElem<T>(nextElem, elem);
                _collElem++;
            }
            else if ((index == _collElem) && (index > 0))
            {
                Append(elem);
                _collElem++;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int FindElem(T elem)
        {
            LinkElem<T> now = _head;
            int i;
            for (i=0;i < _collElem;i++)
            {
                if (now.elem.Equals(elem)) { return i; }
                else now = now.next;
            }
            return -1;
        }

        object ICloneable.Clone()
        {
            LinkElem<T> now = _head;
            int i;
            LinkList<T> CloneList = new LinkList<T>();
            for (i=0;i<_collElem;i++)
            {
                CloneList.Append(now.elem);
                now = now.next;
            }
            return CloneList;
        }
    }
}
