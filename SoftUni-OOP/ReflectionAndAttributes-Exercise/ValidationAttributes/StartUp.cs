using System;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person("Mitko", 20);

            bool isValidEntity = Vlidator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
