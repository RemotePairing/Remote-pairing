namespace CodeMate.WebApp
{
    using System.Web.Optimization;
    using System.Collections.Generic;

    class NonOrderingBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }


    static class BundleExtentions
    {
        public static Bundle PreserveOrder(this Bundle bundle)
        {
            bundle.Orderer = new NonOrderingBundleOrderer();
            return bundle;
        }
    }

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").PreserveOrder().Include(
                "~/Scripts/fullcalendar/moment.min.js",
                "~/Scripts/fullcalendar/jquery-ui.custom.min.js",
                "~/Scripts/fullcalendar/fullcalendar.min.js"));

            bundles.Add(new StyleBundle("~/Content/fullcalendar").Include(
                "~/Content/fullcalendar.css",
                "~/Content/themes/base/jquery-ui.min.css",
                "~/Content/themes/smoothness/jquery-ui.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            // Page-specific bundles
            bundles.Add(new ScriptBundle("~/bundles/homepage").Include(
                "~/Scripts/homepage.js"));
        }
    }
}