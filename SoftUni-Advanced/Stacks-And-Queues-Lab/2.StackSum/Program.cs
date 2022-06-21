using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbersAsString = Console.ReadLine();

            Stack<int> numbers = new Stack<int>();
            string[] numbersAsList = numbersAsString.Split(' ');

            foreach (var number in numbersAsList)
            {
                numbers.Push(int.Parse(number));
            }

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] commandArgs = line.Split(' ');
                string command = commandArgs[0].ToLower();

                if (command == "add")
                {
                    numbers.Push(int.Parse(commandArgs[1]));
                    numbers.Push(int.Parse(commandArgs[2]));
                }
                else if (command == "remove")
                {
                    int numberOfElementsToRemove = int.Parse(commandArgs[1]);

                    if (numberOfElementsToRemove <= numbers.Count)
                    {
                        for (int i = 0; i < numberOfElementsToRemove; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }
                line = Console.ReadLine();
            }

            // Console.WriteLine($"Sum: {numbers.Sum()}");

            int sum = 0;

            while (numbers.Count > 0)
            {
                int number = numbers.Pop();
                sum += number;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
