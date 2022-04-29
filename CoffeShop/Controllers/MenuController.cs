using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CoffeShop.Controllers
{   [AllowAnonymous]
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index(int categoryID = 1)
        {  
            GetProduct getproduct = new GetProduct();
            ViewBag.Menu = "active";
            var ProductList = getproduct.GetProductViewModel(categoryID);
            return View(ProductList);
        }
        
    }
}