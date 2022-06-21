using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> isDivisible = (n, m) => n % m == 0;


            int[] sequenceOfNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            int[] num = sequenceOfNumbers.Where(x => !isDivisible(x, n))
            .Reverse().ToArray();

            Console.WriteLine(string.Join(" ", num));
        }
    }
}
