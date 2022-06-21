using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementCustomStack
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int initialCapacity = 4;
        private T[] elements;

        public Stack()
        {
            elements = new T[initialCapacity];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {

            if(this.Count == elements.Length)
            {

                Resize();

            }

            elements[Count++] = element;

        }

        public T Pop()
        {

            try
            {
                if (this.Count == 0)
                {

                    throw new InvalidOperationException();

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            T element = elements[this.Count - 1];

            this.Count--;

            if (this.Count <= elements.Length / 4)
            {

                Shrink();

            }

            return element;
        }

        public T Peek()
        {

            try
            {
                throw new InvalidOperationException();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

            return elements[Count - 1];
        }

        public void ForEach(Action<T> action)
        {

            for (int i = 0; i < this.Count; i++)
            {

                action(elements[i]);

            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        private void Resize()
        {

            T[] coppyArray = new T[elements.Length * 2];

            for (int i = 0; i < elements.Length; i++)
            {

                coppyArray[i] = elements[i];

            }

            elements = coppyArray;
        }

        private void Shrink()
        {

            T[] coppyArray = new T[elements.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {

                coppyArray[i] = elements[i];

            }

            elements = coppyArray;
        }
    }
}
