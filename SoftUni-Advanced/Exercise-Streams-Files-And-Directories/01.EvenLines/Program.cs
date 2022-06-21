using System;
using System.IO;
using System.Linq;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"..\..\..\text.txt");
            string[] specialSybols = new string[] { "-", ",", ".", "!", "?" };
            bool isEvent = true;

            while (!sr.EndOfStream)
            {
                string result = sr.ReadLine();

                if (!isEvent)
                {
                    isEvent = true;
                    continue;
                }

                foreach (var symbol in specialSybols)
                {
                    result = result.Replace(symbol, "@");
                }

                Console.WriteLine(string.Join(" ", result.Split().Reverse()));

                isEvent = false;
            }
        }
    }
}
