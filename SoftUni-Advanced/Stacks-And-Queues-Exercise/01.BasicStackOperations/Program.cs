using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray());

            //for (int i = 0; i < integers[1]; i++)
            //{
            //    stack.Pop();
            //}
            //if (stack.Count <= 0)
            //{
            //    Console.WriteLine(0);
            //}
            //else
            //{
            //    Console.WriteLine(stack.Contains(integers[2]) ? "true" : $"{stack.Min()}");
            //}

            int firstNumber = integers[1];
            int secondNumber = integers[2];

            for (int i = 0; i < firstNumber; i++)
            {
                stack.Pop();
            }
            if (stack.Count <= 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (stack.Contains(secondNumber))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    int minNumber = 0;
                    int maxNumber = stack.Peek();

                    if (minNumber < maxNumber)
                    {
                        minNumber = maxNumber;
                    }
                    Console.WriteLine(minNumber);
                }
            }
        }
    }
}
