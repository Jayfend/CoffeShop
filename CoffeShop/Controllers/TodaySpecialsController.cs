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
            ViewBag.TodaySpecials = "active";
            return View();
        }
    }
}