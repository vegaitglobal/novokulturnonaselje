using System.Linq;
using System.Web.Configuration;
using System.Web.Routing;
using System.Xml.Linq;
using Umbraco.Web;
using NKN.Common;
using NKN.Core.Controllers.RenderMvc;
using NKN.Core.Extensions;
using NKN.Core.Handlers;

namespace NKN.Core
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Route for the XML sitemap functionality
            routes.MapUmbracoRoute(
                "SitemapXML",
                AppSettings.XMLSitemapRouteUrl,
                new
                {
                    controller = nameof(XMLSitemapController).RemoveControllerSuffix(),
                    action = nameof(XMLSitemapController.XMLSitemap)
                },
                new DomainRootRouteHandler()
            );

            // Route for the Content Not Found (Error404) error handling, to make it irrelevant where Error404 node is placed in Content tree.
            var error404RouteUrl = GetError404RouteUrl();
            if (!string.IsNullOrWhiteSpace(error404RouteUrl))
                routes.MapUmbracoRoute(
                    "Error404",
                    error404RouteUrl,
                    new
                    {
                        controller = nameof(Error404Controller).RemoveControllerSuffix(),
                        action = nameof(Error404Controller.Index)
                    },
                    new Error404RouteHandler()
                );
        }

        private static string GetError404RouteUrl()
        {
            // This will pick up Error 404 path from system.webServer/httpErrors configuration setting, and return it as Error 404 route URL.
            var xml = WebConfigurationManager.OpenWebConfiguration("/").GetSection("system.webServer")
                .SectionInformation.GetRawXml();
            var url = XDocument.Parse(xml).Root.Element("httpErrors")?.Elements("error")
                ?.FirstOrDefault(e => e.Attribute("statusCode")?.Value == "404")?.Attribute("path")?.Value;

            if (!string.IsNullOrEmpty(url) && url[0] == '/') url = url.Substring(1);

            return url;
        }
    }
}