using System.Web;
using System.Web.Optimization;

namespace Asset_Management
{
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

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/scripts/jqueryall", "//cdn.syncfusion.com/scripts/jquery/jquery.all.min.js")
                                              .Include("~/Scripts/jquery.all.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts/ejdialogall", "//cdn.syncfusion.com/scripts/components/essentialjs/ej.dialog.all_15.min.js").Include("~/Scripts/ej.dialog.all_15.min.js"));

            bundles.Add(new StyleBundle("~/bundles/styles/gridmaterialthemecss", "//cdn.syncfusion.com/15.1.0.41/js/web/material/ej.web.all.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/scripts/ejwidget").Include("~/Scripts/ej.widget.all.js"));

            bundles.Add(new ScriptBundle("~/scripts/jqueries").Include(
"~/Scripts/jQuery/jquery-2.1.4.min.js",
"~/Scripts/jQuery/jquery.easing.1.3.min.js",
"~/Scripts/jQuery/jquery.globalize.min.js",
"~/Scripts/jQuery/jsrender.min.js",
"~/Scripts/jQuery/jquery-ui.js",
"~/Scripts/jQuery/jquery.validate.min.js",
"~/Scripts/jQuery/jquery.validate.unobtrusive.min.js",
"~/Scripts/jQuery/modernizr-2.6.2.js",
"~/Scripts/Bootstrap/bootstrap.min.js"
  ));
        }
    }
}
