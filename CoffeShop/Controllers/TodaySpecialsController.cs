using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeShop.Controllers
{
    public class TodaySpecialsController : Controller
    {
        // GET: TodaySpecials
        public ActionResult Index()
        {
            GetProductSpecial getproductspecial = new GetProductSpecial();
            var ProductList = getproductspecial.GetProductViewModel();
            ProductList.Sort((x, y) => DateTime.Compare(x.CreatedDate, y.CreatedDate));
            var firstsixitems= ProductList.Take(6).ToList();
            ViewBag.TodaySpecials = "active";
            return View(firstsixitems);
        }
    }
}