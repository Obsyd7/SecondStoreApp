using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SecondStoreApp.Infrastructure
{
    public class AppConfig
    {
        private static string _categoryIconsRelativeFolder = ConfigurationManager.AppSettings["CategoryIconFolder"];

        public static string CategoryIconsRelativeFolder
        {
            get { return _categoryIconsRelativeFolder; }
        }


        private static string _courseImagesRelativeFolder = ConfigurationManager.AppSettings["CourseImagesFolder"];

        public static string CourseImagesRelativeFolder
        {
            get { return _courseImagesRelativeFolder; }
        }
    }
}