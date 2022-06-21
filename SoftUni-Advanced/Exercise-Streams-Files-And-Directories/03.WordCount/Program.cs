using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            string[] wordLines = File.ReadAllLines(@"..\..\..\words.txt");
            string[] textLines = File.ReadAllLines(@"..\..\..\text.txt");

            foreach (var word in wordLines)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount.Add(word, 1);
                }
            }

            foreach (var line in textLines)
            {
                string[] words = line.Split(' ');

                foreach (var word in words)
                {
                    string loweCaseWord = word.ToLower();
                    
                    if (wordsCount.ContainsKey(loweCaseWord))
                    {
                        wordsCount[loweCaseWord]++;
                    }
                }
            }

            foreach (var item in wordsCount.OrderByDescending(x => x.Value))
            {
                string result = $"{item.Key} - {item.Value}{Environment.NewLine}";
                File.AppendAllText(@"..\..\..\actualResult.txt", result);
            }
        }
    }
}
