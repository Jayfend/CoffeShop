using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace CoffeShop.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

                //Filter specific claim    
                var AccountID = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier, StringComparison.OrdinalIgnoreCase))?.Value;
                CartService cartService = new CartService();
                ViewBag.Cart = cartService.GetCart(int.Parse(AccountID));
                Services.Login LoginService = new Services.Login();
                ViewBag.avatar = LoginService.GetAvatar(int.Parse(AccountID));
                //ViewBag.CartCount = ViewBag.Cart.Count; 
            }
            else
            {
                ViewBag.Cart = new List<OrderItemResponse>();

                //ViewBag.CartCount = 0;
            }
            ViewBag.bill = true;
            return View();
        }
    }
}