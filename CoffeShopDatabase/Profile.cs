using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShopDatabase
{
    public class Profile
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
       
        public byte[] Image { get; set; }
       
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }

    }
}
