using CoffeShopDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services
{
    public class BillService
    {
        private CoffeShopDbContext _Database = null;
        public BillService()
        {
            _Database = new CoffeShopDbContext();
        }
        public bool CreateBill(BillViewModel bill,int AccountID)
        {
            double Total = 0;
            var getorder = _Database.Orders.FirstOrDefault(s => s.AccountID == AccountID && s.Status == "Pending");
            if (getorder != null)
            {
                CartService cartService = new CartService();
                var orderitems = cartService.GetCart(AccountID);
                foreach(var item in orderitems)
                {
                    Total += ((item.Price)-(item.Price*item.Discount/100))*item.Quantity;
                }

                if (Total > 0)
                {
                    getorder.Status = "Paid";
                    Bill newBill = new Bill()
                    {   Name= bill.Name,
                        TotalPrice = Total,
                        Order = getorder,
                        Purchasedate = DateTime.Now,
                        PhoneNumber = bill.PhoneNumber,
                        Address = bill.Address,
                       

                    };
                    Order neworder = new Order()
                    {
                        AccountID= AccountID,
                        Status = "Pending"
                    };
                    _Database.Orders.Add(neworder); 
                    _Database.Bills.Add(newBill);
                    _Database.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        public List<BillAdminViewModel> GetBill()
        {
            return _Database.Bills.Select(x => new BillAdminViewModel()
            {
                BillID = x.BillID,
                Address = x.Address,
                PhoneNumber = x.PhoneNumber,
                Name = x.Name,
                TotalPrice= x.TotalPrice,
                Purchasedate= DateTime.Now,
                OrderId = x.OrderId,
            }).ToList();
        }
       public List<BillDetailViewModel> GetProductOfBill()
        {       List<BillDetailViewModel> result = new List<BillDetailViewModel>();
            var listBill = GetBill();
            foreach(var item in listBill)
            {
                BillDetailViewModel billdetail = new BillDetailViewModel();
                billdetail.address = item.Address;
                billdetail.phonenumber = item.PhoneNumber;
                billdetail.Name = item.Name;
                billdetail.CreatedDate = item.Purchasedate;
                billdetail.Product = _Database.OrderItems.Where(s => s.OrderId == item.OrderId)
                    .Select(s => new ProductAdminViewModel()
                    {   
          
                        quantity = s.Quantity,
                        ProductName = s.Product.ProductName
                        
                    }).ToList();
                result.Add(billdetail);
            }
            return result;
            
        }
    }
}
