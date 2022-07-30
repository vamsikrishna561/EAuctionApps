using E_Auction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Domain.Interfaces
{
    public interface IBuyerRepository
    {
        public Task PlaceBid(Buyer buyer);
        public Task UpdateBid(Buyer buyer);
        public Buyer GetBuyerByEmailIdAndProductId(int productId, string emailId);
        public void SendMessage<T>(T message);
        
        public List<Buyer> GetBuyers();
    }
}
