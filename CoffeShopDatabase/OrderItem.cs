using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShopDatabase
{
    public class OrderItem
    { 
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
