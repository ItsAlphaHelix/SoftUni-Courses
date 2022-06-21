using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> box = new List<T>();

        public int Count
        {
            get => box.Count;
        }

        public void Add(T item)
        {
            box.Add(item);
        }

        public T Remove()
        {
            T item = box[box.Count - 1];
            box.RemoveAt(box.Count - 1);
            return item;
        }
    }
}
