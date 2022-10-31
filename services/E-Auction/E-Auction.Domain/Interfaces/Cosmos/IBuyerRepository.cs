using E_Auction.Domain.Models.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Auction.Domain.Interfaces.Cosmos
{
    public interface IBuyerRepository
    {
        public Task PlaceBid(Buyer buyer);
        public Task UpdateBid(Buyer buyer);
        public Buyer GetBuyerByEmailIdAndProductId(string emailId);
        //public void SendMessage<T>(T message);
        
        public List<Buyer> GetBuyers();
    }
}
