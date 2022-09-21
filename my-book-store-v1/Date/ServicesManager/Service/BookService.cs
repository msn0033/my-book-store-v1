using Microsoft.EntityFrameworkCore;
using my_book_store_v1.Date.Dto;
using my_book_store_v1.Date.Models;
using my_book_store_v1.Date.ServicesManager.Interface;

namespace my_book_store_v1.Date.ServicesManager.Service
{
    public class BookService : IBook
    {
        private readonly AppDbContext _DbContext;

        #region DI context
        public BookService(AppDbContext appDbContext)
        {
            _DbContext = appDbContext;
        }
        #endregion

        public async Task<IEnumerable<Book>> GetBooksAsync() => await _DbContext.Books.ToListAsync();
        public async Task<Book> GetBookByIdAsync(int id) => await _DbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        public async Task<Book> GetBookByNameAsync(string name) => await _DbContext.Books.FirstOrDefaultAsync(b => b.Title == name);
        public async Task<Book> AddBookAsync(BookDto book)
        {
            Book b = new Book
            {
                Title = book.Title,
                Description = book.Description,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead : null,
                Rate = book.IsRead ? book.Rate : null,
                PublisherId = book.PublisherId,

            };
            await _DbContext.Books.AddAsync(b);
            await SaveAsync();
            foreach (var Id in book.AuthorIds)
            {
                var book_author = new Book_Author
                {
                    BookId = b.Id,
                    AuthorId = Id,
                    AddedOn = DateTime.Now

                };

                await _DbContext.Book_Authors.AddAsync(book_author);
            }
            await SaveAsync();
            return b;

        }
        public async Task<Book> UpdateBookAsync(BookDto book, int id)
        {
            var item = await GetBookByIdAsync(id);
            if (item == null) return null;

            if (item.Id == id)
            {
                item.Title = book.Title;
                item.Description = book.Description;
                item.Genre = book.Genre;
                item.CoverUrl = book.CoverUrl;
                item.DateAdded = DateTime.Now;
                item.IsRead = book.IsRead;
                item.DateRead = book.IsRead ? book.DateRead : null;
                item.Rate = book.IsRead ? book.Rate : null;
                item.PublisherId = book.PublisherId;

               // await SaveAsync();

                return item;
            }
            return null;

        }
        public async Task<Book> DeleteBookAsync(int id)
        {
            var re = await GetBookByIdAsync(id);
            if (re == null)
                return null;
            _DbContext.Remove(re);
            return re;
        }
        public async Task SaveAsync() => await _DbContext.SaveChangesAsync();
    }
}
