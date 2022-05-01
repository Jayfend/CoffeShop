using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace CoffeShop.Areas.Admin.Controllers
{   
    public class BasicElementController : Controller
    {
        // GET: Admin/BasicElement
        [HttpGet]
        public ActionResult Index()
        {
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
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}