using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> elements = new Stack<string>(Console.ReadLine().Split().Reverse());
            while (elements.Count > 1)
            {
                int a = int.Parse(elements.Pop());
                string @operator = elements.Pop();
                int b = int.Parse(elements.Pop());
                // elements.Push(@operator == "+" ? (a + b).ToString() : (a - b).ToString());

                if (@operator == "+")
                {
                    elements.Push((a + b).ToString());
                }
                else if (@operator == "-")
                {
                    elements.Push((a - b).ToString());
                }
            }

            Console.WriteLine(elements.Pop());
        }
    }
}
