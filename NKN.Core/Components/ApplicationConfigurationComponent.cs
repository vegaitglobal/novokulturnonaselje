using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Umbraco.Core;
using Umbraco.Core.Composing;
using NKN.Core.ViewEngines;

namespace NKN.Core.Components
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class ApplicationConfigurationComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<ApplicationConfigurationComponent>();
        }
    }

    public class ApplicationConfigurationComponent : IComponent
    {
        // initialize: runs once when Umbraco starts
        public void Initialize()
        {
            System.Web.Mvc.ViewEngines.Engines.Add(new PartialViewEngine());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        // terminate: runs once when Umbraco stops
        public void Terminate()
        {
        }
    }
}