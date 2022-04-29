using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ProductViewModel
    {   [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductCategoryId { get; set; }
        public double Price { get; set; }
        [Required]
        public double Discount { get; set; }
        [Required]
        public string Description { get; set; }
       
        public byte[] Image { get; set; }
       
        public DateTime CreatedDate { get; set; }

    }
}
