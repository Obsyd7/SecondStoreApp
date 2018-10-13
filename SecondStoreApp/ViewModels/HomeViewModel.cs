using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SecondStoreApp.Models;

namespace SecondStoreApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> CategoryViewModel { get; set; }
        public IEnumerable<Course> NewestCourseViewModel { get; set; }
        public IEnumerable<Course> Bestsellers { get; set; }
    }
}