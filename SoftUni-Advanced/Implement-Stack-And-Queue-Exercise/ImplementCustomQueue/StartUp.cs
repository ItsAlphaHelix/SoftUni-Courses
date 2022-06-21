using ImplementCustomQueue;
using System;

namespace ImplementCustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Queue queue = new Queue();

            queue.Enqueue(2);
            queue.Enqueue(4);
            queue.Enqueue(5);

            for (int i = 0; i < queue.Count; i++)
            {
                Console.Write(queue[i] + " ");
            }
            Console.WriteLine();
            queue.Dequeue();
            for (int i = 0; i < queue.Count; i++)
            {
                Console.Write(queue[i] + " ");
            }

            queue.Clear();
            Console.WriteLine(queue.Count);
        }
    }
}