using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<int[], int> numbers = number
                =>
            {
                int minValue = int.MaxValue;

                for (int i = 0; i < number.Length; i++)
                {
                    if (minValue > number[i])
                    {
                        minValue = number[i];
                    }
                }
                return minValue;
            };

            int[] sequenceOfNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(numbers(sequenceOfNumbers));
        }
    }
}
