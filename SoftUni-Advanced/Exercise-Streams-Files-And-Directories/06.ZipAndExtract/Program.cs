using System;
using System.IO;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDirectory = @"C:\Users\PC01\Desktop\MyFolder";
            string targerDirectory = @"C:\Users\PC01\Desktop\result.zip";
            string destinationDirectory = @"C:\Users\PC01\Desktop\result";

            ZipFile.CreateFromDirectory(sourceDirectory, targerDirectory);
            ZipFile.ExtractToDirectory(targerDirectory, destinationDirectory);
        }
    }
}
