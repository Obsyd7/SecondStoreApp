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
            var categoryList = db.Categories.ToList();

            return View(categoryList);
        }

        public ActionResult StaticSites(string name)
        {
            return View(name);
        }
    }
}