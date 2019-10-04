using System.Web.Routing;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using NKN.Core.Extensions;
using NKN.Models.Generated;

namespace NKN.Core.Handlers
{
	/// <summary>
	/// Provides Error 404 node for the current request
	/// </summary>
	public class Error404RouteHandler : UmbracoVirtualNodeRouteHandler
	{
		public Error404RouteHandler()
		{ }

		protected override IPublishedContent FindContent(RequestContext requestContext, UmbracoContext umbracoContext)
			=> umbracoContext.TypedContentAtDomainRoot(requestContext.HttpContext.Request.Url.AbsolutePath)?.FirstChild<Error404>();
	}
}
