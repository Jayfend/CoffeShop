using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CoffeShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TableController : Controller
    {
        // GET: Admin/Table
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

                //Filter specific claim    
                var AccountID = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier, StringComparison.OrdinalIgnoreCase))?.Value;

                Services.Login LoginService = new Services.Login();
                ViewBag.avatar = LoginService.GetAvatar(int.Parse(AccountID));
                //ViewBag.CartCount = ViewBag.Cart.Count; 
            }
            ProductService productService = new ProductService();
            var ListHotProduct = productService.GetHotProduct();
            foreach(var item in ListHotProduct)
            {
                item.Amount = productService.BuyCount(item.ProductId);
            }
            ViewBag.HotProduct = ListHotProduct;
            ReviewService reviewService = new ReviewService();
            ViewBag.Reviews = reviewService.getReviews();
            BillService billservice = new BillService();
            Login Login = new Login();
            var billlist = billservice.GetBill();
            ViewBag.BillDetail = billservice.GetProductOfBill();
            ViewBag.Table = "active";
            ViewBag.AccountList = Login.getinfo();
            return View(billlist);
        }
    }
}