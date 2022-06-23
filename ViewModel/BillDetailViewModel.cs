using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BillDetailViewModel
    {
        public string Name { get; set; }
        public List<ProductAdminViewModel> Product { get; set; }
        public string address { get; set; }
        public string phonenumber { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
