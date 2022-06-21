using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
   public class Engine
    {
        public Engine(int hoursePower, int cubicCapacity)
        {
            this.HorsePower = hoursePower;
            this.CubicCapacity = cubicCapacity;
        }
        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }
    }
}
