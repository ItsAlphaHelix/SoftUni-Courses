using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> lengthNames = (name, lengthName) => name.Length <= lengthName;

            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(' ');

            string[] result = names.Where(x => lengthNames(x, length))
                .ToArray();

            foreach (var name in result)
            {
                Console.WriteLine(name);
            }
        }
    }
}
