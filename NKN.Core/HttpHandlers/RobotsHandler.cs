using System.Linq;
using System.Net;
using System.Web;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Web;
using NKN.Core.Extensions;
using NKN.Models.Generated;
using Umbraco.Core.Models.PublishedContent;

namespace NKN.Core.HttpHandlers
{
    public class RobotsHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var contextBase = context.ToBase();
            var path = context.Server.MapPath(context.Request.RawUrl);

            // Is there a file that already exists on the file system?
            // If so, always serve that.
            if (System.IO.File.Exists(path))
            {
                Current.Logger.Debug<RobotsHandler>("Streaming specified robots file from disk.");

                contextBase.Response.TransmitFileContent(path);
                return;
            }

            // Ensure there is an Umbraco context that is necessary for data access.
            var umbracoContextFactory =
                Current.Factory.GetInstance(typeof(IUmbracoContextFactory)) as IUmbracoContextFactory;
            var umbracoContext = umbracoContextFactory?.EnsureUmbracoContext(contextBase)?.UmbracoContext;
            if (umbracoContext == null)
            {
                Current.Logger.Warn<RobotsHandler>("Umbraco context is null even after ensuring there is one!");
                throw new HttpException((int) HttpStatusCode.NotFound, "Page Not Found");
            }

            contextBase.Response.Clear();
            contextBase.Response.ContentType = "text/plain";

            // Lets try and find the robots file contents from Umbraco.
            var siteSettings = umbracoContext
                    .Content
                    .GetAtRoot()
                    .FirstOrDefault(c => context.Request.Url.AbsoluteUri.StartsWith(c.Url(mode: UrlMode.Absolute)))
                as ISiteSettings;

            contextBase.Response.Write(siteSettings?.Robots ?? string.Empty);

            contextBase.Response.End();
        }

        public bool IsReusable => true;
    }
}