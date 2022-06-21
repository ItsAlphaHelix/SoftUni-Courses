using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbers = new Queue<int>();
            List<int> addNumbers = new List<int>();

            for (int i = 0; i < numbersList.Length; i ++)
            {
                if (numbersList[i] % 2 == 0)
                {
                    numbers.Enqueue(numbersList[i]);
                    addNumbers.Add(numbers.Dequeue());
                }
            }
            Console.WriteLine(string.Join(", ", addNumbers));
        }
    }
}
