using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Telephony
{
    public class SmartPhone : ISmartPhone
    {
        public void Browser(string URL)
        {
            // bool isValidURL = URL.Any(char.IsDigit);

            if (Regex.Match(URL, @"^http:\/\/[a-z]+\.[a-z]*$").Success)
            {
                Console.WriteLine($"Browsing: {URL}!");
            }
            else
            {
                Console.WriteLine("Invalid URL!");
            }
            
        }

        public void Calling(string number)
        {
            bool isValidNumber = number.All(char.IsDigit);

            if (isValidNumber)
            { 
                Console.WriteLine($"Calling... {number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }
    }
}
