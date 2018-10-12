using System;
using System.Collections;
using System.Collections.Generic;

namespace SecondStoreApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string IconName { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}