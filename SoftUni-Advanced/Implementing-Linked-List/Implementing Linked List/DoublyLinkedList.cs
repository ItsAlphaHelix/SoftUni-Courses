using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementing_Linked_List
{
    public class DoublyLinkedList<T>
    {
        //fields
        private LinkedListItem<T> first = null;
        private LinkedListItem<T> last = null;

        public int Count
        {

            get
            {

                var count = 0;
                var current = first;

                while (current != null)
                {

                    count++;
                    current = current.Next;

                }

                return count;
            }

        }
        public void AddFirst(T element)
        {
            
            var newItem = new LinkedListItem<T>(element);

            if (first == null)
            {
                first = newItem;
                last = newItem;

            }
            else
            {
                
                newItem.Next = first;
                first.Previous = newItem;                
                first = newItem;

            }

        }
         
        public void AddLast(T element)
        {

            var newItem = new LinkedListItem<T>(element);

            if (last == null)
            {

                first = newItem;
                last = newItem;

            }
            else
            {

                last.Next = newItem;
                newItem.Previous = last;

                last = newItem;

            }
        }

        public T RemoveFirst()
        {
            try
            {
                if (first == null)
                {

                    throw new InvalidOperationException("The element cannot be null!");

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var currentFirstValue = first.Value;

            if (first == last)
            {

                first = null;
                last = null;

            }
            else
            {

                var newFirst = first.Next;
                newFirst.Previous = null;

                first = newFirst;

            }

            return currentFirstValue;
        }

        public T RemoveLast()
        {
            try
            {
                if (last == null)
                {

                    throw new InvalidOperationException("The element cannot be null!");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var currentLastValue = last.Value;

            if(first == last)
            {

                first = null;
                last = null;

            }
            else
            {

                var newLast = last.Previous;
                newLast.Next = null;
                last = newLast;
            }

            return currentLastValue;
        }

        public void DeleteByValue(T value)
        {

            var current = this.first;

            while (current != null)
            {

                //TODO: current == first;
                //TODO: current == last

                if(current.Value.Equals(value))
                {

                    current.Next.Previous = current.Previous;
                    current.Previous.Next = current.Next;
                    break;
                }
                
                current = current.Next;

            }

        }
        public void ForEach(Action<T> action)
        {
            var current = first;

            while (current != null)
            {
                action(current.Value);
                current = current.Next;

            }
        }

        public T[] ToArray()
        {

            var array = new T[Count];
            var index = 0;
            var current = first;

            while (current != null) 
            {

                array[index] = current.Value;
                index++;

                current = current.Next;
            }

            return array;
        }
    }
}