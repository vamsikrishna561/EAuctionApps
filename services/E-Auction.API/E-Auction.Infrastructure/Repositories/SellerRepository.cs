using E_Auction.Domain.Interfaces;
using E_Auction.Domain.Models;
using E_Auction.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Infrastructure.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly EAuctionContext _eAuctionContext;
        public SellerRepository(EAuctionContext eAuctionContext)
        {
            _eAuctionContext = eAuctionContext ?? throw new NullReferenceException();
        }

        public async Task AddProduct(Product product)
        {
            this._eAuctionContext.Products.Add(product);
            await this._eAuctionContext.SaveChangesAsync();
        }

        public async Task AddSeller(Seller seller)
        {
            this._eAuctionContext.Sellers.Add(seller);
            await this._eAuctionContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            this._eAuctionContext.Remove(product);
            await this._eAuctionContext.SaveChangesAsync();
        }

        public IEnumerable<Buyer> GetBidsByProductId(int productId)
        {
            return this._eAuctionContext.Buyers.Where(x=>x.ProductId == productId).ToList();
        }

        public Seller GetSellerByEmailId(string emailId)
        {
            return this._eAuctionContext.Sellers.Where(x => x.Email == emailId).FirstOrDefault();
        }
    }
}
