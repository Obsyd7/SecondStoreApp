﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SecondStoreApp.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string categoryName)
        {
            return View();
        }

        public ActionResult Details(string id)
        {
            return View();
        }
    }
}