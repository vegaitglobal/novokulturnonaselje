using NKN.Core.Contexts;
using NKN.Models.Extensions;
using NKN.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Web;
using Umbraco.Web.Composing;

namespace NKN.Core.Extensions
{
	public static class UmbracoHelperExtensions
    {
        public static ISiteContext CreateSiteContext(this UmbracoHelper helper)
        {
            return new SiteContext(helper);
        }

        public static IPageContext<T> CreatePageContext<T>(this UmbracoHelper helper, T page) where T : class, IPage
        {
            return new PageContext<T>(page, helper);
        }

		public static IEnumerable<T> GetContentOfType<T>(this UmbracoHelper helper) where T : class
		{
			if (helper == null) return default(IEnumerable<T>);

			return Current.UmbracoHelper.ContentAtXPath(GetXpath(typeof(T))).AsType<T>();
		}

		private static string GetXpath(Type t)
		{
			return $"//*[@isDoc and translate(name(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = '{t.Name.RemoveViewModelSuffix().ToLower()}']";
		}

		public static IEnumerable<Home> GetLanguages(this UmbracoHelper helper)
			=> helper?.ContentAtRoot().Where(c => c.GetTemplateAlias() == Home.ModelTypeAlias).OfType<Home>() ?? Enumerable.Empty<Home>();

	}
}