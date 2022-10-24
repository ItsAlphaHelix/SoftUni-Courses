using Library.Data.Models;
using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetAllAsync();

        Task AddBookToTheCollectionAsync(int bookId, string userId);

        Task<IEnumerable<BookViewModel>> GetMyBooks(string userId);

        Task AddBookAsync(AddBookViewModel model);

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task RemoveBookFromCollectionAsync(int bookId, string userId);
    }
}
