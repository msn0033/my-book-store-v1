using my_book_store_v1.Date.Models;

namespace my_book_store_v1.Date
{
    public class AppDbInitializer
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            using( var serviceScope=applicationBuilder.ApplicationServices.CreateScope())
            {
                //get db
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any())
                {
                    await context.Books.AddRangeAsync(
                        new Book() {
                            Title="First Book",
                            Description= "First Description",
                            CoverUrl="",
                            DateAdded=DateTime.Now.AddDays(-8),
                            DateRead=DateTime.Now,
                            Genre="Comady",
                            IsRead=true,
                            Rate=7

                        },
                         new Book()
                         {
                             Title = "Second Book",
                             Description = "Second Description",
                             CoverUrl = "",
                             DateAdded = DateTime.Now.AddDays(-8),
                             Genre = "Action",
                             IsRead = false,
                         }
                        );
                    await context.SaveChangesAsync();
                }
              
            }
        }
    }
}
