using my_book_store_v1.Data.Dto;
using my_book_store_v1.Data.Models;

namespace my_book_store_v1.Data.ServicesManager.Interface
{
    public interface IBook
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> GetBookByNameAsync(string name);
        Task<Book> AddBookAsync(BookDto book);
        Task<Book> DeleteBookAsync(int id);
        Task<Book> UpdateBookAsync(BookDto book,int id);
        //Task<bool> IsExistsAsync(int id);
        Task SaveAsync();

    }
}
