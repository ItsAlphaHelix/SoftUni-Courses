using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get;}

        public double FuelConsumption { get;}

        public double TankCapacity { get;}

        public bool isEmpty { get; set; }

        public bool CanDrive(double km);

        void Drive(double km);

        void Refuel(double liters);
    }
}
