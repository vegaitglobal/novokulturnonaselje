using System;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using NKN.Models.Generated;
using Umbraco.Core.Models.PublishedContent;

namespace NKN.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExternalRedirectAttribute : ActionFilterAttribute
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public ExternalRedirectAttribute(IUmbracoContextAccessor umbracoContextAccessor)
        {
            _umbracoContextAccessor =
                umbracoContextAccessor ?? throw new ArgumentNullException(nameof(umbracoContextAccessor));
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as RenderMvcController;
            if (controller == null) return;

            var currentUrl = filterContext.HttpContext.Request.Url;

            if (currentUrl == null) return;

            var rootPage = _umbracoContextAccessor.UmbracoContext
                .Content
                .GetAtRoot()
                .FirstOrDefault(rp => currentUrl.AbsoluteUri.StartsWith(rp.Url(mode: UrlMode.Absolute)));

            if (rootPage == null) return;

            var page = _umbracoContextAccessor.UmbracoContext
                    .Content
                    .GetByRoute($"{rootPage.Id}{currentUrl.AbsolutePath}")
                as IPage;

            if (string.IsNullOrWhiteSpace(page?.ExternalRedirect)) return;

            filterContext.HttpContext.Response.Redirect(page.ExternalRedirect);
        }
    }
}