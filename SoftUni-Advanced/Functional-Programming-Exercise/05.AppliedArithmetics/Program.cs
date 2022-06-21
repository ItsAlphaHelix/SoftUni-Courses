using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<int[], int[]> addNumber = number
                =>
            {
                for (int i = 0; i < number.Length; i++)
                {
                    number[i] += 1;
                }

                return number;
            };

            Func<int[], int[]> subtract = number
                =>
            {
                for (int i = 0; i < number.Length; i++)
                {
                    number[i] -= 1;
                }

                return number;
            };

            Func<int[], int[]> multiply = number
                =>
            {
                for (int i = 0; i < number.Length; i++)
                {
                    number[i] *= 2;
                }

                return number;
            };

            Action<int[]> print = number
            => Console.WriteLine(string.Join(" ", number));

            //1 2 3 4 5
            int[] sequenceOfNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();

            while (command != "end")
            {

                if (command == "add")
                {
                    addNumber(sequenceOfNumbers);
                }

                else if (command == "subtract")
                {
                    subtract(sequenceOfNumbers);
                }

                else if (command == "multiply")
                {
                    multiply(sequenceOfNumbers);
                }

                else if (command == "print")
                {
                    print(sequenceOfNumbers);
                }

                command = Console.ReadLine();
            }
        }
    }
}
