using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();

            SortedDictionary<char, int> wordByCount = new SortedDictionary<char, int>();

                foreach (var ch in words)
                {
                    if (!wordByCount.ContainsKey(ch))
                    {
                        wordByCount.Add(ch, 0);
                    }

                    wordByCount[ch]++;
                }

            foreach (var count in wordByCount)
            {
                Console.WriteLine($"{count.Key}: {count.Value} time/s");
            }
        }
    }
}
