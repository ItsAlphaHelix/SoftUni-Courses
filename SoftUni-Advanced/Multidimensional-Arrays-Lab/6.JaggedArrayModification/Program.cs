using System;

namespace _6.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] array = new int[n][];

            for (int i = 0; i < n; i++)
            {
                string[] splitted = Console.ReadLine()
                    .Split(' ');
                array[i] = new int[splitted.Length];

                for (int j = 0; j < splitted.Length; j++)
                {
                    array[i][j] = int.Parse(splitted[j]);
                }
            }
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArgs = command.Split(' ');
                string action = commandArgs[0];
                int arrayIndex = int.Parse(commandArgs[1]);
                int arrayElement = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);

                if (arrayIndex < 0 || arrayIndex >= array.Length ||
                   arrayElement < 0 || arrayElement >= array[arrayIndex].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    command = Console.ReadLine();
                    continue;
                }

                if (action == "Add")
                {
                    array[arrayIndex][arrayElement] += value;
                }
                else if (action == "Subtract")
                {
                    array[arrayIndex][arrayElement] -= value;
                }
                command = Console.ReadLine();
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
