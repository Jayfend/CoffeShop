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
    public class CartController : BaseController
    {
        // GET: Cart
        public ActionResult Index()
        {
         
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

                //Filter specific claim    
                var AccountID = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier, StringComparison.OrdinalIgnoreCase))?.Value;
                CartService cartService = new CartService();
                ViewBag.Cart = cartService.GetCart(int.Parse(AccountID));
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public ActionResult UpdatetoOrderItem(List<CheckOutViewModel> checkout)
        {   
            CartService cartService = new CartService();
            if (ModelState.IsValid)
            {
                if (cartService.Checkoutupdate(checkout))
                {
                    return new JsonResult() { 
                        Data = new
                        {
                            Result = true,
                            ReturnURL = "/Payment"
                        }
                    };
                }
                else
                {
                    return new JsonResult()
                    {
                        Data = new
                        {
                            Result = false,
                            ReturnURL = ""
                        }
                    };
                }
            }
            else
            {
                return new JsonResult()
                {
                    Data = new
                    {
                        Result = false,
                        ReturnURL = ""
                    }
                };
            }
                    
        }
        public ActionResult Save(List<CheckOutViewModel> checkout)
        {
            CartService cartService = new CartService();
            if (ModelState.IsValid)
            {
                if (cartService.Checkoutupdate(checkout))
                {
                    return new JsonResult()
                    {
                        Data = new
                        {
                            Result = true,
                            Message = "Save Successfully!"
                        }
                    };
                }
                else
                {
                    return new JsonResult()
                    {
                        Data = new
                        {
                            Result = false,
                            Message="Save Failed!"
                        }
                    };
                }
            }
            else
            {
                return new JsonResult()
                {
                    Data = new
                    {
                        Result = false,
                        Message = "Something went wrong!"
                    }
                };
            }
        }
    }
}