using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CoffeShop.Controllers
{   [AllowAnonymous]
    public class BaseController : Controller
    {   
        public BaseController()
        {
                
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated) {
                
                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

                //Filter specific claim    
                var AccountID = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier, StringComparison.OrdinalIgnoreCase))?.Value;
                CartService cartService = new CartService();
                ViewBag.Cart = cartService.GetCart(int.Parse(AccountID));
                ViewBag.CartCount = ViewBag.Cart.Count; 
            }
            else
            {
                ViewBag.Cart = null;
                ViewBag.CartCount = 0;
            }
            
        }
        public ActionResult DeleteItem(int OrderItemId)
        {
            var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

            //Filter specific claim    
            var AccountID = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier, StringComparison.OrdinalIgnoreCase))?.Value;
            CartService cartService = new CartService();
            if(cartService.DeleteCartItem(OrderItemId, int.Parse(AccountID)))
            {
                return RedirectToAction("Index","Menu");
            }
            
            return View();
        }
        
    }
}