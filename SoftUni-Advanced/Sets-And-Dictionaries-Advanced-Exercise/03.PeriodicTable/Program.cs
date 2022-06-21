using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> unique = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] chemicalCompounds = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < chemicalCompounds.Length; j++)
                {
                    string curr = chemicalCompounds[j];
                    unique.Add(curr);
                }
            }

            foreach (var item in unique)
            {
                Console.Write(item + " ");
            }
        }
    }
}
