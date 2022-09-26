
using my_book_store_v1.Date.Dto;
using my_book_store_v1.Date.Models;

namespace my_book_store_v1.Date.ServicesManager.Interface
{
    public interface IAuthor
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
       
        Task<AuthorWithBooksDto> GetAuthorWithBooksDtoByIdAsync(int id);
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> GetAuthorByNameAsync(string name);
        Task<Author> AddAuthorAsync(AuthorDto AuthorDto);
        Task<Author> DeleteAuthorAsync(int id);
        Task<Author> UpdateAuthorAsync(AuthorDto AuthorDto,int id);
        Task<bool> IsExistsAsync(int id);
        Task SaveAsync();

    }
}
