using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Domain.Models.Cosmos
{
    public class Seller
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
        public List<int> ProductIds { get; set; }
    }
}
