using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class LinkElem<T>
    {
        public LinkElem<T> next;
        public T elem;

        public LinkElem()
        {
            next = null;
        }

        public LinkElem(LinkElem<T> a)
        {
            next = a;
        }

        public LinkElem(LinkElem<T> nextelem, T elem)
        {
            this.elem = elem;
            next = nextelem;
        }

        public LinkElem(T elem)
        {
            this.elem = elem;
            next = null;
        }
    }
}
