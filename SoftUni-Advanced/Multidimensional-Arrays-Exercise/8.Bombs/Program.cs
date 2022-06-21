using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] splittedNumbers = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = splittedNumbers[col];
                }
            }
            string[] coordinatesOfBoobs = Console.ReadLine()
                .Split(' ');

            foreach (var coordinate in coordinatesOfBoobs)
            {
                string[] currBomb = coordinate.Split(",");
                int bombRow = int.Parse(currBomb[0]);
                int bombCol = int.Parse(currBomb[1]);

                int bombPower = matrix[bombRow, bombCol];

                if (bombPower > 0)// Check if current bomb have positive value !
                {
                    //-1,-1
                    if (IsExist(matrix, bombRow - 1, bombCol - 1) && matrix[bombRow - 1, bombCol - 1] > 0 &&
                        matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow - 1, bombCol - 1] -= matrix[bombRow, bombCol];
                    }
                    //-1,0
                    if (IsExist(matrix, bombRow - 1, bombCol) && matrix[bombRow - 1, bombCol] > 0 &&
                        matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow - 1, bombCol] -= matrix[bombRow, bombCol];
                    }
                    //-1,+1
                    if (IsExist(matrix, bombRow - 1, bombCol + 1) && matrix[bombRow - 1, bombCol + 1] > 0 &&
                        matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow - 1, bombCol + 1] -= matrix[bombRow, bombCol];
                    }
                    //0,+1
                    if (IsExist(matrix, bombRow, bombCol + 1) && matrix[bombRow, bombCol + 1] > 0 &&
                        matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow, bombCol + 1] -= matrix[bombRow, bombCol];
                    }
                    //+1,+1
                    if (IsExist(matrix, bombRow + 1, bombCol) && matrix[bombRow + 1, bombCol] > 0 &&
                        matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow + 1, bombCol] -= matrix[bombRow, bombCol];
                    }
                    //+1,0
                    if (IsExist(matrix, bombRow + 1, bombCol + 1) && matrix[bombRow + 1, bombCol + 1] > 0 &&
                        matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow + 1, bombCol + 1] -= matrix[bombRow, bombCol];
                    }
                    //+1,-1
                    if (IsExist(matrix, bombRow, bombCol - 1) && matrix[bombRow, bombCol - 1] > 0 &&
                        matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow, bombCol - 1] -= matrix[bombRow, bombCol];
                    }
                    //0,-1
                    if (IsExist(matrix, bombRow + 1, bombCol - 1) && matrix[bombRow + 1, bombCol - 1] > 0 &&
                        matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow + 1, bombCol - 1] -= matrix[bombRow, bombCol];
                    }
                    matrix[bombRow, bombCol] = 0;
                }
            }
            int counter = 0;
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        counter++;
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {counter}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
        static bool IsExist(int[,] matrix, int bombRow, int bombCol)
        {
            return bombRow >= 0 && bombRow < matrix.GetLength(0) &&
                   bombCol >= 0 && bombCol < matrix.GetLength(1);
        }
    }
}
