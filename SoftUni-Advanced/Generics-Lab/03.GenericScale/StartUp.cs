using System;

namespace GenericScale
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            EqualityScale<int> numbers = new EqualityScale<int>(3, 3);
            Console.WriteLine(numbers.AreEqual());
        }
    }
}
