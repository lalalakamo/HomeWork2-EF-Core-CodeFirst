using Microsoft.EntityFrameworkCore;

namespace HomeWork2_EF_Core_CodeFirst.Models
{
    public class WebContext : DbContext
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Id).IsRequired()
                .HasDefaultValueSql("NEWID()");
                entity.Property(e => e.Title).IsRequired()
                .HasMaxLength(100);
                entity.Property(e => e.Author).IsRequired();
                entity.Property(e => e.PublishDate).HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
