using System.Web;
using System.Web.Optimization;

namespace TaxOnline.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            

                bundles.Add(new ScriptBundle("~/bundles/custombootstrap").Include(
                        "~/Scripts/ui-bootstrap-custom-0.5.0.js",
                        "~/Scripts/ui-bootstrap-custom-tpls-0.5.0.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/ajaxlogin").Include(
                "~/app/ajaxlogin.js"));

            bundles.Add(new ScriptBundle("~/bundles/breeze").Include(
                        "~/Scripts/q.js",
                        "~/Scripts/breeze.debug.js",
                        "~/Scripts/breeze.min.js",
                        "~/Scripts/breeze.savequeuing.js"));

            bundles.Add(new ScriptBundle("~/bundles/mainscripts").Include(
             "~/app/modules/main.module.js", // must be first
                          "~/app/services/utils.js",
                          "~/app/services/state.js",
             "~/app/services/logger.js",
             "~/app/controllers/base.controller.js",
             "~/app/services/search.js",
             
             "~/app/controllers/main.controller.js",
             "~/app/controllers/todo.controller.js",
             "~/app/controllers/logs.controller.js",
             "~/app/controllers/search.controller.js",
             "~/app/services/taxnoticeloader.js",
             "~/app/controllers/taxnotice.controller.js",
             "~/Scripts/utils.js"

             ));

            bundles.Add(new ScriptBundle("~/bundles/todo").Include(
                "~/app/todo.main.js", // must be first
                "~/app/todo.model.js",
                "~/app/todo.datacontext.js",
                "~/app/todo.controller.js",
                "~/app/about.controller.js",
                "~/app/about.logger.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

          

            bundles.Add(new StyleBundle("~/Content/css").Include(
                
                "~/Content/Site.css"
           ));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}