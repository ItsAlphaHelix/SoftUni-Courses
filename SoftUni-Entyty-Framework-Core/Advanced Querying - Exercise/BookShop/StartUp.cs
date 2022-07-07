namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            RemoveBooks(db);
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command) //Task 02.
        {
            var ageClause = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .ToList()
                .Where(x => x.AgeRestriction == ageClause)
                .Select(x => x.Title)
                .OrderBy(x => x);

            return string.Join("\n", books);
        }

        public static string GetGoldenBooks(BookShopContext context) //Task 03.
        {
            var goldenClause = Enum.Parse<EditionType>(EditionType.Gold.ToString(), true);

            var books = context.Books
                 .Where(x => x.EditionType == goldenClause && x.Copies < 5000)
                 .OrderBy(x => x.BookId)
                 .Select(x => new
                 {
                     Title = x.Title
                 })
                 .ToList();

            string book = null;

            foreach (var b in books)
            {
                book += $"{b.Title}\n";
            }

            return book;
        }

        public static string GetBooksByPrice(BookShopContext context) //Task 04.
        {
            var books = context.Books
                .Select(x => new
                {
                    Title = x.Title,
                    Price = x.Price
                })
                .Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - ${b.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year) //Task 05.
        {

            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    Title = x.Title
                }).ToList();

            string result = null;

            foreach (var b in books)
            {
                result += $"{b.Title}\n";
            }

            return result;
        }

        public static string GetBooksByCategory(BookShopContext context, string input) //Task 06.
        {

                var books = context.Books
                    .Where(x => x.BookCategories.Any(x => input.Trim().ToLower().Contains(x.Category.Name.ToLower())))
                    .Select(x => new
                    {
                        Title = x.Title
                    })
                    .OrderBy(x => x.Title)
                    .ToList();

                string result = null;

                foreach (var book in books)
                {
                    result += $"{book.Title}\n";
                }
            return result;
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date) //Task 07.
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .Select(x => new
                {
                    Title = x.Title,
                    EditionType = x.EditionType,
                    Price = x.Price,
                    ReleaseDate = x.ReleaseDate
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input) //Task 08.
        {
            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => new
                {
                    FullName = string.Concat(x.FirstName, " ", x.LastName)
                })
                .ToList();

            string author = null;

            foreach (var a in authors)
            {
                author += $"{a.FullName}\n";
            }

            return author;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input) //Task 09.
        {
            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => new
                {
                    Title = x.Title
                })
                .OrderBy(x => x.Title)
                .ToList();

            string book = null;

            foreach (var b in books)
            {
                book += $"{b.Title}\n";
            }

            return book;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input) //Task 10.
        {
            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()) && x.AuthorId == x.Author.AuthorId)
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    Title = x.Title,
                    Author = string.Concat(x.Author.FirstName, " ", x.Author.LastName)
                }).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.Author})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck) //Task 11.
        {
            var books = context.Books
                .Where(x => x.Title.Length > lengthCheck).ToList();

            return books.Count;
        }

        public static string CountCopiesByAuthor(BookShopContext context) //Task 12.
        {
            var books = context.Authors
                .Select(x => new
                {
                    Author = string.Concat(x.FirstName, " ", x.LastName),
                    TotalCopies = x.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(x => x.TotalCopies)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Author} - {book.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context) //Task 13.
        {
            var books = context.Categories
                .Select(x => new
                {
                   CategoryName = x.Name,
                   TotalProfit = x.CategoryBooks.Sum(x => x.Book.Copies * x.Book.Price)
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.CategoryName} ${book.TotalProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context) //Task 14.
        {
            var books = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    CategoryBook = x.CategoryBooks.Select(x => new
                    {
                        Title = x.Book.Title,
                        ReleaseDate = x.Book.ReleaseDate
                    })
                    .OrderByDescending(x => x.ReleaseDate)
                    .Take(3)
                })
                .OrderBy(x => x.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"--{book.CategoryName}");

                foreach (var category in book.CategoryBook)
                {
                    sb.AppendLine($"{category.Title} ({category.ReleaseDate.Value.Year})");
                }   
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context) //Task 15.
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }
        }

        public static int RemoveBooks(BookShopContext context) //Task 16.
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            //Alternative
            //context.Books.RemoveRange(books);

            foreach (var book in books)
            {
                context.Books.Remove(book);
            }

            context.SaveChanges();

            return books.Count();
        }
    }
}
