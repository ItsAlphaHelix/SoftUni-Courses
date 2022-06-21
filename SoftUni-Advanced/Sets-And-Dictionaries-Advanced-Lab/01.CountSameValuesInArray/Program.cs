using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbersByCount = new Dictionary<double, int>();

            double[] spittedNumbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            foreach (var number in spittedNumbers)
            {
                if (!numbersByCount.ContainsKey(number))
                {
                    numbersByCount.Add(number, 0);
                }

                numbersByCount[number]++;
            }

            foreach (var number in numbersByCount)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
