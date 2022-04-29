using CoffeShopDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services
{
    public class AddProduct
    {
        private CoffeShopDbContext _Database = null;
        public AddProduct()
        {

            _Database = new CoffeShopDbContext();
        }
        public bool AddProductToDb(ProductViewModel product)
        {
            
            var check= _Database.Products.FirstOrDefault(s => s.ProductId==product.ProductId);
            if (check == null)
            {
                Product newproduct = new Product()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductCategoryId = product.ProductCategoryId,
                    Price = product.Price,
                    Discount = product.Discount,
                    Description = product.Description,
                    Image = product.Image,
                    CreatedDate = DateTime.Now,
                };
                _Database.Products.Add(newproduct);
                _Database.SaveChanges();
                return true;
            }
            else
            {
                var productchange = _Database.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                if (productchange != null)
                {
                    productchange.ProductName = product.ProductName;
                    productchange.ProductCategoryId = product.ProductCategoryId;
                    productchange.ProductId = product.ProductId;
                    productchange.Price = product.Price;
                    productchange.Discount = product.Discount;
                    productchange.Description = product.Description;
                    productchange.CreatedDate = DateTime.Now;
                    productchange.Image = product.Image;
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
}
