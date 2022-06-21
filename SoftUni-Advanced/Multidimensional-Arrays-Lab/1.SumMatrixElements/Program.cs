using System;
using System.Linq;

namespace _1.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] input = Console.ReadLine()
            //    .Split(", ")
            //    .Select(int.Parse)
            //    .ToArray();

            //int[,] matrix = new int[input[0], input[1]];

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    int[] colElements = Console.ReadLine()
            //            .Split(", ")
            //            .Select(int.Parse)
            //            .ToArray();

            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        matrix[row, col] = colElements[col];
            //    }
            //}

            //int sum = 0;

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        sum += matrix[row, col];
            //    }
            //}

            //Console.WriteLine(matrix.GetLength(0));
            //Console.WriteLine(matrix.GetLength(1));
            //Console.WriteLine(sum);

            string input = Console.ReadLine();
            string[] inputArray = input.Split(", ");
            int rows = int.Parse(inputArray[0]);
            int cols = int.Parse(inputArray[1]);
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();
                string[] colElements = line.Split(", ");

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(colElements[col]);
                }
            }

            int sum = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    sum += matrix[row, col];
                }
            }
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
