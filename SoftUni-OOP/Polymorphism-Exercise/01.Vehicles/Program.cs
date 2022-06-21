using System;
using System.Collections.Generic;

namespace _01.Vehicles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split(' ');
            string[] truckInfo = Console.ReadLine()
                .Split(' ');
            string[] busInfo = Console.ReadLine()
                .Split(' ');

            double carQunatity = double.Parse(carInfo[1]);
            double carConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            double truckQuantity = double.Parse(truckInfo[1]);
            double truckConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            double busQuantity = double.Parse(busInfo[1]);
            double busConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            IVehicle car = new Car(carQunatity, carConsumption, carTankCapacity);
            IVehicle truck = new Truck(truckQuantity, truckConsumption, truckTankCapacity);
            IVehicle bus = new Bus(busQuantity, busConsumption, busTankCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split(' ');
                string action = inputInfo[0];
                string vehicle = inputInfo[1];
                double value = double.Parse(inputInfo[2]);

                try
                {
                    if (action == "Drive")
                    {
                        if (vehicle == "Car")
                        {
                            if (car.CanDrive(value))
                            {
                                car.Drive(value);
                                Console.WriteLine($"Car travelled {value} km");
                            }
                            else
                            {
                                Console.WriteLine("Car needs refueling");
                            }
                        }
                        else if (vehicle == "Truck")
                        {
                            if (truck.CanDrive(value))
                            {
                                truck.Drive(value);
                                Console.WriteLine($"Truck travelled {value} km");
                            }
                            else
                            {
                                Console.WriteLine("Truck needs refueling");
                            }
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.isEmpty = false; 

                            if (bus.CanDrive(value))
                            {
                                bus.Drive(value);
                                Console.WriteLine($"Bus travelled {value} km");
                            }
                            else
                            {
                                Console.WriteLine("Bus needs refueling");
                            }
                        }
                    }
                    else if (action == "Refuel")
                    {
                        if (vehicle == "Truck")
                        {
                            truck.Refuel(value);
                        }
                        else if (vehicle == "Car")
                        {
                            car.Refuel(value);
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.Refuel(value);
                        }
                    }
                    else if (action == "DriveEmpty")
                    {
                        bus.isEmpty = true;

                        if (bus.CanDrive(value))
                        {
                            bus.Drive(value);
                            Console.WriteLine($"Bus travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Bus needs refueling");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        } 
    }
}
