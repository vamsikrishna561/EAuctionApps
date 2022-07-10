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
    public class BuyerRepository : IBuyerRepository
    {
        private readonly EAuctionContext _eAuctionContext;
        public BuyerRepository(EAuctionContext eAuctionContext)
        {
            _eAuctionContext = eAuctionContext ?? throw new NullReferenceException();
        }
        public async Task PlaceBid(Buyer buyer)
        {
            this._eAuctionContext.Buyers.Add(buyer);
            await this._eAuctionContext.SaveChangesAsync();
        }
        public async Task UpdateBid(Buyer buyer)
        {
            this._eAuctionContext.Buyers.Update(buyer);
            await this._eAuctionContext.SaveChangesAsync();
        }

        public Buyer GetBuyerByEmailIdAndProductId(int productId, string emailId)
        {
            return this._eAuctionContext.Buyers.Where(x=>x.ProductId == productId && x.Email == emailId).FirstOrDefault();
        }
    }
}
