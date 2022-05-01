using Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
            GetProductSpecial getproductspecial = new GetProductSpecial();
            var ProductList = getproductspecial.GetProductViewModel();
            var firstsixitems= ProductList.Take(6).ToList();
            ViewBag.TodaySpecials = "active";
            return View(firstsixitems);
        }
    }
}