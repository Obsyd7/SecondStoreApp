using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondStoreApp.DAL;
using SecondStoreApp.Infrastructure;
using SecondStoreApp.Models;
using SecondStoreApp.ViewModels;

namespace SecondStoreApp.Controllers
{
    public class HomeController : Controller
    {
        private StoreDbContext db = new StoreDbContext();

        public ActionResult Index()
        {
            

            ICacheProvider cache = new DefaultCacheProvider();

            List<Category> categories;

            if (cache.IsSet(Const.CategoryCacheKey))
            {
                categories = cache.Get(Const.CategoryCacheKey) as List<Category>;
            }
            else
            {
                categories = db.Categories.ToList();
                cache.Set(Const.CategoryCacheKey, categories, 60);
            }

            List<Course> newest;

            if (cache.IsSet(Const.NewestCacheKey))
            {
                newest = cache.Get(Const.NewestCacheKey) as List<Course>;
            }
            else
            {
                newest = db.Courses.Where(a => !a.Hidden).OrderByDescending(a => a.DateAdded).Take(3).ToList();
                cache.Set(Const.NewestCacheKey, newest, 60);
            }

            List<Course> bestsellers;

            if (cache.IsSet(Const.BestSellerCacheKey))
            {
                bestsellers = cache.Get(Const.BestSellerCacheKey) as List<Course>;
            }
            else
            {
                bestsellers = db.Courses.Where(a => !a.Hidden && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(3).ToList();
                cache.Set(Const.BestSellerCacheKey, newest, 60);
            }

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