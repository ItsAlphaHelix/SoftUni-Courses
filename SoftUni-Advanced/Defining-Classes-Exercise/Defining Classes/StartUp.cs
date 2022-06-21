using System;
using System.Linq;

namespace DefiningClasses
{
   public class StartUp
    {
       public static void Main(string[] args)
        {

            Family family = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(' ');
                string name = commandArgs[0];
                int age = int.Parse(commandArgs[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }

            family.People.Where(x => x.Age > 30)
                .OrderBy(x => x.Name)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
