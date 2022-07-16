using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //db.Database.EnsureCreated();

            //Import data.
            //string suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //string partsJson = File.ReadAllText("../../../Datasets/parts.json");
            //string carsJson = File.ReadAllText("../../../Datasets/cars.json");
            //string customersJson = File.ReadAllText("../../../Datasets/customers.json");
            //string salesJson = File.ReadAllText("../../../Datasets/sales.json");
            //var result = ImportSales(db, salesJson);
            //Console.WriteLine(result);





            //Export data.
            //File.WriteAllText("../../../Datasets/ordered-customers.json", GetOrderedCustomers(db));
            //File.WriteAllText("../../../Datasets/toyota-cars.json", GetCarsFromMakeToyota(db));
            //File.WriteAllText("../../../Datasets/local-suppliers.json", GetLocalSuppliers(db));
            //File.WriteAllText("../../../Datasets/local-suppliers.json", GetCarsWithTheirListOfParts(db));
            //File.WriteAllText("../../../Datasets/local-suppliers.json", GetTotalSalesByCustomer(db));
            File.WriteAllText("../../../Datasets/sales-discounts.json", GetSalesWithAppliedDiscount(db));

            var result = GetSalesWithAppliedDiscount(db);
            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson) //Task 01.
        {
            IMapper mapper = new Mapper(MapperConfig.config);

            var deserialize = JsonConvert.DeserializeObject<IEnumerable<SupplierDto>>(inputJson);

            var suppliers = mapper.Map<IEnumerable<Supplier>>(deserialize);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson) //Task 02.
        {
            IMapper mapper = new Mapper(MapperConfig.config);

            int[] supplierIds = context.Suppliers.Select(x => x.Id).ToArray();

            var deserialize = JsonConvert.DeserializeObject<IEnumerable<PartDto>>(inputJson)
                 .Where(x => supplierIds.Contains(x.SupplierId));

            var parts = mapper.Map<IEnumerable<Part>>(deserialize);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson) //Task 03.
        {
            IMapper mapper = new Mapper(MapperConfig.config);

            var cars = new List<Car>();

            var deserialize = JsonConvert.DeserializeObject<IEnumerable<CarDto>>(inputJson);

            foreach (var car in deserialize)
            {
                Car currentCar = mapper.Map<Car>(car);

                foreach (var partId in car.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson) //Task 04.
        {
            IMapper mapper = new Mapper(MapperConfig.config);

            var deserialize = JsonConvert.DeserializeObject<IEnumerable<CustomerDto>>(inputJson);

            var customers = mapper.Map<IEnumerable<Customer>>(deserialize);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson) //Task 05.
        {
            IMapper mapper = new Mapper(MapperConfig.config);

            var deserialize = JsonConvert.DeserializeObject<IEnumerable<SaleDto>>(inputJson);

            var sales = mapper.Map<IEnumerable<Sale>>(deserialize);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context) //Task 06.
        {
            var customers = context.Customers
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYoungDriver
                })
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                DateFormatString = "dd/MM/yyyy",
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(customers, settings);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .Select(x => new
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context) //Task 07.
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToList();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context) //Task 08.
        {
            var cars = context.Cars
                .Include(x => x.PartCars)
                .Select(x => new
                {
                    car = new 
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance,
                    },
                    parts = x.PartCars.Select(p => new
                    {
                            
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("F2")
                                
                    }),
                })
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context) //Task 09.
        {

            var sales = context.Sales
                .Where(x => x.Customer.Sales.Any())
                .Select(x => new
                {
                    FullName = x.Customer.Name,
                    BoughtCars = x.Customer.Sales.Count(),
                    SpentMoney = x.Customer.Sales.Sum(y => y.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .Distinct()
                .ToArray();

            DefaultContractResolver resolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = resolver,
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(sales, settings);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context) //Task 10.
        {
            var sales = context.Sales
                 .Take(10)
                 .Select(x => new
                 {
                     car = new
                     {
                         Make = x.Car.Make,
                         Model = x.Car.Model,
                         TravelledDistance = x.Car.TravelledDistance
                     },
                     customerName = x.Customer.Name,
                     Discount = x.Discount.ToString("f2"),
                     price = x.Car.PartCars.Sum(p => p.Part.Price).ToString("f2"),
                     priceWithDiscount = (x.Car.PartCars.Sum(p => p.Part.Price) - x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100).ToString("f2")
                 })
                 .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }
    }
}