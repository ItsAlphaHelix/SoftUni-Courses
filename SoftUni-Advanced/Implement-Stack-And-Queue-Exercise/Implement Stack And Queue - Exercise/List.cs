using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementCustomList
{
    public class List
    {
        private const int DefaultCapacity = 2;
        private int[] items;

        public List()
        {

            items = new int[DefaultCapacity];

        }

        public int Count { get; private set; }

        public int this[int i]
        {

            get
            {
                IsInRange(i);

                return items[i];
            }
            set
            {

                IsInRange(i);

                items[i] = value;

            }
        }

        private void IsInRange(int i)
        {
            try
            {
                if (i < 0 || i >= this.Count)
                {

                    throw new IndexOutOfRangeException();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Add(int element)
        {

            if(this.Count == items.Length)
            {
                Resize();
            }

            items[Count++] = element;

        }

        private void Resize()
        {
            int[] tempArray = new int[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {

                tempArray[i] = items[i];

            }

            items = tempArray;
        }

        public int RemoveAt(int index)
        {

            try
            {

                if (index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

            int element = items[index];
            items[index] = 0;

            Shift(index);

            this.Count--;

            if (this.Count <= items.Length / 4)
            {
                Shrink();

            }

            return element;

        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count; i++)
            {

                items[i] = items[i + 1];

            }
        }

        private void Shrink()
        {
            int[] tempArray = new int[items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {

                tempArray[i] = items[i];

            }

            items = tempArray;
        }

        public bool Contains(int element)
        {

            for (int i = 0; i < items.Length; i++)
            {

                if(items[i] == element)
                {

                    return true;

                }

            }

                return false;

        } 

        public void Swap(int firstIndex, int secondIndex)
        {

            try
            {

                if (firstIndex < 0 || firstIndex >= this.Count
                || secondIndex < 0 || secondIndex >= this.Count)
                {

                    throw new ArgumentOutOfRangeException();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            int tempElement = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = tempElement;
        }

        public void Insert(int index, int element)
        {

            try
            {

                if(index > this.Count)
                {

                    throw new IndexOutOfRangeException();

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                
            }

            if(this.Count == items.Length)
            {

                Resize();

            }

            Shift(index);

            items[index] = element;
            this.Count++;
        }
        public void Print()
        {

            Console.WriteLine(String.Join(" ", items));

        }
    }
}
