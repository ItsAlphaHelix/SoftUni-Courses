using Implementing_Linked_List;
using System;

namespace ImplementingLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            var list = new DoublyLinkedList<int>();


            list.AddFirst(5);
            //5
            list.AddFirst(3);
            //3,5
            list.AddFirst(4);
            //4,3,5
            list.AddLast(1);
            //4,3,5,1
            list.AddFirst(2);
            //2,4,3,5,1
            list.AddLast(22);
            //2,4,3,5,1,22        
            list.RemoveFirst();
            //4,3,5,1,22
            list.RemoveLast();
            //4,3,5,1
            list.AddLast(10);
            //4,3,5,1,10

            Console.WriteLine(list.Count);
            Console.WriteLine(String.Join(", ", list.ToArray()));

            list.ForEach(x => Console.WriteLine(x));
        }
    }
}