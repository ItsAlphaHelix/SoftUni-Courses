using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEvenOddNumbers = number => number % 2 == 0;
            
            Action<int[]> print = inputNumber
                => Console.WriteLine(string.Join(" ", inputNumber));

            List<int> numbers = new List<int>();
            int[] sequenceOfNumbs = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = sequenceOfNumbs[0]; i <= sequenceOfNumbs[1]; i++)
            {
                numbers.Add(i);
            }

            string command = Console.ReadLine();

            if (command == "even")
            {
                print(numbers.Where(x => isEvenOddNumbers(x)).ToArray());
            }
            else
            {
                print(numbers.Where(x => !isEvenOddNumbers(x)).ToArray());
            }
        }
    }
}
