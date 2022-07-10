using E_Auction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Domain.Interfaces
{
    public interface ISellerRepository
    {
        public Task AddProduct(Product product);
        public Task AddSeller(Seller seller);
        public Task DeleteProduct(Product product);
        public IEnumerable<Buyer> GetBidsByProductId(int productId);
        public Seller GetSellerByEmailId(string emailId);
        Product GetProductById(int productId);

        Task<Product> GetBidsWithProductById(int productId);
    }
}
