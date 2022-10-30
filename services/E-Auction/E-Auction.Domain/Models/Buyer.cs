﻿using System.ComponentModel.DataAnnotations.Schema;

namespace E_Auction.Domain.Models
{
    public class Buyer
    {
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pin { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BidAmount { get; set; }
        
        public virtual Product product { get; set; }
    }
}
