using System;
using System.IO;
namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileOne = File.ReadAllLines(@"..\..\..\inputOne.text");
            string[] fileTwo = File.ReadAllLines(@"..\..\..\inputTwo.text");

            using StreamWriter sw = File.CreateText(@"..\..\..\output.text");

            int lineNum = 0;
            while (lineNum < fileOne.Length || lineNum < fileTwo.Length)
            {
                if (lineNum < fileOne.Length)
                    sw.WriteLine(fileOne[lineNum]);
                if (lineNum < fileTwo.Length)
                    sw.WriteLine(fileTwo[lineNum]);
                lineNum++;

            }
        }
    }
}
