using my_book_store_v1.Data.Models;

namespace my_book_store_v1.Data
{
    public class AppDbInitializer
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //get db
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Publishers.Any())
                {
                    await context.Publishers.AddRangeAsync(
                        new Publisher {  Name = "دار الفكر" },
                        new Publisher {  Name = "دار التوحيد" },
                        new Publisher {  Name = "دار الحديث" }
                        );
                    await context.SaveChangesAsync();

                }
             
                if (!context.Books.Any())
                {
                    await context.Books.AddRangeAsync(
                        new Book()
                        {
                            Title = "First Book",
                            Description = "First Description",
                            CoverUrl = "",
                            DateAdded = DateTime.Now.AddDays(-8),
                            DateRead = DateTime.Now,
                            Genre = "Comady",
                            IsRead = true,
                            Rate = 7,
                            PublisherId = 1

                        },
                         new Book()
                         {
                             Title = "Second Book",
                             Description = "Second Description",
                             CoverUrl = "",
                             DateAdded = DateTime.Now.AddDays(-8),
                             Genre = "Action",
                             IsRead = false,
                             PublisherId = 2
                         }
                        );
                    await context.SaveChangesAsync();
                }

            }
        }
    }
}
