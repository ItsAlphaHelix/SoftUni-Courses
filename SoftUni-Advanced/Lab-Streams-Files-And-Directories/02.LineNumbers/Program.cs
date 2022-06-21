using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader("input.text");
            using StreamWriter sw = new StreamWriter("countLine.text");

            int count = 1;

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                sw.WriteLine($"{count}. {line}");
                count++;
            }
        }
    }
}
