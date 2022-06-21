using System;

namespace _01.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            private set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }

                fuelQuantity = value;
            }
        }
        public virtual double FuelConsumption
        {
            get => fuelConsumption;
            private set => fuelConsumption = value;
        }

        public double TankCapacity
        {
            get => tankCapacity;
            private set => tankCapacity = value;
        }
        public bool isEmpty { get; set; }

        public bool CanDrive(double km)
            => this.FuelQuantity - (km * this.FuelConsumption) >= 0;

        public void Drive(double km)
        {
            if (!CanDrive(km))
            {
                return;
            }

            this.FuelQuantity -= km * FuelConsumption;
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters;
        }
    }
}
