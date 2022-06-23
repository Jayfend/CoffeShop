using CoffeShopDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services
{
    public  class ProductService
    {
        private CoffeShopDbContext _Database = null;
        public ProductService()
        {
            _Database = new CoffeShopDbContext();
        }
        public bool AddProductToDb(ProductViewModel product)
        {

            var check = _Database.Products.FirstOrDefault(s => s.ProductId == product.ProductId);
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
        public List<ProductViewModel> GetProductViewModel(int categoryID)
        {

            return _Database.Products.Where(x => x.ProductCategoryId == categoryID).Select(x => new ProductViewModel()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductCategoryId = x.ProductCategoryId,
                Price = x.Price,
                Discount = x.Discount,
                Description = x.Description,
                Image = x.Image
            }).ToList();

        }
        public List<ProductViewModel> GetProduct()
        {

            return _Database.Products.Select(x => new ProductViewModel()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductCategoryId = x.ProductCategoryId,
                Price = x.Price,
                Discount = x.Discount,
                Description = x.Description,
                Image = x.Image
            }).ToList();

        }
        public List<ProductViewModel> GetProductViewModelSpecial()
        {

            return _Database.Products.OrderByDescending(x => x.CreatedDate).Select(x => new ProductViewModel()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductCategoryId = x.ProductCategoryId,
                Price = x.Price,
                Discount = x.Discount,
                Description = x.Description,
                Image = x.Image
            }).ToList();

        }
        public List<HotProductViewModel> GetHotProduct() {


            return _Database.Products.Select(x => new HotProductViewModel()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductCategoryId = x.ProductCategoryId,
                Price = x.Price,
                Discount = x.Discount,
                Description = x.Description,
                Image = x.Image,
            }).ToList();


        }
        public bool DeleteProduct(int ProductId)
        {
            var Product = _Database.Products.FirstOrDefault(s => s.ProductId==ProductId);
            if (Product != null)
            {
                _Database.Products.Remove(Product);
                _Database.SaveChanges();
                return true; ;
            }
            else
            {
                return false;
            }
        }
        public int BuyCount(int ProductID)
        {
            int amount = 0;
            BillService billService = new BillService();
            var ListBill = billService.GetBill();
            foreach(var item in ListBill)
            {
                var orderitems = _Database.OrderItems.Where(s => s.OrderId == item.OrderId && s.ProductId == ProductID).FirstOrDefault();
                if(orderitems != null)
                {
                    amount+= orderitems.Quantity;
                }
            }
            return amount;
        }
    }
}
