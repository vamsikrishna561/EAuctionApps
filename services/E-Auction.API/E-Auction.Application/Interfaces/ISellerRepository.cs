using E_Auction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Application.Interfaces
{
    public interface ISellerRepository
    {
        public Task AddProduct(Product product);
        public Task AddSeller(Seller seller);
        public Task DeleteProduct(Product product);
        public IEnumerable<Buyer> GetBidsByProductId(int productId);
    }
}
