using Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using ViewModel;

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
                //ViewBag.CartCount = ViewBag.Cart.Count; 
            }
            else
            {
                ViewBag.Cart = new List<OrderItemResponse>();
                
                //ViewBag.CartCount = 0;
            }
            
        }
        [Authorize]
        public ActionResult DeleteItem(int OrderItemId)
        {
            
            var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

            //Filter specific claim    
            var AccountID = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier, StringComparison.OrdinalIgnoreCase))?.Value;
            CartService cartService = new CartService();
            
                ViewBag.Cart = cartService.GetCart(int.Parse(AccountID));
                return PartialView("_Cart");
               
            

           
        }
        public virtual ActionResult Change(String LanguageAbbrevation)
        {
            if (!string.IsNullOrEmpty(LanguageAbbrevation))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);
            }

            HttpCookie cookie = new HttpCookie(name: "Languages");
            cookie.Value = LanguageAbbrevation;
            Response.Cookies.Add(cookie);
            return Json(new { result = true }, JsonRequestBehavior.AllowGet);

        }

    }
}