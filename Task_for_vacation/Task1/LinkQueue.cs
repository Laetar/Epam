using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class LinkQueue<T> : LinkElem<T>, IMyQueue<T>,ICloneable
    {
        private bool _isEmpty = true;
        private int _collElem;
        private LinkElem<T> _head;
        private LinkElem<T> _tail;

        public int CollElem
        {
            private set { }
            get { return _collElem; }
        }

        public bool IsEmpty
        {
            get { return _isEmpty; }
            private set { }
        }

        public LinkQueue()
        {
            _collElem = 0;
        }

        public LinkQueue(T elem)
        {
            _head = new LinkElem<T>(elem);
            _tail = _head;
            _isEmpty = false;
            _collElem = 1;
        }

        public void Add(T elem)
        {
            if (!_isEmpty)
            {
                _tail.next = new LinkElem<T>(elem);
                _tail = _tail.next;
                _collElem++;
            }
            else
            {
                _head = new LinkElem<T>(elem);
                _tail = _head;
                _isEmpty = false;
                _collElem = 1;
            }
        }

        public T Take()
        {
            if (!_isEmpty)
            {
                T nowElem = _head.elem;
                _collElem--;
                if (_collElem == 0)
                {
                    _isEmpty = true;
                }
                else
                {
                    _head = _head.next;
                }
                return nowElem;
            }
            else throw new IndexOutOfRangeException();
        }

        public object Clone()
        {
            LinkElem<T> now = _head;
            int i;
            LinkQueue<T> CloneQueue = new LinkQueue<T>();
            for (i = 0; i < _collElem; i++)
            {
                CloneQueue.Add(now.elem);
                now = now.next;
            }
            return CloneQueue;
        }
    }
}
