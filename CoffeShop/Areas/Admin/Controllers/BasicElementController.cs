using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace CoffeShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BasicElementController : Controller
    {
        // GET: Admin/BasicElement
        [HttpGet]
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

                //Filter specific claim    
                var AccountID = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier, StringComparison.OrdinalIgnoreCase))?.Value;

                Services.Login LoginService = new Services.Login();
                ViewBag.avatar = LoginService.GetAvatar(int.Parse(AccountID));
                //ViewBag.CartCount = ViewBag.Cart.Count; 
            }
            ViewBag.ProductMG = "active";
            return View();
        }
        [HttpPost]
        public ActionResult AddNewProduct(ProductViewModel product)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
            product.Image= ConvertToBytes(file);
            ProductService addnewproduct = new ProductService();
            if (ModelState.IsValid)
            {
                if (addnewproduct.AddProductToDb(product))
                {
                    ViewBag.success = "Add Product Successful";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Add Product Failed";
                    return View("Index");
                }
                
                
            }
               
            return View();
        }
        public ActionResult DeleteProduct(int ProductId)
        {   ProductService productService = new ProductService();
            if (productService.DeleteProduct(ProductId))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
        [HttpPost]
        public JsonResult AdminSignUp(SignupViewModel account)
        {
            if (ModelState.IsValid)
            {
                SignUp signup = new SignUp();
                if (signup.RegisterAdmin(account))
                {

                    return Json(new { result = true }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    
                    return Json(new { result = false }, JsonRequestBehavior.AllowGet);

                }

            }
            return Json(new { result = false }, JsonRequestBehavior.AllowGet);
        }
    }
}