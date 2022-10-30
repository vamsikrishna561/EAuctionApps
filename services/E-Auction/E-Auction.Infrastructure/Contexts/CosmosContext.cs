using E_Auction.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Auction.Infrastructure.Contexts
{
    public class CosmosContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasNoDiscriminator()
                .ToContainer("Product");
            modelBuilder.Entity<Buyer>()
                .HasNoDiscriminator()
                .ToContainer("Buyer");
            modelBuilder.Entity<Seller>()
                .HasNoDiscriminator()
                .ToContainer("Seller");
            modelBuilder.Entity<Category>()
                .HasNoDiscriminator()
                .ToContainer("Category")
                .HasData(new Category { Id = 1, CategoryName = "Painting" },
                new Category { Id = 2, CategoryName = "Sculptor" },
                new Category { Id = 3, CategoryName = "Ornament" });
        }
    }
}
