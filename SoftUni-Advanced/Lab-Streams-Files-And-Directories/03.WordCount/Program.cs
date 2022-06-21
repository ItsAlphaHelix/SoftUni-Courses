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
           using StreamReader wordLine = new StreamReader(@"..\..\..\words.txt");
           using StreamReader inputLine = new StreamReader(@"..\..\..\input.txt");
           using StreamWriter output = new StreamWriter(@"..\..\..\output.txt");
           string[] arrayOfWords = wordLine.ReadLine().Split(" ");

            foreach (var word in arrayOfWords)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount.Add(word, 1);
                }
            }

            string[] arrayOfInputs = inputLine.ReadToEnd().Split(' ');

            foreach (var word in arrayOfInputs)
            {
                string lowerCaseWord = word.ToLower();

                if (wordsCount.ContainsKey(lowerCaseWord))
                {
                    wordsCount[lowerCaseWord]++;
                }
            }

            foreach (var count in wordsCount.OrderByDescending(x => x.Value))
            {
                string result = $"{count.Key} - {count.Value}";
                output.WriteLine(result);
            }
        }
    }
}
