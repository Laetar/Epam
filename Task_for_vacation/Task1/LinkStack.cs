using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class LinkStack<T> : LinkElem<T>, IMyStack<T>, ICloneable
    {
        private bool _isEmpty = true;
        private int _collElem;
        private LinkElem<T> _head;

        public bool IsEmpty
        {
            get { return _isEmpty; }
            private set { }
        }

        public int CollElem
        {
            get { return _collElem; }
            private set { }
        }

        public LinkStack()
        {

        }

        public LinkStack(T elem)
        {
            _isEmpty = false;
            _head = new LinkElem<T>(elem);
        }

        public T Pop()
        {
            if (!_isEmpty)
            {
                T ReturnElem = _head.elem;
                _collElem--;
                if (_collElem != 0)
                {
                    _head = _head.next;
                }
                else
                {
                    _isEmpty = true;
                }
                return ReturnElem;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Push(T elem)
        {
            if (!_isEmpty)
            {
                LinkElem<T> OldHead = _head;
                _head = new LinkElem<T>(elem);
                _head.next = OldHead;
                _collElem++;
            }
            else
            {
                _isEmpty = false;
                _head = new LinkElem<T>(elem);
                _collElem = 1;
            }
        }

        public object Clone()
        {
            LinkElem<T> now = _head;
            int i;
            LinkStack<T> CloneStack = new LinkStack<T>();
            for (i = 0; i < _collElem; i++)
            {
                CloneStack.Push(now.elem);
                now = now.next;
            }
            return CloneStack;
        }
    }
}
