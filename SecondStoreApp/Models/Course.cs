using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondStoreApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please, enter course title")]
        [StringLength(100)]
        public string CourseTitle { get; set; }

        [Required(ErrorMessage = "Please, enter the author")]
        [StringLength(100)]
        public string Author { get; set; }

        public DateTime DateAdded { get; set; }

        [StringLength(100)]
        public string ImgFileName { get; set; }

        public string CourseDescription { get; set; }

        public decimal CoursePrice { get; set; }

        public bool Bestseller { get; set; }

        public bool Hidden { get; set; }

        public virtual Category Category { get; set; }
    }
}