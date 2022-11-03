using Microsoft.EntityFrameworkCore;
using my_book_store_v1.Data.Models;

namespace my_book_store_v1.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext):base(dbContext)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }
        public DbSet<Seriloging> Serilogings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region m:m book & Author
            modelBuilder.Entity<Book_Author>().HasKey(b => new { b.BookId, b.AuthorId });
            modelBuilder.Entity<Book_Author>().HasOne(b => b.Books).WithMany(b => b.Book_Authors).HasForeignKey(b => b.BookId);
            modelBuilder.Entity<Book_Author>().HasOne(b => b.Authors).WithMany(b => b.Book_Authors).HasForeignKey(b => b.AuthorId);
            #endregion

        }

    }
}
