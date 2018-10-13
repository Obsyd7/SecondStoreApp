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
                    CategoryName = "asp",
                    IconFileName = "asp.png",
                    CategoryDescription = "description asp net mvc",
                },

                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "java",
                    IconFileName = "java.png",
                    CategoryDescription = "description java",
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "php",
                    IconFileName = "php.png",
                    CategoryDescription = "description php",
                },
                new Category()
                {
                    CategoryId = 4,
                    CategoryName = "html",
                    IconFileName = "html.png",
                    CategoryDescription = "description html",
                },
                new Category()
                {
                    CategoryId = 5,
                    CategoryName = "css",
                    IconFileName = "css.png",
                    CategoryDescription = "description css",
                },
                new Category()
                {
                    CategoryId = 6,
                    CategoryName = "xml",
                    IconFileName = "xml.png",
                    CategoryDescription = "description xml",
                },
                new Category()
                {
                    CategoryId = 7,
                    CategoryName = "c#",
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
                    Author = "Thomas",
                    CourseTitle = "asp.net mvc",
                    CategoryId = 1,
                    CoursePrice = 99,
                    Bestseller = true,
                    ImgFileName = "asp.png",
                    DateAdded = DateTime.Now,
                    CourseDescription = "course description1"
                },
                new Course()
                {
                    Author = "Jack",
                    CourseTitle = "asp.net mvc",
                    CategoryId = 1,
                    CoursePrice = 120,
                    Bestseller = true,
                    ImgFileName = "asp.png",
                    DateAdded = DateTime.Now,
                    CourseDescription = "course description2"
                },
                new Course()
                {
                    Author = "Stephen",
                    CourseTitle = "asp.net mvc",
                    CategoryId = 1,
                    CoursePrice = 120,
                    Bestseller = true,
                    ImgFileName = "asp.png",
                    DateAdded = DateTime.Now,
                    CourseDescription = "course description3"
                },
                new Course()
                {
                    Author = "Beth",
                    CourseTitle = "asp.net mvc",
                    CategoryId = 1,
                    CoursePrice = 140,
                    Bestseller = true,
                    ImgFileName = "asp.png",
                    DateAdded = DateTime.Now,
                    CourseDescription = "course description4"
                },

            };

            courses.ForEach(c => context.Courses.AddOrUpdate(c));
            context.SaveChanges();
        }
    }
}