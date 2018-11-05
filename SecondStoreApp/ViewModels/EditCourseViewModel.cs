using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SecondStoreApp.Models;

namespace SecondStoreApp.ViewModels
{
    public class EditCourseViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public bool? Confirmation { get; set; }
    }
}