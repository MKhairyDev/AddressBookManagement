using System.Web;
using System.Web.Optimization;

namespace AddressBook.WebApp
{
    public class BundleConfig
    {
  
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            if (bundles != null)
            {
                bundles.Add(new ScriptBundle("~/bundles/jquery", "https://maps.googleapis.com/maps/api/js?key=AIzaSyDn8aqtpOImia5QtN6VYTQQ-UUe6ZBjFFE").Include(
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

                bundles.Add(new StyleBundle("~/Content/css").Include(
                          "~/Content/bootstrap.css",
                          "~/Content/site.css"));
            }
        }
    }
}
