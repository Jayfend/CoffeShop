using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CoffeShopDatabase
{
       
    public class Profile
    {

        [Key]
        public int UserId { get; set; }
         
        public string FullName { get; set; }
        
      
        public string Address { get; set; }
      
        public string PhoneNumber { get; set; }
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }

    }
}
