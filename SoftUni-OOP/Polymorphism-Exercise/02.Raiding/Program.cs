using System;
using System.Collections.Generic;

namespace Raiding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IBaseHero> heros = new List<IBaseHero>();

            int n = int.Parse(Console.ReadLine());
            int totalAbilityPower = 0;

            IBaseHero heroInfo = null;
            int count = 0;

            while (n != count)
            {
                string name = Console.ReadLine();
                string typeOfHero = Console.ReadLine();

                if (typeOfHero == "Paladin")
                {
                    heroInfo = new Paladin(typeOfHero, name);
                    heros.Add(heroInfo);
                }
                else if (typeOfHero == "Druid")
                {
                    heroInfo = new Druid(typeOfHero, name);
                    heros.Add(heroInfo);
                }
                else if (typeOfHero == "Rogue")
                {
                    heroInfo = new Rogue(typeOfHero, name);
                    heros.Add(heroInfo);
                }
                else if (typeOfHero == "Warrior")
                {
                    heroInfo = new Warrior(typeOfHero, name);
                    heros.Add(heroInfo);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
                count++;
            }

            foreach (var hero in heros)
            {
                totalAbilityPower += hero.AbilityPower;

                Console.WriteLine(hero.CastAbility());
            }
            int bossAbilityPower = int.Parse(Console.ReadLine());

            string result = (totalAbilityPower >= bossAbilityPower)
            ? "Victory!"
            : "Defeat...";

            Console.WriteLine(result);
        }
    }
}
