using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "Hi");
            Console.WriteLine(string.Join(", ", strings));
            int[] integers = ArrayCreator.Create(5, 10);
            Console.WriteLine(string.Join(", ", integers));
        }
    }
}
