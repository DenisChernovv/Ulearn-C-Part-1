using System;
using System.Collections.Generic;

namespace TodoApplication
{
    public class ListModel<TItem>
    {
        public List<TItem> Items { get; }
        LimitedSizeStack<Tuple<Operations, TItem, int>> LimidetStack;
        enum Operations { Add, Remove };

        public ListModel(int limit)
        {
            Items = new List<TItem>();
            LimidetStack = new LimitedSizeStack<Tuple<Operations, TItem, int>>(limit);
        }

        public void AddItem(TItem item)
        {
            Items.Add(item);
            var tuple = new Tuple<Operations, TItem, int>(Operations.Add,
                item, Items.Count - 1);
            LimidetStack.Push(tuple);
        }

        public void RemoveItem(int index)
        {
            var item = Items[index];
            Items.RemoveAt(index);
            var tuple = new Tuple<Operations, TItem, int>(Operations.Remove,
                item, index);
            LimidetStack.Push(tuple);

        }

        public bool CanUndo()
        {
            return LimidetStack.Count != 0;
        }

        public void Undo()
        {
            var tuple = LimidetStack.Pop();
            switch (tuple.Item1)
            {
                case Operations.Add:
                    Items.RemoveAt(tuple.Item3);
                    return;
                case Operations.Remove:
                    Items.Insert(tuple.Item3, tuple.Item2);
                    return;
            }

            throw new NotImplementedException();
        }
    }
}
