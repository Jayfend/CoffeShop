using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShopDatabase
{
    public class Order
    {   [Key]
        public int OrderId { get; set; }
        [Required]
        public int AccountID { get; set; }
        [ForeignKey("AccountID")]
        public Account Account { get; set; }
        [Required]
        [MaxLength(10)]
        public string Status { get; set; }
        
    }
}
