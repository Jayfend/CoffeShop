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
            ViewBag.IsLogin = true;

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
                    ViewBag.IsLogin = true;
                    return RedirectToAction("Index");
                    
                }
                else
                {   
                    ModelState.AddModelError(string.Empty,"Username or Email already existed");
                    ViewBag.IsLogin = false;
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
            { var response = login.UserLogin(account);
                if (response!=null)
                {
                    var identity = new ClaimsIdentity(
                     new[] {
                    new Claim(ClaimTypes.Name, response.UserName),
                    new Claim(ClaimTypes.NameIdentifier, response.AccountID.ToString()),
                    new Claim(ClaimTypes.Role,response.UserType)
                  
                    
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