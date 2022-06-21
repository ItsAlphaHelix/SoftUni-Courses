using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> vlogger =
                new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string command = Console.ReadLine();

            string following = "following";
            string followers = "followers";

            while (command != "Statistics")
            {
                string[] commandArgs = command.Split(' ');
                string action = commandArgs[1];
                string user = commandArgs[0];
                string starUser = commandArgs[2];

                if (action == "joined" && !vlogger.ContainsKey(user))
                {
                    vlogger.Add(user, new Dictionary<string, SortedSet<string>>());
                    vlogger[user].Add(following, new SortedSet<string>());
                    vlogger[user].Add(followers, new SortedSet<string>());
                }

                else if (action == "followed" && vlogger.ContainsKey(user)
                    && vlogger.ContainsKey(starUser) && user != starUser)
                {
                    vlogger[user][following].Add(starUser);
                    vlogger[starUser][followers].Add(user);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {vlogger.Count} vloggers in its logs.");


            int count = 1;

            foreach (var currentVloger in vlogger.OrderByDescending(x => x.Value[followers].Count)
                .ThenBy(x => x.Value[following].Count))
            {
                Console.WriteLine($"{count}. {currentVloger.Key} : {currentVloger.Value[followers].Count} followers, {currentVloger.Value[following].Count} following");
            
                if (count == 1)
                {
                    foreach (var item in currentVloger.Value[followers])
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }
                count++;
            }
        }
    }
}
