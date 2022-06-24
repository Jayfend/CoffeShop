using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CoffeShop.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
       
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

                //Filter specific claim    
                var AccountID = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier, StringComparison.OrdinalIgnoreCase))?.Value;
                Services.Login LoginService = new Services.Login();
                ViewBag.avatar = LoginService.GetAvatar(int.Parse(AccountID));
              
            }
            ProductService productService = new ProductService();
            var ListHotProduct = productService.GetHotProduct();
            foreach (var item in ListHotProduct)
            {
                item.Amount = productService.BuyCount(item.ProductId);
            }
            ViewBag.HotProducts= ListHotProduct.OrderByDescending(s => s.Amount).Take(3);
            var ProductList = productService.GetProductViewModelSpecial();
            var firstthreeitems = ProductList.Take(4).ToList();
            ViewBag.Home = "active";
            ViewBag.firstSpecialProduct = firstthreeitems.FirstOrDefault();
            ViewBag.secondSpecialProduct = firstthreeitems.ElementAt(1);
            ViewBag.thirdSpecialProduct = firstthreeitems.ElementAt(2);
            ViewBag.fourthSpecialProduct = firstthreeitems.ElementAt(3);
            return View();
        }
     



    }
}