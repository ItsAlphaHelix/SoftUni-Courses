using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementCustomQueue
{
    public class Queue
    {

        private const int InitialCapacity = 2;
        private const int FirstElementIndex = 0;
        private int[] items;

        public Queue()
        {
            items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int i]
        {

            get
            {
                //IsInRange(i);

                return items[i];
            }
            set
            {

                //IsInRange(i);

                items[i] = value;

            }
        }
        public void Enqueue(int item)
        {

            if (this.Count == items.Length)
            {

                IncreaseSize();

            }

            items[this.Count++] = item;

        }

        public int Dequeue()
        {

            var firstElement = items[FirstElementIndex];

            IsEmpty();
            items[FirstElementIndex] = 0;
            SwitchElements();

            this.Count--;

            return firstElement;
        }

        public int Peek()
        {

            IsEmpty();

            return items[FirstElementIndex]; 

        }

        public int Clear()
        {

            IsEmpty();


            items = new int[1];
            this.Count = 0;

            return this.Count;
        }

        public void ForEach(Action<int> action)
        {

            for (int i = 0; i < items.Length; i++)
            {
                action(items[i]);
            }

        }
        private void SwitchElements()
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                items[i] = items[i + 1];
            }
        }

        private void IsEmpty()
        {
            try
            {
                if (this.Count == 0)
                {
                    throw new InvalidOperationException("The queue is empty!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void IncreaseSize()
        {

               int[] tempArray = new int[items.Length * 2];

                for (int i = 0; i < items.Length; i++)
                {

                    tempArray[i] = items[i];

                }

                items = tempArray;
        }

        public void Print()
        {

            Console.WriteLine(String.Join(", ", items));

        }
    }
}
