using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BillAdminViewModel
    {
        [Required]
        public int BillID { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public DateTime Purchasedate { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
