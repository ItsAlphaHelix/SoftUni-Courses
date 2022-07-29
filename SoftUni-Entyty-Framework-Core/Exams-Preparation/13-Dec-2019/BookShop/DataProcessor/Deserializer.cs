namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();
            List<Book> listOfBooks = new List<Book>();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportXmlBookModel[]), new XmlRootAttribute("Books"));
            StringReader reader = new StringReader(xmlString);

            var importXmlBooks = (ImportXmlBookModel[])serializer.Deserialize(reader);

            foreach (var importXmlBook in importXmlBooks)
            {
                List<string> values = new List<string> { "1", "2", "3" };

                if (!IsValid(importXmlBook) || !values.Contains(importXmlBook.Genre))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var publishedOn = DateTime.ParseExact(importXmlBook.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                var books = new Book
                {
                    Name = importXmlBook.Name,
                    Genre = Enum.Parse<Genre>(importXmlBook.Genre),
                    Price = importXmlBook.Price,
                    Pages = importXmlBook.Pages,
                    PublishedOn = publishedOn
                };

                listOfBooks.Add(books);
                output.AppendLine($"Successfully imported book {books.Name} for {books.Price:F2}.");
            }

            context.Books.AddRange(listOfBooks);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorDtos = JsonConvert.DeserializeObject<ImportJsonAuthorModel[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Author> authors = new List<Author>();

            foreach (var authorDto in authorDtos)
            {
                if (!IsValid(authorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool doesEmailExists = authors
                    .FirstOrDefault(x => x.Email == authorDto.Email) != null;

                if (doesEmailExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Email = authorDto.Email,
                    Phone = authorDto.Phone
                };

                var uniqueBookIds = authorDto.Books.Distinct();

                foreach (var authorDtoAuthorBookDto in uniqueBookIds)
                {
                    var book = context.Books.Find(authorDtoAuthorBookDto.Id);

                    if (book == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = book
                    });
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(author);
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, (author.FirstName + " " + author.LastName), author.AuthorsBooks.Count));
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}