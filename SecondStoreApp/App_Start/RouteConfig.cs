using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SecondStoreApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CourseDetails",
                url: "course-{id}.html",
                defaults: new { controller = "Course", action = "Details" }
            );

            routes.MapRoute(
                name: "CourseList",
                url: "Category/{categoryName}",
                defaults: new { controller = "Course", action = "List"}
                );

            routes.MapRoute(
                name: "StaticSites",
                url: "site/{name}.html",
                defaults: new {Controller = "Home", action = "StaticSites"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
