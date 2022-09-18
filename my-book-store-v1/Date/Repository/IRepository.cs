using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace my_book_store_v1.Date.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int? Id);
        Task<T> Delete(int Id);
         Task Add(T Entity);
        Task<T> Update(T Entity);
        Task<bool> IsExsit(int Id);
        Task Save();
       
        
        
    }
}
