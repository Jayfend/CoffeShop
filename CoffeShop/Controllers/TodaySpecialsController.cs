using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CoffeShop.Controllers
{   [AllowAnonymous]
    public class TodaySpecialsController : BaseController
    {
        // GET: TodaySpecials
        [HttpGet]
        public ActionResult Index()
        {
            ProductService  productservice = new ProductService();
            var ProductList = productservice.GetProductViewModelSpecial();
            var firstsixitems= ProductList.Take(6).ToList();
            ViewBag.TodaySpecials = "active";
            return View(firstsixitems);
        }
        public ActionResult UpdateToCart(int ProductId)
        {
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

                //Filter specific claim    
                var AccountID = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier, StringComparison.OrdinalIgnoreCase))?.Value;
                CartService updatetocart = new CartService();
                ;
                if (updatetocart.UpdateCart(ProductId, int.Parse(AccountID)))
                {
                    return RedirectToAction("Index");
                }
            }
            //First get user claims    

            return View();
        }
    }
}