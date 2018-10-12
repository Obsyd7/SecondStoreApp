using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondStoreApp.DAL;
using SecondStoreApp.Models;

namespace SecondStoreApp.Controllers
{
    public class HomeController : Controller
    {
        private StoreDbContext db = new StoreDbContext();

        public ActionResult Index()
        {
            Category category = new Category
            {
                CategoryName = "asp.net mvc",
                IconFileName = "aspNetMvc.png",
                CategoryDescription = "Description"
            };

            db.Categories.Add(category);
            db.SaveChanges();

            return View();
        }
    }
}