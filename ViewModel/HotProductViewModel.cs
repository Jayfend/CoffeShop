using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public class HotProductViewModel
    {
        
        public int ProductId { get; set; }
      
        public string ProductName { get; set; }
       
        public int ProductCategoryId { get; set; }
        public double Price { get; set; }
       
        public double Discount { get; set; }
       
        public string Description { get; set; }

        public byte[] Image { get; set; }

        public DateTime CreatedDate { get; set; }
        public int Amount { get; set; }

    }
}
