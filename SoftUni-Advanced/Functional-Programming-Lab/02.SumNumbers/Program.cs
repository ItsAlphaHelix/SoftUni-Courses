using System;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int count = numbers.Count();
            int sumofNumber = numbers.Sum();

            Console.WriteLine(count);
            Console.WriteLine(sumofNumber);
        }
    }
}
