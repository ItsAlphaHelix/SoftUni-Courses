using System;

namespace Operations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            MathOperations operation = new MathOperations();

            Console.WriteLine(operation.Add(2, 3));

            Console.WriteLine(operation.Add(2.2, 3.3, 5.5));

            Console.WriteLine(operation.Add(2.3M, 3.4M, 7.7M));
        }
    }
}
