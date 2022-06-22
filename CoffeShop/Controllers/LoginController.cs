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

            var login = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            var signup = new SignupViewModel
            {
                ReturnUrl = returnUrl
            };
            var account = new AccountViewModel
            {
                LoginModel = login,
                SignupModel = signup
            };
            return View(account);
          
        }
        
        [HttpPost]
        public ActionResult Register(SignupViewModel account)
        {   SignUp signup = new SignUp();
            if (ModelState.IsValid)
            {
                if (signup.Register(account))
                {
                    
                    return Json(new { result = true }, JsonRequestBehavior.AllowGet);

                }
                else
                {   
                    ViewBag.IsLogin = false;
                    return Json(new { result = false }, JsonRequestBehavior.AllowGet);

                }
               
            }
            return View();
        }
       
        [HttpPost]
        public ActionResult Login(LoginViewModel account)
        {
            Login login =  new Login();
            if (!ModelState.IsValid)
            {
                return Json(new { result = false, message="This account is valid !" }, JsonRequestBehavior.AllowGet);
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
                    return Json(new { result = true, message = GetRedirectUrl(account.ReturnUrl) }, JsonRequestBehavior.AllowGet);
                    

                }
                else
                {
                    return Json(new { result = false, message ="User name or password is not correct" }, JsonRequestBehavior.AllowGet);

                }
            }
            
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