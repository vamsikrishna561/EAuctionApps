using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Domain.DTOs
{
    public class CategoryDto
    {        
        public int Id { get; set; }
        public string CategoryName { get; set; }
        
    }
}
