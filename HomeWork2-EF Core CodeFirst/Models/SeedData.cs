using  Microsoft.EntityFrameworkCore;

namespace HomeWork2_EF_Core_CodeFirst.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebContext(serviceProvider.GetRequiredService<DbContextOptions<WebContext>>()))
            {
                if (!context.Book.Any())
                {
                    context.Book.AddRange(
                        new Book { Title = "Book 1", Author = "Author 1", Price = 100 },
                        new Book { Title = "Book 2", Author = "Author 2", Price = 200 },
                        new Book { Title = "Book 3", Author = "Author 3", Price = 300 },
                        new Book { Title = "Book 4", Author = "Author 4", Price = 400 },
                        new Book { Title = "Book 5", Author = "Author 5", Price = 500 },
                        new Book { Title = "Book 6", Author = "Author 6", Price = 600 },
                        new Book { Title = "Book 7", Author = "Author 7", Price = 700 },
                        new Book { Title = "Book 8", Author = "Author 8", Price = 800 },
                        new Book { Title = "Book 9", Author = "Author 9", Price = 900 },
                        new Book { Title = "Book 10", Author = "Author 10", Price = 1000 }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
