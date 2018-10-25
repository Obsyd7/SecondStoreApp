using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcSiteMapProvider;
using SecondStoreApp.DAL;
using SecondStoreApp.Models;

namespace SecondStoreApp.Infrastructure
{
    public class CategoryDynamicNodeProvider : DynamicNodeProviderBase
    {
        private StoreDbContext db = new StoreDbContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodE)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Category category in db.Categories)
            {
                DynamicNode node = new DynamicNode();
                node.Title = category.CategoryName;
                node.Key = "Category_" + category.CategoryId;
                node.RouteValues.Add("categoryName", category.CategoryId);

                returnValue.Add(node);
            }

            return returnValue;
        }
    }
}