
namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;
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
            var db = new ProductShopContext();
            //db.Database.EnsureCreated();

            //Import data.
            //string usersXml = File.ReadAllText("../../../Datasets/users.xml");
            //string productsXml = File.ReadAllText("../../../Datasets/products.xml");
            //string categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            //string categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            //string result = ImportCategoryProducts(db, categoriesProductsXml);
            //Console.WriteLine(result);




            //Export data.
            //File.WriteAllText("../../../Datasets/products-in-range.xml", GetProductsInRange(db));
            //File.WriteAllText("../../../Datasets/users-sold-products.xml", GetSoldProducts(db));
            //File.WriteAllText("../../../Datasets/categories-by-products.xml", GetCategoriesByProductsCount(db));
            File.WriteAllText("../../../Datasets/users-and-products.xml", GetUsersWithProducts(db));

            var result = GetUsersWithProducts(db);
            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml) //Task 01.
        {
            IMapper mapper = new Mapper(MapperConfig.config);

            XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));
            StringReader reader = new StringReader(inputXml);

            var deserialize = (ImportUserDto[])serializer.Deserialize(reader);

            var users = mapper.Map<IEnumerable<User>>(deserialize);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml) //Task 02.
        {
            IMapper mapper = new Mapper(MapperConfig.config);

            XmlSerializer serializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));
            StringReader reader = new StringReader(inputXml);

            var deserialize = (ImportProductDto[])serializer.Deserialize(reader);

            var products = mapper.Map<IEnumerable<Product>>(deserialize);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml) //Task 03.
        {
            IMapper mapper = new Mapper(MapperConfig.config);

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));
            StringReader reader = new StringReader(inputXml);

            var deserialize = (ImportCategoryDto[])serializer.Deserialize(reader);

            var filtered = deserialize
                .Where(x => x.Name != null)
                .ToList();

            var categories = mapper.Map<IEnumerable<Category>>(filtered);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml) // Task 04.
        {
            IMapper mapper = new Mapper(MapperConfig.config);

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));
            StringReader reader = new StringReader(inputXml);

            var deserialize = (ImportCategoryProductDto[])serializer.Deserialize(reader);

            var CategoryIds = context.Categories.Select(x => x.Id).ToList();
            var ProductIds = context.Products.Select(x => x.Id).ToList();

            var filtered = deserialize
                .Where(x => CategoryIds.Contains(x.CategoryId) && ProductIds.Contains(x.ProductId)).ToList();

            var categoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(filtered);

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context) // Task 05.
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ProductInRangeDto[]), new XmlRootAttribute("Products"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            StringWriter writer = new StringWriter(sb);

            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(p => new ProductInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}",
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            serializer.Serialize(writer, products, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context) //Task 06.
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(UserProductDto[]), new XmlRootAttribute("Users"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            StringWriter writer = new StringWriter(sb);

            var users = context.Users
                .Where(x => x.ProductsSold.Count > 1)
                .Select(x => new UserProductDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(p => new SoldProductDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    }).ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            serializer.Serialize(writer, users, namespaces);

            return sb.ToString().TrimEnd();
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context) //Task 07.
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(CategoriesProductCountDto[]), new XmlRootAttribute("Categories"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            StringWriter writer = new StringWriter(sb);

            var categories = context.Categories
                .Select(x => new CategoriesProductCountDto
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(x => x.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(x => x.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            serializer.Serialize(writer, categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context) //Task 08.
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportModel), new XmlRootAttribute("Users"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            StringWriter writer = new StringWriter(sb);

            var users = context.Users
                .Where(x => x.ProductsSold.Count >= 1)
                .Select(x => new UsersWithProductsDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new UserSoldProduct
                    {
                        Count = x.ProductsSold.Count(),
                        Products = x.ProductsSold.Select(p => new SoldProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .Take(10)
                .ToArray();

            var result = new ExportModel
            {
                Count = context.Users.Where(x => x.ProductsSold.Any()).Count(),
                Users = users
            };

            serializer.Serialize(writer, result, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}