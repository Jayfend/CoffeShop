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
        public int BillID { get; set; }

        public double TotalPrice { get; set; }

        public int OrderId { get; set; }


        public DateTime Purchasedate { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }
    }
}
