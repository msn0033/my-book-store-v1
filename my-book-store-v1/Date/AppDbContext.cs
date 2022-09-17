using Microsoft.EntityFrameworkCore;
using my_book_store_v1.Date.Models;

namespace my_book_store_v1.Date
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext):base(dbContext)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
