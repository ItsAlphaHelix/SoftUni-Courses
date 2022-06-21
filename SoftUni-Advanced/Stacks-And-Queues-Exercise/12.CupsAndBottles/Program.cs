using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputCups = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int[] currentBottles = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(inputCups);
            Stack<int> bottles = new Stack<int>(currentBottles);

            int wastedLiters = 0;
            int currentCup = 0;
            bool isNewOne = true;

            while (cups.Any() && bottles.Any())
            {
                if (isNewOne)
                {
                    currentCup = cups.Peek();
                    isNewOne = false;
                }

                int currentBottle = bottles.Pop();

                if (currentCup - currentBottle <= 0)
                {
                    wastedLiters += currentBottle - currentCup;
                    cups.Dequeue();
                    isNewOne = true;
                }
                else
                {
                    currentCup -= currentBottle;
                }
            }
            if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedLiters}");
        }
    }
}
