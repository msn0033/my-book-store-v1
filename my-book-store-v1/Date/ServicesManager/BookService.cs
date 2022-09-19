using Microsoft.EntityFrameworkCore;
using my_book_store_v1.Date.Dto;
using my_book_store_v1.Date.Models;
using my_book_store_v1.Date.Repository;

namespace my_book_store_v1.Date.ServicesManager
{
    public class BookService : IRepository<Book>
    {
        #region ID
        private readonly AppDbContext _dbContext;

        public BookService(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        #endregion

        public async Task<IEnumerable<Book>> GetAllAsync() =>  await _dbContext.Books.ToListAsync();

        public async Task<Book> GetByIdAsync(int id)=> await _dbContext.Books.FirstOrDefaultAsync(e => e.Id == id);
      
        public async Task AddAsync(Book book)=> await _dbContext.AddAsync(book);

        public async Task<Book> DeleteAsync(int id)
        {
            var d = await GetByIdAsync(id);
            if (d == null)
                return null;
            _dbContext.Books.Remove(d);
         
            return d;
        }  
        public Book Update(Book? book)
        {

            _dbContext.Entry(book).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsExsitAsync(book.Id).GetAwaiter().GetResult())
                    return null;
                else

                    throw;
            }
            return book;
        }

        public async Task<bool> IsExsitAsync(int id) => await _dbContext.Books.AnyAsync(e => e.Id == id);

        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
