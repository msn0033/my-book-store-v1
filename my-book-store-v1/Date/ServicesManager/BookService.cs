using Microsoft.EntityFrameworkCore;
using my_book_store_v1.Date.Dto;
using my_book_store_v1.Date.Models;
using my_book_store_v1.Date.Repository;

namespace my_book_store_v1.Date.ServicesManager
{
    public class BookService : IRepository<Book>
    {
        private readonly AppDbContext _dbContext;
  
        public BookService(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _dbContext.Books.ToListAsync();
        }
        public async Task<Book?> GetById(int? id)
        {
            
                var e= await _dbContext.Books.FindAsync(id);
            return e;
        }
        public async Task Add(Book book)
        {
            _dbContext.Add(book);
            await Save();
        }

        public async Task<Book> Delete(int id)
        {
            var d =await GetById(id);
            if(d!= null)  
            _dbContext.Books.Remove(d);
            await Save();
            return d;
        }

        public async Task<bool> IsExsit(int id)
        {
            var bol =await _dbContext.Books.AnyAsync(e => e.Id == id);
            return bol;
            //if (await GetById(id) != null) 
            //    return true;
            //return false;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Book> Update(Book? book)
        {
         
            _dbContext.Entry(book).State=EntityState.Modified;
            try
            {
                await Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if ( !IsExsit(book.Id).Result)
                    return null;
                else

                throw;
            }
           
            return book;
        }
    }
}
