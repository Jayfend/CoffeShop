using CoffeShopDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services
{
    public class GetProductSpecial
    {
        private CoffeShopDbContext _Database = null;
        public GetProductSpecial()
        {

            _Database = new CoffeShopDbContext();
        }
        public List<ProductViewModel> GetProductViewModel()
        {

            return _Database.Products.OrderByDescending(x=>x.CreatedDate).Select(x => new ProductViewModel()
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
    }
}
