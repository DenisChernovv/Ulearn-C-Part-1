using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication
{
    public class LimitedSizeStack<T>
    {
        LinkedList<T> List = new LinkedList <T>();
        private int lim;

        public LimitedSizeStack(int limit)
        {
            lim = limit;
        }

        public void Push(T item)
        {
            List.AddLast(item);
            if (List.Count > lim)
                List.RemoveFirst();
        }

        public T Pop()
        {
            if (List.Count == 0) throw new NotImplementedException();
            var item = List.Last.Value;
            List.RemoveLast();
            return item;
        }

        public int Count
        {
            get
            {
                return List.Count;
            }
        }
    }
}
