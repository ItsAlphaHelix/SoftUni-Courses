using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            for (int i = 1; i <= n; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(' ');

                var person = new Person(commandArgs[0], commandArgs[1],
                int.Parse(commandArgs[2]), decimal.Parse(commandArgs[3]));
                persons.Add(person);
            }
            decimal percentage = decimal.Parse(Console.ReadLine());

            foreach (var personInfo in persons)
            {
                personInfo.IncreaseSalary(percentage);
                Console.WriteLine(personInfo.ToString());
            }
        }
    }
}
