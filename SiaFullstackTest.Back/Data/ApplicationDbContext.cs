using Microsoft.EntityFrameworkCore;
using SiaFullstackTest.Back.Data.Entities;

namespace SiaFullstackTest.Back.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity(j => j.ToTable("ProductCategory"));
        }
    }
}
