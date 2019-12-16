using NKN.Models.Generated;
using System.Collections.Generic;

namespace NKN.Models.Extensions
{
	public static class PageExtensions
	{
		public static string PageTitle(this IPage page)
		{
			return page.GetPropertyWithDefaultValue(page.Name);
		}

		public static bool IsHome(this IPage page)
		{
			return page.ContentType.Alias == Home.ModelTypeAlias;
		}

		public static IEnumerable<T> GetNavigationItems<T>(this IPage node) where T : class, IPage
			=> node.Children<T>(c => !c.UmbracoNaviHide);

		public static bool ChangeColorToBlack(this IPage node)
		{
			return node.ChangeTitleColor ? true : false;
		}
	}
}