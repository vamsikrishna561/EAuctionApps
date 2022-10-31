using E_Auction.Domain.Interfaces.Cosmos;
using E_Auction.Domain.Models.Cosmos;
using E_Auction.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Auction.Infrastructure.Repositories.Cosmos
{
    public class SellerRepository : ISellerRepository
    {
        private readonly CosmosContext _cosmosContext;
        //private readonly IMessageProducer _publishEndpoint;
        public SellerRepository(CosmosContext cosmosContext)
        {
            _cosmosContext = cosmosContext ?? throw new NullReferenceException();
            //_publishEndpoint = publishEndpoint;
        }

        public async Task AddProduct(Product product)
        {
            _cosmosContext.Products.Add(product);
            await _cosmosContext.SaveChangesAsync();
        }

        public async Task AddSeller(Seller seller)
        {
            if (GetSellerByEmailId(seller.Email) == null)
            {
                _cosmosContext.Sellers.Add(seller);
                await _cosmosContext.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(Product product)
        {
            _cosmosContext.Products.Remove(product);
            await _cosmosContext.SaveChangesAsync();            
        }

        public IEnumerable<Buyer> GetBidsByProductId(int productId)
        {
            return _cosmosContext.Buyers
                //.Where(x=>x.ProductId == productId)
                .ToList();
        }

        public Seller GetSellerByEmailId(string emailId)
        {
            return _cosmosContext.Sellers.Where(x => x.Email == emailId).FirstOrDefault();
        }
        public Product GetProductById(int productId)
        {
            return _cosmosContext.Products.Where(x=>x.Id == productId).FirstOrDefault();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _cosmosContext.Products
                //.Include(x=>x.Seller)
                //.Include(y=>y.Category)
                //.Include(y => y.Buyers)
                .ToListAsync();
        }

        //public T GetMessage<T>()
        //{
        //    return _publishEndpoint.GetMessage<T>();
        //}

        public async Task<Product> GetBidsWithProductById(int productId)
        {
            return await _cosmosContext.Products.Where(x => x.Id == productId)
                //.Include(y => y.Buyers)
                .FirstOrDefaultAsync();
        }
    }
}
