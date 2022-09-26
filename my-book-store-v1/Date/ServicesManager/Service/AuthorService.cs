using Microsoft.EntityFrameworkCore;

using my_book_store_v1.Date.Dto;
using my_book_store_v1.Date.Models;
using my_book_store_v1.Date.ServicesManager.Interface;

namespace my_book_store_v1.Date.ServicesManager.Service
{
    public class AuthorService : IAuthor
    {
        #region DI context
        private readonly AppDbContext _DbContext;
        public AuthorService(AppDbContext appDbContext)
        {
            _DbContext = appDbContext;
        }
        #endregion

        public async Task<IEnumerable<Author>> GetAuthorsAsync() => await _DbContext.Authors.ToListAsync();
 
        public async Task<Author> GetAuthorByNameAsync(string name) => await _DbContext.Authors.FirstOrDefaultAsync(b => b.Name == name);
        public async Task<Author> AddAuthorAsync(AuthorDto authorDto)
        {
            Author author = new Author
            {
                Name = authorDto.FullName
            };
            await _DbContext.Authors.AddAsync(author);
         
            return author;
        }
        public async Task<Author> UpdateAuthorAsync(AuthorDto authorDto, int id)
        {
            Author item = await GetAuthorByIdAsync(id);
            if (item == null) return null;

            if (item.Id == id)
            {
                item.Name = authorDto.FullName;
                return item;
            }
            return null;

        }
        public async Task<Author> DeleteAuthorAsync(int id)
        {
            Author re = await GetAuthorByIdAsync(id);
            if (re == null)
                return null;
            _DbContext.Remove(re);
            return re;
        }
        public async Task SaveAsync() => await _DbContext.SaveChangesAsync();

        public async Task<bool> IsExistsAsync(int id)
        {
            //var item = await _DbContext.Authors.FirstOrDefaultAsync(b => b.Id == id);
            //if (item == null)
            //    return false;
            //return true;
            return await _DbContext.Authors.AnyAsync(a=>a.Id==id)?true:false;
        }
        public async  Task<AuthorWithBooksDto> GetAuthorWithBooksDtoByIdAsync(int id)
        {
            var item = await _DbContext.Authors.Where(x => x.Id == id).Select(x => new AuthorWithBooksDto
            {
                AuthorName = x.Name,
                Books = x.Book_Authors.Select(x => x.Books.Title).ToList(),
            }).FirstOrDefaultAsync();

            return item;
        }
        public async Task<Author> GetAuthorByIdAsync(int id)=> await _DbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
    }
}

