using System;

namespace CarManufacturer
{
  public class StartUp
    {
        static void Main(string[] args)
        {
            Tire[] tires = new Tire[4]
           {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3)
           };

            Engine engine = new Engine(560, 6300);

            Car myCar = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);

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
