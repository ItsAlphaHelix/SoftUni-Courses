using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
   public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public double TravelledDisctance { get; set; } = 0;

        public void Drive(double disctance)
        {
            double fuelConsumption = disctance * FuelConsumptionPerKm;

            if (FuelAmount - fuelConsumption >= 0)
            {
                FuelAmount -= fuelConsumption;
                TravelledDisctance += disctance;
            }

            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:F2} {TravelledDisctance}";
        }
    }
}
