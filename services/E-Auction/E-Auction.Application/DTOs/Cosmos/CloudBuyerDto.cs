using System.ComponentModel.DataAnnotations;

namespace E_Auction.Application.DTOs.Cosmos
{
    public class CloudBuyerDto
    {
        
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 5)]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pin { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10)]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int ProductId { get; set; }
        public decimal BidAmount { get; set; }
    }
}
