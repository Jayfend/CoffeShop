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
            var getorder = _Database.Orders.FirstOrDefault(s => s.AccountID == AccountID && s.Status == "Pending");
            if (getorder != null)
            {

                if (bill.TotalPrice > 0)
                {
                    getorder.Status = "Paid";
                    Bill newBill = new Bill()
                    {   Name= bill.Name,
                        TotalPrice = bill.TotalPrice,
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
    }
}
