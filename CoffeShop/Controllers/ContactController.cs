using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeShop.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contact
        public ActionResult Index(string lang="")
        {
            if (!string.IsNullOrEmpty(lang))
            {
                Session["lang"] = lang;
                return RedirectToAction("Index", "Contact", new { language = lang });
            }
            @ViewBag.Contact = "active";
            return View();
        }
    }
}