using System;
using System.Collections.Generic;
using System.Text;

namespace _6.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> names = new Queue<string>();

            StringBuilder sb = new StringBuilder();

            while (input != "End")
            {
                if (input == "Paid")
                {
                    foreach (var name in names)
                    {
                        sb.Append(name);
                        sb.AppendLine();
                    }
                    names.Clear();
                    input = Console.ReadLine();
                    continue;
                }
                names.Enqueue(input);
                input = Console.ReadLine();
            }
            Console.Write(sb);
            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
