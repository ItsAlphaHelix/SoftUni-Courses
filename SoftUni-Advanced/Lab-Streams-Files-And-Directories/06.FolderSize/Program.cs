using System;
using System.IO;

namespace _06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"D:\SoftUni\LabStreamsFilesAndDirectories\01.OddLines\bin\Debug\netcoreapp3.1";
            string[] files = Directory.GetFiles(directoryPath);
            long totallength = 0;

            foreach (var file in files)
            {
                totallength += new FileInfo(file).Length;
            }
            Console.WriteLine(totallength);
        }
    }
}
