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
    public class PaymentController : BaseController
    {
        // GET: Payment
        public ActionResult Index()
        {
         
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

                //Filter specific claim    
                var AccountID = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier, StringComparison.OrdinalIgnoreCase))?.Value;
                CartService cartService = new CartService();
                ProfileService ProfileService = new ProfileService();
                ViewBag.FullName = ProfileService.GetFullName(int.Parse(AccountID));
                ViewBag.Address = ProfileService.GetAddress(int.Parse(AccountID));
                ViewBag.Phone = ProfileService.GetPhone(int.Parse(AccountID));

                ViewBag.Cart = cartService.GetCart(int.Parse(AccountID));
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }
        public ActionResult CreateBill(BillViewModel bill)
        {
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

                //Filter specific claim    
                var AccountID = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier, StringComparison.OrdinalIgnoreCase))?.Value;
                BillService billService = new BillService();
                if (ModelState.IsValid)
                {
                    if (billService.CreateBill(bill, int.Parse(AccountID))){
                        return new JsonResult()
                        {
                            Data = new
                            {
                                Result = true,
                                Message = " Thank you for buying, your order will be delivered soon!"
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
                            Message = "Something is wrong, please check the information "
                        }
                    };
                }

               
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }
    }
}