using System.Web.Configuration;
using System.Web.Optimization;

namespace NKN.Core
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.UseCdn = true;   //enable CDN support

            // Styles bundle
            //bundles.Add(new StyleBundle("~/bundles/styles").Include("~/css/dist/style.min.css"));

            // Scripts bundle
            //bundles.Add(new ScriptBundle("~/bundles/scripts").Include("~/js/dist/global.min.js"));

            //CompilationSection compilationSection = (CompilationSection)System.Configuration.ConfigurationManager.GetSection(@"system.web/compilation");
            //BundleTable.EnableOptimizations = !compilationSection.Debug;
        }
    }
}