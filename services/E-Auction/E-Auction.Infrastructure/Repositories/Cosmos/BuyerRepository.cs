using E_Auction.Domain.Interfaces;
using E_Auction.Domain.Models;
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
        private readonly IMessageProducer _publishEndpoint;


        public BuyerRepository(CosmosContext cosmosContext, IMessageProducer publishEndpoint)
        {
            _cosmosContext = cosmosContext ?? throw new NullReferenceException();
            _publishEndpoint = publishEndpoint;

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

        public void SendMessage<T>(T buyer)
        {
            _publishEndpoint.SendMessage(buyer);
        }

        

        public Buyer GetBuyerByEmailIdAndProductId(int productId, string emailId)
        {
            return _cosmosContext.Buyers.Where(x=>x.ProductId == productId && x.Email == emailId).FirstOrDefault();
        }

        public List<Buyer> GetBuyers()
        {
            return _cosmosContext.Buyers.ToList();
        }
    }
}
