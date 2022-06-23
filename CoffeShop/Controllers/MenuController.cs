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
        public ActionResult Index(int categoryId = 1)
        {
            ProductService getproduct = new ProductService();
            ViewBag.Menu = "active";
            var ProductList = getproduct.GetProductViewModel(categoryId);
            return View(ProductList);
        }
        [Authorize]
        public ActionResult UpdateToCart(int ProductId)
        {
           
                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

                //Filter specific claim    
                var AccountID = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier, StringComparison.OrdinalIgnoreCase))?.Value;
                CartService updatetocart = new CartService();
                
                updatetocart.UpdateCart(ProductId, int.Parse(AccountID));
                
                    ViewBag.Cart = updatetocart.GetCart(int.Parse(AccountID));

            return PartialView("_Cart");
            
        }


        //First get user claims    

    }
       
    
}