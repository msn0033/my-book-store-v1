using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace my_book_store_v1.Date.Repository
{
    public class RepositoryService<T> : IRepository<T> where T : class
    {
        #region ID
        private readonly AppDbContext _context;//db
        private readonly DbSet<T> _table ;//table
        public RepositoryService( AppDbContext context)
        {
            _context = context;
            _table=_context.Set<T>();
        }
        #endregion
        public async Task Add(T Entity)
        {
           await _table.AddAsync(Entity);
        }

   

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetById(int? id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<bool> IsExsit(int id)
        {
           if(await GetById(id) !=null)
            return true;
            return false;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

     

        Task<T> IRepository<T>.Delete(int Id)
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository<T>.Update(T Entity)
        {
            throw new NotImplementedException();
        }
    }
}
