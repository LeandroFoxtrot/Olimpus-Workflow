using System.Web.Optimization;
using System.Web.UI.WebControls;

namespace Lead7.Olimpus.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.min.js", "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/gauge").Include("~/Scripts/gauge/gauge.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/chart").Include("~/Scripts/chartjs/chart.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap_progress").Include("~/Scripts/progressbar/bootstrap-progressbar.min.js", "~/Scripts/nicescroll/jquery.nicescroll.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/icheck").Include("~/Scripts/icheck/icheck.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/daterangepicker").Include("~/Scripts/moment.min.js", "~/Scripts/datepicker/daterangepicker.js"));
            bundles.Add(new ScriptBundle("~/bundles/custom").Include("~/Scripts/custom.js"));
            bundles.Add(new ScriptBundle("~/bundles/flot").Include("~/Scripts/flot/jquery.flot*", "~/Scripts/flot/date.js", "~/Scripts/flot/curvedLines.js"));
            bundles.Add(new ScriptBundle("~/bundles/maps").Include("~/Scripts/jquery-jvectormap*", "~/Scripts/maps/gdp-data.js"));
            bundles.Add(new ScriptBundle("~/bundles/pace").Include("~/Scripts/pace/pace.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/skycons").Include("~/Scripts/skycons/skycons.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/nprogress").Include("~/Scripts/nprogress.js"));
            bundles.Add(new ScriptBundle("~/bundles/messagebox").Include("~/Scripts/messagebox/dist/js/lobibox.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Content/animate").Include("~/Content/animate.min.css"));
            bundles.Add(new StyleBundle("~/Fonts/css").Include("~/fonts/css/font-awesome.min.css"));
            bundles.Add(new StyleBundle("~/Content/custom").Include("~/Content/custom.css"));
            bundles.Add(new StyleBundle("~/Content/maps").Include("~/Content/maps/jquery-jvectormap-2.0.3.css"));
            bundles.Add(new StyleBundle("~/Content/icheck").Include("~/Content/icheck/flat/green.css"));
            bundles.Add(new StyleBundle("~/Content/float").Include("~/Content/floatexamples.css"));
            bundles.Add(new StyleBundle("~/Content/messagebox").Include("~/Scripts/messagebox/dist/css/lobibox.css"));
        }
    }
}