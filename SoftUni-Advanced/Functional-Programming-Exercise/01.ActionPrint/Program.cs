using System;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = name => Console.WriteLine(string.Join(Environment.NewLine, name));

            string[] names = Console.ReadLine()
                .Split(' ');

            print(names);
        }
    }
}
