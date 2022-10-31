using E_Auction.Domain.Interfaces.Cosmos;
using E_Auction.Domain.Models.Cosmos;
using E_Auction.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Auction.Infrastructure.Repositories.Cosmos
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly CosmosContext _cosmosContext;


        public BuyerRepository(CosmosContext cosmosContext)
        {
            _cosmosContext = cosmosContext ?? throw new NullReferenceException();

        }
        public async Task PlaceBid(Buyer buyer)
        {
            _cosmosContext.Buyers.Add(buyer);
            await _cosmosContext.SaveChangesAsync();
        }
        public async Task UpdateBid(Buyer buyer)
        {
            _cosmosContext.Buyers.Update(buyer);
            await _cosmosContext.SaveChangesAsync();
        }

        //public void SendMessage<T>(T buyer)
        //{
        //    _publishEndpoint.SendMessage(buyer);
        //}

        

        public Buyer GetBuyerByEmailIdAndProductId(int productId, string emailId)
        {
            return _cosmosContext.Buyers.Where(x=>x.Email == emailId).FirstOrDefault();
        }

        public List<Buyer> GetBuyers()
        {
            return _cosmosContext.Buyers.ToList();
        }
    }
}
