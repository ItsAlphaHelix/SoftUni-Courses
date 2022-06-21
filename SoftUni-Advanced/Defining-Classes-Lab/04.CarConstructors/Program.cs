using System;

namespace CarConstructors
{
    public class Car
    {
        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public void Drive(double dictance)
        {
            double fuelToConsume = dictance * FuelConsumption;

            if (FuelQuantity - fuelToConsume > 0)
            {
                FuelQuantity -= fuelToConsume;
            }

            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return $"Make: {this.Make}\nModel: {this.Model}" +
                $"\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}L";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car bmv = new Car("BMV", "X6", 1993, 5003, -50);
            Car defaultCar = new Car();
            Console.WriteLine($"Default Golf: {bmv.WhoAmI()}");

            Car car = new Car();
            car.Make = "VM";
            car.Model = "MK3";
            car.Year = 1992;
            car.FuelQuantity = 200;
            car.FuelConsumption = 200;

            car.Drive(2000);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
