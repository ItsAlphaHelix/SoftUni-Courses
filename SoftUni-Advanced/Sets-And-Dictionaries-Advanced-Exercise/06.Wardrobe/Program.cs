using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> colorByClothesByCount = new Dictionary<string, Dictionary<string, int>>();


            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(" -> ");
                string color = commandArgs[0];
                string[] clothes = commandArgs[1]
                    .Split(",");

                if (!colorByClothesByCount.ContainsKey(color))
                {
                    colorByClothesByCount.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in clothes)
                {
                    if (!colorByClothesByCount[color].ContainsKey(item))
                    {
                        colorByClothesByCount[color].Add(item, 0);
                    }

                    colorByClothesByCount[color][item]++;
                }
            }

            string[] colorClothes = Console.ReadLine()
                .Split(" ");
            string findColor = colorClothes[0];
            string findClothes = colorClothes[1];

            foreach (var item in colorByClothesByCount)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var count in item.Value)
                {

                    if (findColor == item.Key && findClothes == count.Key)
                    {
                        Console.WriteLine($"* {count.Key} - {count.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {count.Key} - {count.Value}");
                    }
                }
            }
        }
    }
}
