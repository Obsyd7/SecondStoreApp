using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SecondStoreApp.DAL;

namespace SecondStoreApp.Controllers
{
    public class CourseController : Controller
    {
        private StoreDbContext db = new StoreDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string categoryName)
        {
            var category = db.Categories.Include("Course")
                .Where(c => c.CategoryName.ToUpper() == categoryName.ToUpper()).Single();

            var course = category.Course.ToList();

            return View(course);
        }

        public ActionResult Details(int id)
        {
            var course = db.Courses.Find(id);
            return View(course);
        }

        [ChildActionOnly]
        public ActionResult CategoryMenu(string id)
        {
            var categories = db.Categories.ToList();
            return PartialView("_CategoryMenu", categories);
        }
    }
}