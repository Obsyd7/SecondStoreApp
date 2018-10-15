using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using SecondStoreApp.Migrations;
using SecondStoreApp.Models;

namespace SecondStoreApp.DAL
{
    public class CourseInitializer : MigrateDatabaseToLatestVersion<StoreDbContext, Configuration>
    {
        //protected override void Seed (StoreDbContext context)
        //{
        //    SeedCourseData(context);
        //    base.Seed(context);
        //}

        public static void SeedCourseData(StoreDbContext context)
        {
            var category = new List<Category>
            {
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Asp.Net MVC",
                    IconFileName = "asp.png",
                    CategoryDescription = "description asp net mvc",
                },

                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Java",
                    IconFileName = "java.png",
                    CategoryDescription = "description java",
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "PHP",
                    IconFileName = "php.png",
                    CategoryDescription = "description php",
                },
                new Category()
                {
                    CategoryId = 4,
                    CategoryName = "Html",
                    IconFileName = "html.png",
                    CategoryDescription = "description html",
                },
                new Category()
                {
                    CategoryId = 5,
                    CategoryName = "CSS",
                    IconFileName = "css.png",
                    CategoryDescription = "description css",
                },
                new Category()
                {
                    CategoryId = 6,
                    CategoryName = "Xml",
                    IconFileName = "xml.png",
                    CategoryDescription = "description xml",
                },
                new Category()
                {
                    CategoryId = 7,
                    CategoryName = "C#",
                    IconFileName = "c#.png",
                    CategoryDescription = "description c#",
                },
            };

            category.ForEach(c => context.Categories.AddOrUpdate(c));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course()
                {
                    Author = "Thomas White",
                    CourseTitle = "Asp.net MVC",
                    CategoryId = 1,
                    CoursePrice = 99,
                    Bestseller = true,
                    ImgFileName = "obrazekaspnet.png",
                    DateAdded = DateTime.Now,
                    CourseDescription = "course description1"
                },
                new Course()
                {
                    Author = "Jack Blue",
                    CourseTitle = "JavaScript",
                    CategoryId = 2,
                    CoursePrice = 120,
                    Bestseller = true,
                    ImgFileName = "obrazekjavascript.png",
                    DateAdded = DateTime.Now,
                    CourseDescription = "course description2"
                },
                new Course()
                {
                    Author = "Stephen Green",
                    CourseTitle = "JQuery",
                    CategoryId = 3,
                    CoursePrice = 120,
                    Bestseller = true,
                    ImgFileName = "obrazekjquery.png",
                    DateAdded = DateTime.Now,
                    CourseDescription = "course description3"
                },
                new Course()
                {
                    Author = "Beth Black",
                    CourseTitle = "Html5",
                    CategoryId = 4,
                    CoursePrice = 140,
                    Bestseller = true,
                    ImgFileName = "obrazekhtml.png",
                    DateAdded = DateTime.Now,
                    CourseDescription = "course description4"
                },
                new Course()
                {
                    Author = "Tom Brown",
                    CourseTitle = "Css3",
                    CategoryId = 5,
                    CoursePrice = 125,
                    Bestseller = true,
                    ImgFileName = "obrazekcss.png",
                    DateAdded = DateTime.Now,
                    CourseDescription = "course description5"
                },
                new Course()
                {
                    Author = "Bob Orange",
                    CourseTitle = "Xml",
                    CategoryId = 6,
                    CoursePrice = 90,
                    Bestseller = true,
                    ImgFileName = "obrazekxlm.png",
                    DateAdded = DateTime.Now,
                    CourseDescription = "course description6"
                },
                new Course()
                {
                    Author = "Bob Orange",
                    CourseTitle = "C#",
                    CategoryId = 7,
                    CoursePrice = 185,
                    Bestseller = true,
                    ImgFileName = "obrazekcsharp.png",
                    DateAdded = DateTime.Now,
                    CourseDescription = "course description7"
                },

            };

            courses.ForEach(c => context.Courses.AddOrUpdate(c));
            context.SaveChanges();
        }
    }
}