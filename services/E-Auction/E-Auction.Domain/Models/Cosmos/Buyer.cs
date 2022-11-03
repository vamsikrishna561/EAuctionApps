using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Auction.Domain.Models.Cosmos
{
    public class Buyer
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pin { get; set; }
        public string Phone { get; set; }
        [Key]
        public string Email { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BidAmount { get; set; }
        
    }
}
