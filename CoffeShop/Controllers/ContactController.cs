using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace CoffeShop.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contact
        public ActionResult Index()
        {
          
            @ViewBag.Contact = "active";
            return View();
        }
        [HttpPost]
        public JsonResult Reviews(ContactViewModel review)
        {
            if (ModelState.IsValid)
            {
                ReviewService reviewservice = new ReviewService();
                if (reviewservice.ReceiveReview(review))
                {
                    return new JsonResult()
                    {
                        Data = new
                        {
                            Result = true,
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
                        
                    }
                };
            }
        }
    }
}