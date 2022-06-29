using CoffeShopDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services
{
   
    public  class CartService
    {
        private CoffeShopDbContext _Database = null;
        public CartService()
        {
            _Database = new CoffeShopDbContext();
        }
        public bool UpdateCart(int productid, int AccountId)
        {

            var getorder = _Database.Orders.FirstOrDefault(s => s.AccountID == AccountId && s.Status == "Pending");
            if (getorder != null)
            {
                var check = _Database.OrderItems.FirstOrDefault(s => s.OrderId == getorder.OrderId && s.ProductId == productid);
                if (check != null)
                {
                    check.Quantity += 1;
                    _Database.SaveChanges();
                    return true;
                }
                else
                {
                    OrderItem orderItem = new OrderItem()
                    {
                        Order = getorder,
                        ProductId = productid,
                        Quantity = 1,



                    };
                    _Database.OrderItems.Add(orderItem);
                    _Database.SaveChanges();
                    return true;
                }
            }
            else
            {
                Order newOder = new Order()
                {
                    AccountID = AccountId,
                    Status = "Pending",


                };

                OrderItem orderItem = new OrderItem()
                {
                    Order = newOder,
                    ProductId = productid,
                    Quantity = 1,



                };
                _Database.OrderItems.Add(orderItem);
                _Database.SaveChanges();
                return true;

            }

        }
        public bool Checkoutupdate(List<CheckOutViewModel> listitem)
        {
            
            if (listitem.Count > 0 )
            {
                foreach (var item in listitem)
                {
                    var orderitem = _Database.OrderItems.FirstOrDefault(s => s.OrderItemId == item.OrderItemId && s.Quantity != item.Quantity);
                    if (orderitem != null)
                    {
                        if (item.Quantity > 0)
                        {
                            orderitem.Quantity = item.Quantity;
                            
                            
                        }
                        else if (item.Quantity <= 0)
                        {
                            _Database.OrderItems.Remove(orderitem);
                            
                         
                        }
                    }
                    
                }
                _Database.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<OrderItemResponse> GetCart(int AccountId)
        {
            var orderitems = _Database.OrderItems.Where(s => s.Order.Status == "Pending" && s.Order.AccountID == AccountId)
                 .Select(s => new OrderItemResponse()
                 {
                     ProductName = s.Product.ProductName,
                     ProductCategoryID = s.Product.ProductCategoryId,
                     img=s.Product.Image,
                    Price=s.Product.Price,
                    Quantity=s.Quantity,
                    OrderItemId=s.OrderItemId,
                    Discount =s.Product.Discount
                 })
               .ToList();
            return orderitems;
        }
        public bool DeleteCartItem(int OrderItemId,int AccountId)
        {
            var orderitem = _Database.OrderItems.FirstOrDefault(s => s.OrderItemId == OrderItemId && s.Order.AccountID==AccountId);
            if(orderitem != null)
            {
                _Database.OrderItems.Remove(orderitem);
                _Database.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
}
