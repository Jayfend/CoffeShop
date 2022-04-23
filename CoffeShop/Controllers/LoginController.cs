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
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
       
        [HttpGet]
        public ActionResult Index(string returnUrl)
        {
            var account = new AccountViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(account);
          
        }
        
        [HttpPost]
        public ActionResult Register(AccountViewModel account)
        {   SignUp signup = new SignUp();
            if (ModelState.IsValid)
            {
                if (signup.Register(account))
                {
                    return RedirectToAction("Index");
                    ViewBag.Success = "Register Successfully";
                }
                else
                {
                    ViewBag.error = "User name or Email already exist";
                    return View("Index");
                }
               
            }
            return View("Index");
        }
       
        [HttpPost]
        public ActionResult Login(AccountViewModel account)
        {
            Login login =  new Login();
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            if (ModelState.IsValid)
            {
                if (login.UserLogin(account))
                {
                    var identity = new ClaimsIdentity(
                     new[] {
                    new Claim(ClaimTypes.Name, account.UserName),
                  
                    
                    },
            "ApplicationCookie");
                    var ctx = Request.GetOwinContext();
                    var authManager = ctx.Authentication;

                    authManager.SignIn(identity);
                  
                    return Redirect(GetRedirectUrl(account.ReturnUrl));
                  
                }
              
            }
            
            ModelState.AddModelError("", "Invalid password");
            return View("Index");
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Login");
        }
    }
}