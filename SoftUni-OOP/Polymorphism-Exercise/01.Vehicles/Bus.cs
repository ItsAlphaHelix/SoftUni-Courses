using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override double FuelConsumption
            => this.isEmpty
            ? base.FuelConsumption
            : base.FuelConsumption + 1.4;
    }
}
