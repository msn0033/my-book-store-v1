using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace my_book_store_v1.Date.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int Id);
        Task<T> DeleteAsync(int Id);
         Task AddAsync(T Entity);
        T Update(T Entity);
        Task<bool> IsExsitAsync(int Id);
        Task SaveAsync();
       
        
        
    }
}
