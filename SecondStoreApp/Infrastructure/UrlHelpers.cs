using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondStoreApp.Infrastructure
{
    public static class UrlHelpers
    {
        public static string CategoryIconsPath(this UrlHelper helper, string categoryIconName)
        {
            var categoryIconsFolder = AppConfig.CategoryIconsRelativeFolder;
            var path = Path.Combine(categoryIconsFolder, categoryIconName);
            var absolutePath = helper.Content(path);

            return absolutePath;
        }

        public static string CourseImagesPath(this UrlHelper helper, string courseImageName)
        {
            var courseImageFolder = AppConfig.CourseImagesRelativeFolder;
            var path = Path.Combine(courseImageFolder, courseImageName);
            var absolutePath = helper.Content(path);

            return absolutePath;
        }
    }
}