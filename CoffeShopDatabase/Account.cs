using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShopDatabase
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        [Required]
        [MaxLength(40)]
        public string UserType { get; set; }
        [Required]
        [MaxLength(40)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
        [Required]
        [MaxLength(255)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
        
    
    }
}
