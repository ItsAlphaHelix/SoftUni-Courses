using System;

namespace _01.Person
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string nameInput = Console.ReadLine();
            int ageInput = int.Parse(Console.ReadLine());

            Person person;
            if (ageInput < 0)
            {
                return;
            }
            if (ageInput <= 15)
            {
                person = new Child(nameInput, ageInput);
            }
            else
            {
                person = new Person(nameInput, ageInput);
            }
            Console.WriteLine(person);
        }
    }
}
