using E_Auction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Application.Interfaces
{
    public interface IBuyerRepository
    {
        public Task AddBid(Buyer buyer);
        public Task UpdateBid(Buyer buyer);
    }
}
