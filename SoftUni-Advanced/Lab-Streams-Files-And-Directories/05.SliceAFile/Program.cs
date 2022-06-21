using System;
using System.IO;

namespace _05.SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream fileStream = new FileStream(
                "bigText.text", FileMode.OpenOrCreate);

            byte[] data = new byte[fileStream.Length];
            var bytePerFile = (int)Math.Ceiling(fileStream.Length / 4.0);

            for (int i = 1; i <= 4; i++)
            {
                byte[] buffer = new byte[bytePerFile];
                fileStream.Read(buffer);

                using FileStream writer = new FileStream($"Part-{i}.text", FileMode.OpenOrCreate);
                writer.Write(buffer);
            }
        }
    }
}
