using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            //quantity of the food
            int quantity = int.Parse(Console.ReadLine());
            //quantity of an order
            int[] orders = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            //keep them in queue
            Queue<int> queueOfOrders = new Queue<int>();

            foreach (var order in orders)
            {
                queueOfOrders.Enqueue(order);
            }

            int maxOrder = int.MinValue;

            while (quantity > 0 && queueOfOrders.Count > 0)
            {
                int currentOrder = queueOfOrders.Peek();

                //biggest order 
                if (currentOrder > maxOrder)
                {
                    maxOrder = currentOrder;
                }

                if (quantity - currentOrder < 0)
                {
                    break;
                }
                quantity -= currentOrder;
                queueOfOrders.Dequeue();
            }

            Console.WriteLine($"{maxOrder}");

            if (queueOfOrders.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queueOfOrders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
