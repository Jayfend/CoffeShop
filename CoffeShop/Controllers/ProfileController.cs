using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace CoffeShop.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        // GET: Profile
        public ActionResult Index()
        {
            ProfileViewModel profile = new ProfileViewModel();
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

                //Filter specific claim    
                var AccountID = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier, StringComparison.OrdinalIgnoreCase))?.Value;
                Services.Login LoginService = new Services.Login();
                ViewBag.avatar = LoginService.GetAvatar(int.Parse(AccountID));
                ViewBag.UserName = LoginService.GetUserName(int.Parse(AccountID));
                ViewBag.Email = LoginService.GetEmail(int.Parse(AccountID));
                ProfileService profileserivce = new ProfileService();
               
                profile = profileserivce.getProfile(int.Parse(AccountID));
                
            }
            ViewBag.Success = TempData["Success"];
            return View(profile);
        }
        [HttpPost]
        public ActionResult Index(ProfileViewModel profile)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
            profile.Image = ConvertToBytes(file);
            if (ModelState.IsValid)
            {
                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

                //Filter specific claim    
                var AccountID = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier, StringComparison.OrdinalIgnoreCase))?.Value;
                ProfileService profileService = new ProfileService();
                profileService.ProfileChanges(profile, int.Parse(AccountID));
                TempData["Success"] = true;
                ModelState.Clear();
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                ModelState.Clear();
                TempData["Success"] = false;
                return RedirectToAction("Index", "Profile");
            }
            
        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

    }
}