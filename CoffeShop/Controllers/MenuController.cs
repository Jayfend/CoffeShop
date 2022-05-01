using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;


namespace CoffeShop.Controllers
{   [AllowAnonymous]
    public class MenuController : BaseController
    {
        // GET: Menu
        public ActionResult Index(int categoryID = 1)
        {  
            GetProduct getproduct = new GetProduct();
            ViewBag.Menu = "active";
            var ProductList = getproduct.GetProductViewModel(categoryID);
            return View(ProductList);
        }
        public ActionResult UpdateToCart(int ProductId)
        {
            if (User.Identity.IsAuthenticated)
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