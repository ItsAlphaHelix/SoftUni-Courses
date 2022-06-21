using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Telephony
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split(' ');
            string[] URLS = Console.ReadLine()
                .Split(' ');

            foreach (var number in phoneNumbers)
            {
                if (number.Length == 10)
                {
                    ISmartPhone smartPhone = new SmartPhone();
                    smartPhone.Calling(number);
                }
                else if (number.Length == 7)
                {
                    IStationaryPhone stationaryPhone = new StationaryPhone();
                    stationaryPhone.Dialing(number);
                }
            }

            foreach (var url in URLS)
            {
                ISmartPhone smartPhone = new SmartPhone();
                smartPhone.Browser(url);
            }
            //string[] phoneNumbers = Console.ReadLine()
            //  .Split(' ');
            //string[] URLS = Console.ReadLine()
            //    .Split(' ');

            //foreach (var number in phoneNumbers)
            //{
            //    bool isValidNumbers = number.All(char.IsDigit);
            //    if (!isValidNumbers)
            //    {
            //        Console.WriteLine("Invalid number!");
            //        continue;
            //    }
            //    if (number.Length == 10 && isValidNumbers)
            //    {
            //        Console.WriteLine($"Calling... {number}");
            //    }
            //    if (!(isValidNumbers))
            //    {
            //        Console.WriteLine("Invalid number!");
            //        continue;
            //    }
            //    if (number.Length == 7 && isValidNumbers)
            //    {
            //        Console.WriteLine($"Dialing... {number}");
            //    }

            //}
            //foreach (var url in URLS)
            //{
            //    bool isValidURL = url.Any(char.IsDigit);

            //    if (!isValidURL)
            //    {
            //        Console.WriteLine($"Browsing: {url}!");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid URL!");
            //    }
            //}
        }
    }
}
