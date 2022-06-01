using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeShop.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
       
        public ActionResult Index(string lang="")
        {   if(!string.IsNullOrEmpty(lang))
            {
                Session["lang"] = lang;
                return RedirectToAction("Index", "Home", new { language = lang });
            }
            else
            {
                ViewBag.Home = "active";
                return View();
            }
            
        }
       
       

    }
}