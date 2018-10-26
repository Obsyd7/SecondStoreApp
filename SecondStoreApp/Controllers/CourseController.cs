using System.Linq;
using System.Web.Mvc;
using SecondStoreApp.DAL;
using System.Data.Entity;

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
            var category = db.Categories.Include(x => x.Course).
                Where(c => c.CategoryName.ToUpper() == categoryName.ToUpper()).Single();

            var course = category.Course.ToList();

            return View(course);
        }

        public ActionResult Details(int id)
        {
            var course = db.Courses.Find(id);
            return View(course);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60000)]
        public ActionResult CategoryMenu(string id)
        {
            var categories = db.Categories.ToList();
            return PartialView("_CategoryMenu", categories);
        }

        public ActionResult CoursePrompts(string term)
        {
            var courses = db.Courses.Where(a => !a.Hidden && a.CourseTitle.ToLower().Contains(term.ToLower()))
                .Take(5).Select(a => new {label = a.CourseTitle});

            return Json(courses, JsonRequestBehavior.AllowGet);
        }
    }
}