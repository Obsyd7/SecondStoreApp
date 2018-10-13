using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondStoreApp.DAL;
using SecondStoreApp.Models;
using SecondStoreApp.ViewModels;

namespace SecondStoreApp.Controllers
{
    public class HomeController : Controller
    {
        private StoreDbContext db = new StoreDbContext();

        public ActionResult Index()
        {
            var categories = db.Categories.ToList();

            var newest = db.Courses.Where(a => !a.Hidden).OrderByDescending(a => a.DateAdded).Take(3).ToList();

            var bestsellers = db.Courses.Where(a => !a.Hidden && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(3)
                .ToList();

            var viewmodel = new HomeViewModel()
            {
                CategoryViewModel = categories,
                Bestsellers = bestsellers,
                NewestCourseViewModel = newest
            };

            return View(viewmodel);
        }

        public ActionResult StaticSites(string name)
        {
            return View(name);
        }

    }
}