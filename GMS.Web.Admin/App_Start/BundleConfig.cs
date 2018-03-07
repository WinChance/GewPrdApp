using System.Web.Optimization;

namespace GMS.Web.Admin
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/bower_components/bootstrap/dist/js/bootstrap.min.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/bower_components/bootstrap/dist/css/bootstrap.min.css",
            //          "~/bower_components/metisMenu/dist/metisMenu.min.css",
            //          "~/Content/timeline.css",
            //          "~/Content/sb-admin-2.css"));


            // 参考PDA的绑定
            //var globalStyleBundle = new StyleBundle("~/media/bundles/css");
            //globalStyleBundle.Include(
            //    "~/media/css/bootstrap.min.css"
            //    , "~/media/css/bootstrap-responsive.min.css"
            //    , "~/media/css/bootstrap-datetimepicker.min.css"
            //    , "~/media/css/font-awesome.min.css"
            //    , "~/media/css/style-metro.css"
            //    , "~/media/css/style.css"
            //    , "~/media/css/style-responsive.css"
            //    , "~/media/css/default.css"
            //    , "~/media/css/uniform.default.css"
            //    , "~/Content/Kendo/kendo.common.min.css"
            //    , "~/Content/Kendo/kendo.default.min.css"
            //    , "~/Content/Site.css");
            //bundles.Add(globalStyleBundle);

            //var coreJsPluginBundle1 = new ScriptBundle("~/bundles/plugin/core1/jquery");
            //coreJsPluginBundle1.Include(
            //    //"~/media/js/jquery-1.10.1.min.js"  //this version will happen error when print review order
            //    // 我注释了一行后菜单可以折叠了！！ ---->"~/Scripts/jquery-1.10.2.js"
            //    "~/media/js/jquery-migrate-1.2.1.min.js"
            //    //IMPORTANT! Load jquery-ui-1.10.1.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip
            //    , "~/media/js/jquery-ui-1.10.1.custom.min.js"
            //    , "~/media/js/bootstrap.min.js"
            //    , "~/media/js/bootstrap-datetimepicker.js"
            //    , "~/media/js/bootstrap-datetimepicker.fr.js"
            //    , "~/Scripts/Kendo/kendo.all.min.js"
            //    , "~/Scripts/Kendo/jszip.min.js"
            //    , "~/Scripts/spin.min.js"
            //    , "~/Scripts/pda_improving.js"
            //     , "~/media/js/jquery.extend.printPage.js"
            //     );
            //bundles.Add(coreJsPluginBundle1);

            //var coreJsPluginBundle2 = new ScriptBundle("~/bundles/plugin/core2/jquery");
            //coreJsPluginBundle2.Include(
            //    "~/media/js/jquery.slimscroll.min.js"
            //    , "~/media/js/jquery.blockui.min.js"
            //    , "~/media/js/jquery.cookie.min.js"
            //    , "~/media/js/jquery.uniform.min.js");
            //bundles.Add(coreJsPluginBundle2);
        }
    }
}
