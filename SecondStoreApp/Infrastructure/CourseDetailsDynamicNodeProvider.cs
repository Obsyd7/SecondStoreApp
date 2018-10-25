using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using MvcSiteMapProvider;
using SecondStoreApp.DAL;
using SecondStoreApp.Models;

namespace SecondStoreApp.Infrastructure
{
    public class CourseDetailsDynamicNodeProvider : DynamicNodeProviderBase
    {
        private StoreDbContext db = new StoreDbContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodE)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Course course in db.Courses)
            {
                DynamicNode node = new DynamicNode();
                node.Title = course.CourseTitle;
                node.Key = "Course_" + course.CourseId;
                node.ParentKey = "Category_" + course.CategoryId;
                node.RouteValues.Add("id", course.CourseId);

                returnValue.Add(node);
            }

            return returnValue;
        }
    }
}