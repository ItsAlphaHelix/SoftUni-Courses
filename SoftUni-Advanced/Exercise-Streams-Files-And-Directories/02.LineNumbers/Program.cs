using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = File.ReadAllLines(@"..\..\..\tex.txt");
            List<string> outputFile = new List<string>();
            for (int i = 0; i < file.Length; i++)
            {
                int countLetters = file[i].Count(symbol => char.IsLetter(symbol));
                int punctuationCount = file[i].Count(punct => char.IsPunctuation(punct));

                outputFile.Add($"Line {i + 1}: {file[i]} ({countLetters})({punctuationCount})");

                File.WriteAllLines(@"..\..\..\output.txt", outputFile);
            }
        }
    }
}
