using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web;
using NKN.Common;
using NKN.Core.Attributes;
using WebMarkupMin.AspNet4.Mvc;

namespace NKN.Core
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            if (AppSettings.DisableHttpCompression != true) filters.Add(new CompressContentAttribute());

            filters.Add(new MinifyHtmlAttribute());
            filters.Add(new ExternalRedirectAttribute(Current.Factory.GetInstance<IUmbracoContextAccessor>()));
        }
    }
}