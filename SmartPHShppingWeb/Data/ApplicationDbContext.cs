using Microsoft.EntityFrameworkCore;
using SmartPHShoppingWeb.Models;

namespace SmartPHShoppingWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Action", DisplayOrder=1},
                new Category { Id=2, Name="Sci-Fi", DisplayOrder=2},
                new Category { Id=3, Name="History", DisplayOrder=3}
                );

            modelBuilder.Entity<Product>().HasData(
                new Product 
                { 
                    Id= 1,
                    Name = "Stick",
                    Description = "A stainless steel stick to provide support while walking",
                    Manufacturer = "Singhai Internatioanl",
                    ListPrice = 600,
                    Price = 500,
                    CategoryId = 1,
                    ImageUrl = ""
                }
                );
        }
    }
}
