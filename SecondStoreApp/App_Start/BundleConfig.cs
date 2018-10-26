﻿using System.Web.Optimization;

namespace SecondStoreApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryAndJqueryUI").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css",
                "~/Content/bootstrap-theme.css"));
        }
    }
}