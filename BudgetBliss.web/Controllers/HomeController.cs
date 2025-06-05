using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace BudgetBliss.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();

        public ActionResult Shop()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Profile()
        {
            ViewBag.Message = "Your Profile.";
            return View();
        }

        public ActionResult MyCart()
        {
            ViewBag.Message = "Your Cart.";
            return View();
        }

        public ActionResult MyListings()
        {
            ViewBag.Message = "Your Listings.";
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your Login.";
            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your Register.";
            return View();
        }

        public ActionResult IndexAdmin()
        {
            ViewBag.Message = "Your Register.";
            return View();
        }

        public ActionResult PofileAdmin()
        {
            ViewBag.Message = "Your Register.";
            return View();
        }

        public ActionResult ShopAdmin()
        {
            ViewBag.Message = "Your Register.";
            return View();
        }

        public ActionResult ContactAdmin()
        {
            ViewBag.Message = "Your Contact Admin.";
            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Your Admin Page.";
            return View();
        }

        // 🔧 New EditProduct Page
        public ActionResult EditProduct(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        // 💾 Handle Save
        [HttpPost]
        public ActionResult SaveProduct(int id, string Name, string Price, HttpPostedFileBase imageUpload)
        {
            // Simulate saving logic
            if (imageUpload != null && imageUpload.ContentLength > 0)
            {
                string extension = Path.GetExtension(imageUpload.FileName);
                string savePath = Server.MapPath($"~/Content/Images/listing{id + 1}{extension}");

                // Overwrite the existing image
                imageUpload.SaveAs(savePath);
            }

            // In a real app, you'd persist Name and Price to a DB here

            return RedirectToAction("MyListings");
        }
    }
}
