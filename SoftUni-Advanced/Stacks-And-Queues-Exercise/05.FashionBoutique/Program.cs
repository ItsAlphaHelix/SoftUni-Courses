using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray());

            int capasity = int.Parse(Console.ReadLine());
            int currentRackClothes = 0;
            int rackCounter = 1;

            while (clothes.Count > 0)
            {
                if (currentRackClothes + clothes.Peek() > capasity)
                {
                    currentRackClothes = 0;
                    rackCounter++;
                }
                currentRackClothes += clothes.Pop();
            }
            Console.WriteLine(rackCounter);
        }
    }
}
