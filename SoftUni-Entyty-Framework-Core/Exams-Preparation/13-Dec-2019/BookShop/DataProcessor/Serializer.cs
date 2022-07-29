namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    // using System.Xml;
    //using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    Books = x.AuthorsBooks
                    .OrderByDescending(p => p.Book.Price).Select(b => new
                    {
                        BookName = b.Book.Name,
                        BookPrice = b.Book.Price.ToString("F2")
                    })
                   .ToList()
                })
                .ToList()
                .OrderByDescending(x => x.Books.Count())
                .ToList();

            return JsonConvert.SerializeObject(authors, Formatting.Indented);
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(BookXmlExportModel[]), new XmlRootAttribute("Books"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            StringWriter writer = new StringWriter(sb);


            var books = context.Books
                .Where(x => x.PublishedOn <= date && x.Genre.ToString() == "Science")
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.PublishedOn)
                .Take(10)
                .Select(x => new BookXmlExportModel
                {
                    Pages = x.Pages,
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
                })
                .ToArray();


            //serializer.Serialize(writer, books, namespaces);

            //return sb.ToString().TrimEnd();
            var xmlBooks = XmlConverter.Serialize<BookXmlExportModel[]>(books, "Books");

            return xmlBooks.ToString();
        }
    }
}