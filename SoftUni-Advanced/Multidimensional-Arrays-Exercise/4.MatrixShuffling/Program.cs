using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = arrayOfNumbers[0];
            int cols = arrayOfNumbers[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] splittedMatrix = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = splittedMatrix[col];
                }
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs.Length == 5 && commandArgs[0] == "swap" &&
                    int.Parse(commandArgs[1]) < rows && int.Parse(commandArgs[2]) < cols)
                {
                    int oldRowIndex = int.Parse(commandArgs[1]);
                    int oldColIndex = int.Parse(commandArgs[2]);
                    int newRowIndex = int.Parse(commandArgs[3]);
                    int newColIndex = int.Parse(commandArgs[4]);

                    string temp = matrix[oldRowIndex, oldColIndex];
                    matrix[oldRowIndex, oldColIndex] = matrix[newRowIndex, newColIndex];
                    matrix[newRowIndex, newColIndex] = temp;
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row, col] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                command = Console.ReadLine();
            }
        }
    }
}
