using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                string[] animalInfo = Console.ReadLine()
                    .Split(' ');
                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string geneder = animalInfo[2];

                if (input == "Cat")
                {
                    Cat cat = new Cat(name, age, geneder);
                    animals.Add(cat);
                }
                else if (input == "Dog")
                {
                    Dog dog = new Dog(name, age, geneder);
                    animals.Add(dog);
                }
                else if (input == "Frog")
                {
                    Frog frog = new Frog(name, age, geneder);
                    animals.Add(frog);
                }
                else if (input == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);
                    animals.Add(kitten);
                }
                else if (input == "Tomcat")
                {
                    Tomcat tomCat = new Tomcat(name, age);
                    animals.Add(tomCat);
                }
                input = Console.ReadLine();
            }
            foreach (var animal in animals)
            {
                
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
