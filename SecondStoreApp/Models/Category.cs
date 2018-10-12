using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecondStoreApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please, enter category name")]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Please, enter category description")]
        [StringLength(100)]
        public string CategoryDescription { get; set; }

        public string IconFileName { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}