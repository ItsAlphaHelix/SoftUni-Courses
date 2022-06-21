using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = name
                => Console.WriteLine("Sir " + string.Join(Environment.NewLine + "Sir ", name));

            string[] names = Console.ReadLine()
                 .Split(' ');

            print(names);

        }
    }
}
