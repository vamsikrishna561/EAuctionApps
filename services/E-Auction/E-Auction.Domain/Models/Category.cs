using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Domain.Models
{
    public class Category
    {        
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Product> products { get; set; }
    }
}
