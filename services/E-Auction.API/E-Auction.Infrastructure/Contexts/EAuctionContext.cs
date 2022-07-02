using E_Auction.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Infrastructure.Contexts
{
    public class EAuctionContext: DbContext
    {
        public EAuctionContext(DbContextOptions<EAuctionContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Category> Categories { get; set; }

        void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, CategoryName = "Painting" },
                new Category { Id = 2, CategoryName = "Sculptor" },
                new Category { Id = 3, CategoryName = "Ornament" });
        }
    }
}
