using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Domain.Models.Cosmos
{
    public class Category
    {        
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
