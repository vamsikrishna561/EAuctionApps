using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Domain.Models.Cosmos
{
    public class Product
    {
        
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public int CategoryId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal StartingPrice { get; set; }
        public DateTime BidEndDate { get; set; }
        
        public List<int> BuyerIds { get; set; }
    }
}
