namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Dto.Import;
    using CarDealer.Dtos.Export;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;
    using CarDealer.XML_Helper;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //db.Database.EnsureCreated();

            //Import data.
            //string suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //string partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //string carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //string customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //string salesXml = File.ReadAllText("../../../Datasets/sales.xml");

            //var result = ImportSales(db, salesXml);
            //Console.WriteLine(result);




            //Export data.
            //File.WriteAllText("../../../Datasets/cars.xml", GetCarsWithDistance(db));
            //File.WriteAllText("../../../Datasets/bmw-cars.xml", GetCarsFromMakeBmw(db));
            //File.WriteAllText("../../../Datasets/local-suppliers.xml", GetLocalSuppliers(db));
            //File.WriteAllText("../../../Datasets/cars-and-parts.xml", GetCarsWithTheirListOfParts(db));
            //File.WriteAllText("../../../Datasets/customers-total-sales.xml", GetTotalSalesByCustomer(db));
            File.WriteAllText("../../../Datasets/sales-discounts.xml", GetSalesWithAppliedDiscount(db));

            var result = GetSalesWithAppliedDiscount(db);
            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml) //Task 09.
        {
            IMapper mapper = new Mapper(MapperConfig.config);

            XmlSerializer serializer = new XmlSerializer(typeof(SupplierDto[]), new XmlRootAttribute("Suppliers"));
            StringReader reader = new StringReader(inputXml);

            var deserialize = (SupplierDto[])serializer.Deserialize(reader);

            var suppliers = mapper.Map<IEnumerable<Supplier>>(deserialize);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml) //Task 10.
        {
            IMapper mapper = new Mapper(MapperConfig.config);

            XmlSerializer serializer = new XmlSerializer(typeof(PartDto[]), new XmlRootAttribute("Parts"));
            StringReader reader = new StringReader(inputXml);

            var deserialize = (PartDto[])serializer.Deserialize(reader);

            var supplierIds = context.Suppliers.Select(x => x.Id);

            var filtered = deserialize
                .Where(x => supplierIds.Contains(x.SupplierId))
                .ToList();

            var suppliers = mapper.Map<IEnumerable<Part>>(filtered);

            context.Parts.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }
        public static string ImportCars(CarDealerContext context, string inputXml) //Task 11.
        {
            //First way.
            XmlSerializer serializer = new XmlSerializer(typeof(CarDto[]), new XmlRootAttribute("Cars"));
            StringReader reader = new StringReader(inputXml);

            var deserialize = (CarDto[])serializer.Deserialize(reader);


            //Second way with Xml Facade.
            const string root = "Cars";

            var cars = new List<Car>();
            var carsDeserialize = XmlConverter.Deserializer<CarDto>(inputXml, root);

            var allparts = context.Parts.Select(x => x.Id).ToList();

            foreach (var currentCar in carsDeserialize)
            {
                var distinctedParts = currentCar.CarParts.Select(x => x.Id).Distinct();
                var parts = distinctedParts.Intersect(allparts);

                var car = new Car
                {
                    Make = currentCar.Make,
                    Model = currentCar.Model,
                    TravelledDistance = currentCar.TravelledDistance
                };

                foreach (var part in parts)
                {
                    var partCar = new PartCar
                    {
                        PartId = part
                    };

                    car.PartCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml) //Task 12.
        {
            IMapper mapper = new Mapper(MapperConfig.config);

            XmlSerializer serializer = new XmlSerializer(typeof(CustomerDto[]), new XmlRootAttribute("Customers"));
            StringReader reader = new StringReader(inputXml);

            var deserialize = (CustomerDto[])serializer.Deserialize(reader);

            var customers = mapper.Map<IEnumerable<Customer>>(deserialize);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml) //Task 13.
        {
            IMapper mapper = new Mapper(MapperConfig.config);

            XmlSerializer serializer = new XmlSerializer(typeof(SaleDto[]), new XmlRootAttribute("Sales"));
            StringReader reader = new StringReader(inputXml);

            var deserialize = (SaleDto[])serializer.Deserialize(reader);

            var carIds = context.Cars.Select(x => x.Id);

            var filtered = deserialize
                .Where(x => carIds.Contains(x.CarId))
                .ToList();

            var sales = mapper.Map<IEnumerable<Sale>>(filtered);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }
        public static string GetCarsWithDistance(CarDealerContext context) //Task 14.
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(CarWithDistanceDto[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            StringWriter writer = new StringWriter(sb);

            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .Select(p => new CarWithDistanceDto
                {
                    Make = p.Make,
                    Model = p.Model,
                    TravelledDistance = p.TravelledDistance,
                    
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            serializer.Serialize(writer, cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context) // Task 15.
        {
            StringBuilder sb = new StringBuilder();

            //XmlSerializer serializer = new XmlSerializer(typeof(CarFromMakeBMWDto[]), new XmlRootAttribute("cars"));
            //XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //namespaces.Add("", "");
            //StringWriter writer = new StringWriter(sb);

            const string root = "cars";


            var carsWithMakeBMW = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new CarFromMakeBMWDto
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            // serializer.Serialize(writer, carsWithMakeBMW, namespaces);
            var serializedCars = XmlConverter.Serialize<CarFromMakeBMWDto>(carsWithMakeBMW, root);

            return serializedCars.TrimEnd();
            //return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context) //Task 16.
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new LocalSupplierDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToArray();

            const string root = "suppliers";

            var serializedSuppliers = XmlConverter.Serialize<LocalSupplierDto>(suppliers, root);

            return serializedSuppliers.TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context) //Task 17.
        {
            var cars = context.Cars
                .Select(x => new CarPartListDto
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(x => new PartsDto
                    {
                        Name = x.Part.Name,
                        Price = x.Part.Price
                    })
                    .OrderByDescending(x => x.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            const string root = "cars";

            var serializedCars = XmlConverter.Serialize<CarPartListDto>(cars, root);

            return serializedCars.TrimEnd();
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context) //Task 18.
        {
            var customers = context.Sales
                .Where(x => x.Customer.Sales.Count > 0)
                .Select(x => new SalesByCustomerDto
                {
                    FullName = x.Customer.Name,
                    Cars = x.Customer.Sales.Count,
                    SpentMoney = x.Car.PartCars.Sum(x => x.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            const string root = "customers";

            var serializedCustomers = XmlConverter.Serialize<SalesByCustomerDto>(customers, root);

            return serializedCustomers.TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context) //Task 19.
        {
            var sales = context.Sales
                .Select(x => new SalesWithDiscount
                {
                    Car = new CarSaleDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(x => x.Part.Price),
                    PriceWithDiscount = x.Car.PartCars.Sum(p => p.Part.Price) - x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100
                })
                .ToArray();

            const string root = "sales";

            var serializedSales = XmlConverter.Serialize<SalesWithDiscount>(sales, root);

            return serializedSales.TrimEnd();
        }
    }
}