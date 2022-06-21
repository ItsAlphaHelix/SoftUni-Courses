using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader("line.text");

            int counter = 0;

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                if (counter % 2 != 0)
                {
                    Console.WriteLine(line);
                }

                counter++;
            }
        }
    }
}
