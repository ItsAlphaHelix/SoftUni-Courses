using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
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

        public void Add(int element)
        {

            if (this.Count == items.Length)
            {
                Resize();

            }

            items[this.Count++] = element;

        }

        public void RemoveAll()
        {

            for (int i = 0; i < items.Length; i++)
            {
                items[i] = 0;
                
                this.Count--;
            }

            ShrinkAll();
        }

        public void RemoveByValue(int value)
        {

            try
            {

                if (value < 0 && value >= this.Count)
                {
                   throw new IndexOutOfRangeException();
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

            for (int i = 0; i < items.Length; i++)
            {

                if (items[i] == value)
                {
                    items[i] = 0;
                    Shift(value);
                    this.Count--;
                }


                if (this.Count < items.Length)
                {
                    Shrink();

                }
            }
        }

        public int RemoveByIndex(int index)
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

            for (int i = 0; i < items.Length; i++)
            {
                if(i == index)
                {
                    items[i] = 0;
                    Shift(index);
                    this.Count--;

                }

                if (this.Count < items.Length)
                {

                    Shrink();

                }
            }

            return index;
        }

        public void Insert(int index, int element)
        {

            try
            {

                if (index > this.Count)
                {

                    throw new IndexOutOfRangeException();

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

            if (this.Count == items.Length)
            {

                Resize();

            }

            Shift(index);

            items[index] = element;
            this.Count++;
        }
        private void Resize()
        {
            if(this.Count == 0)
            {

                int[] tempArray = new int[items.Length + 2];

                ResizeLoop(tempArray);

            }
            else
            {

                int[] tempArray = new int[items.Length + 1];
                ResizeLoop(tempArray);
            }

        }

        private void ResizeLoop(int[] tempArray)
        {
            for (int i = 0; i < items.Length; i++)
            {

                tempArray[i] = items[i];

            }

            items = tempArray;
        }

        private void ShrinkAll()
        {

            int[] tempArray = new int[items.Length - items.Length];

            for (int i = 0; i < this.Count; i++)
            {

                tempArray[i] = items[i];

            }

            items = tempArray;

        }

        private void Shrink()
        {

            int[] tempArray = new int[items.Length - 1];

            for (int i = 0; i < items.Length - 1; i++)
            {

                tempArray[i] = items[i + 1];

            }

            items = tempArray;

        }
        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {

                items[i] = items[i + 1];

            }
        }


        public void Print()
        {
            Console.WriteLine(items.Length == 0 ? "Items -> " + "0" : "Items -> " + $"{string.Join(", ", items)}");
        }
    }
}
