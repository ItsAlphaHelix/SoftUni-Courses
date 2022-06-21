using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] splittedNumbers = Console.ReadLine()
                 .Split(' ')
                 .Select(int.Parse)
                 .ToArray();

            int n = splittedNumbers[0];
            int m = splittedNumbers[1];

            HashSet<int> firsSetNumb = new HashSet<int>();
            HashSet<int> secondSetNumb = new HashSet<int>();

            bool isSecond = false;

            while (n > 0)
            {
                int numbers = int.Parse(Console.ReadLine());
                firsSetNumb.Add(numbers);
                n--;
            }

            while (m > 0)
            {
                int numbers = int.Parse(Console.ReadLine());
                secondSetNumb.Add(numbers);
                m--;
            }

            //List<int> number = firsSetNumb.Intersect(secondSetNumb).ToList();

            foreach (var firstNumb in firsSetNumb)
            {
                foreach (var secondNumb in secondSetNumb)
                {
                    if (firstNumb == secondNumb)
                    {
                        Console.Write(secondNumb + " ");
                    }
                }
            }
        }
    }
}
