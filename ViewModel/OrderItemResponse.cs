using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public class OrderItemResponse
    {
        public string ProductName { get; set; }
        public double Price { get; set; }

        public byte[] img { get; set; }
        public int ProductCategoryID { get; set; }
        public int Quantity { get; set; }
        public int OrderItemId { get; set; }
        public double Discount { get; set; }
    }
}
