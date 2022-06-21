using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {

            string command = Console.ReadLine();
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            bool partyStart = false;

            while (command != "END")
            {
                string peoples = command;

                if (peoples == "PARTY")
                {
                    partyStart = true;
                    command = Console.ReadLine();
                    continue;
                }

                if (partyStart)
                {
                    vip.Remove(peoples);
                    regular.Remove(peoples);
                }

                else
                {
                    if (char.IsDigit(peoples[0]))
                    {
                        vip.Add(peoples);
                    }
                    else
                    {
                        regular.Add(peoples);
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(vip.Count + regular.Count);

            foreach (var v in vip)
            {
                Console.WriteLine(v);
            }

            foreach (var r in regular)
            {
                Console.WriteLine(r);
            }
        }
    }
}
