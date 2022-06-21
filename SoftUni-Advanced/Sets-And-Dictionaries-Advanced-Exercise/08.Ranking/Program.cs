using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contest = new Dictionary<string, string>();

            Dictionary<string, Dictionary<string, int>> participants =
                new Dictionary<string, Dictionary<string, int>>();

            string command = Console.ReadLine();

            while (command != "end of contests")
            {
                string[] commandArgs = command.Split(':');
                string contestName = commandArgs[0];
                string password = commandArgs[1];

                contest.Add(contestName, password);

                command = Console.ReadLine();
            }
            command = Console.ReadLine();

            while (command != "end of submissions")
            {
                string[] commandArgs = command.Split("=>");
                string contestName = commandArgs[0];
                string password = commandArgs[1];
                string participant = commandArgs[2];
                int points = int.Parse(commandArgs[3]);

                if (!contest.ContainsKey(contestName) || contest[contestName] != password)
                {
                    command = Console.ReadLine();
                    continue;
                }

                if (!participants.ContainsKey(participant))
                {
                    participants.Add(participant, new Dictionary<string, int>());
                }

                if (!participants[participant].ContainsKey(contestName))
                {
                    participants[participant].Add(contestName, 0);
                }

                if (participants[participant][contestName] < points)
                {
                    participants[participant][contestName] = points;
                }
                command = Console.ReadLine();
            }

            int topPoints = 0;
            string topName = string.Empty;

            foreach (var currentPoints in participants)
            {
                if (currentPoints.Value.Sum(x => x.Value) > topPoints)
                {
                    topPoints = currentPoints.Value.Sum(x => x.Value);
                    topName = currentPoints.Key;
                }
            }

            Console.WriteLine($"Best candidate is {topName} with total {topPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in participants.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key}");

                foreach (var item in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
