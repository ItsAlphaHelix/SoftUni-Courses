using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public void Dialing(string number)
        {
            bool isValidNumber = number.All(char.IsDigit);

            if (isValidNumber)
            { 
                Console.WriteLine($"Dialing... {number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }
    }
}
