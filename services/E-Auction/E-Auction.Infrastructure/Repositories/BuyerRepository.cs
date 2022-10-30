﻿using E_Auction.Domain.Interfaces;
using E_Auction.Domain.Models;
using E_Auction.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Auction.Infrastructure.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly EAuctionContext _eAuctionContext;
        private readonly IMessageProducer _publishEndpoint;


        public BuyerRepository(EAuctionContext eAuctionContext, IMessageProducer publishEndpoint)
        {
            _eAuctionContext = eAuctionContext ?? throw new NullReferenceException();
            _publishEndpoint = publishEndpoint;

        }
        public async Task PlaceBid(Buyer buyer)
        {
            _eAuctionContext.Buyers.Add(buyer);
            await _eAuctionContext.SaveChangesAsync();
        }
        public async Task UpdateBid(Buyer buyer)
        {
            _eAuctionContext.Buyers.Update(buyer);
            await _eAuctionContext.SaveChangesAsync();
        }

        public void SendMessage<T>(T buyer)
        {
            _publishEndpoint.SendMessage(buyer);
        }

        

        public Buyer GetBuyerByEmailIdAndProductId(int productId, string emailId)
        {
            return _eAuctionContext.Buyers.Where(x=>x.ProductId == productId && x.Email == emailId).FirstOrDefault();
        }

        public List<Buyer> GetBuyers()
        {
            return _eAuctionContext.Buyers.ToList();
        }
    }
}
