using System.Web.Optimization;

namespace WebApplication1
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/jquery").Include("~/Scripts/jquery/jquery-{version}.js"));
            bundles.Add(new Bundle("~/bundles/tv").Include("~/Scripts/TV/users.js"));
            bundles.Add(new Bundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap/bootstrap.js", "~/Scripts/bootstrap/respond.js"));
            bundles.Add(new Bundle("~/Content/css").Include("~/Content/*.css"));
        }
    }
}
