using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Application.DTOs
{
    public class ProductDto
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public int CategoryId { get; set; }
        public decimal StartingPrice { get; set; }
        public DateTime BidEndDate { get; set; } = DateTime.UtcNow;
        public CategoryDto Category { get; set; }
        public SellerDto Seller { get; set; }

        public virtual List<BuyerDto> Buyers { get; set; }
    }
}
