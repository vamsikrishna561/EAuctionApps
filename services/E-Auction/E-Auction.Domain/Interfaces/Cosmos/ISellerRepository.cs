using E_Auction.Domain.Models.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Auction.Domain.Interfaces.Cosmos
{
    public interface ISellerRepository
    {
        public Task AddProduct(Product product);
        public Task AddSeller(Seller seller);
        public Task DeleteProduct(Product product);
        public IEnumerable<Buyer> GetBidsByProductId(int productId);

        public Task<List<Product>> GetProducts();
        public Seller GetSellerByEmailId(string emailId);
        Product GetProductById(int productId);
        //public T GetMessage<T>();
        Task<Product> GetBidsWithProductById(int productId);
    }
}
