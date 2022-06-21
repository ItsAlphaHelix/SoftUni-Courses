using System;
using System.Linq;

namespace _3.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int rows = arrayOfNumbers[0];
            int cols = arrayOfNumbers[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                int[] splittedMatrix = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = splittedMatrix[col];
                }
            }

            int bestSum = int.MinValue;
            int bestRowIndex = 0;
            int bestColIndex = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int firstRowSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    int secondRowSum = matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                    int thirdRowSum = matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    int currentSum = firstRowSum + secondRowSum + thirdRowSum;

                    if (currentSum > bestSum)
                    {
                        bestSum = currentSum;
                        bestRowIndex = row;
                        bestColIndex = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {bestSum}");

            for (int row = bestRowIndex; row <= bestRowIndex + 2; row++)
            {
                for (int col = bestColIndex; col <= bestColIndex + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
