using System.Web;
using System.Web.Optimization;

namespace StayHealthy
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/toastr.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/toastr.css"
                      ));

            bundles.Add(new StyleBundle("~/AngularCSSBundle").Include(
                "~/Content/angular-material.css"
                ));

            bundles.Add(new ScriptBundle("~/AngularJSBundle").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-ui-router.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/angular-aria.js",
                "~/Scripts/angular-material.js",
                "~/JS/appConfiguration.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/JqueryValidation").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/JSFiles")
            .IncludeDirectory("~/JS", "*.js", true)
                );

        }
    }
}
