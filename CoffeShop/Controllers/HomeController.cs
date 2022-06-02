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
       
        public ActionResult Index()
        {  
                ViewBag.Home = "active";
                return View();
            
            
        }
     



    }
}