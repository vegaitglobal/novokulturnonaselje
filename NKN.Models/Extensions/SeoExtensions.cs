using System;
using Umbraco.Core;
using Umbraco.Web;
using NKN.Models.DocumentTypes;
using NKN.Models.Generated;
using Umbraco.Core.Models.PublishedContent;

namespace NKN.Models.Extensions
{
	public static class SeoExtensions
	{
		/// <summary>
		/// Returns formatted <paramref name="seo"/> SEO title, based on specified <paramref name="format"/>.
		/// </summary>
		/// <param name="seo">The seo.</param>
		/// <param name="currentPage">The current page.</param>
		/// <param name="brandName">Brand name to use in the SEO title.</param>
		/// <param name="format">Format to use. First placeholder is used for SEO title, and second one for brand name.</param>
		/// <param name="discardTitleForHomePage">If <c>true</c> only brand name will be used for Home Page SEO title.</param>
		/// <returns>Formatted <paramref name="seo"/> SEO title.</returns>
		public static string GetFormattedSeoTitle(this ISeo seo, IPage currentPage, string brandName, string format = "{0} | {1}", bool discardTitleForHomePage = true)
		{
			if (discardTitleForHomePage && currentPage.IsHome()) return brandName;

			string seoTitle = seo.SeoTitle.IsNullOrWhiteSpace() ? currentPage.PageTitle() : seo.SeoTitle;

			return brandName.IsNullOrWhiteSpace() ? seoTitle : string.Format(format, seoTitle, brandName);
		}

		/// <summary>
		/// Returns canonical url.
		/// </summary>
		/// <param name="seo">The seo.</param>
		/// <param name="canonicalDomain">The canonical domain.</param>
		/// <returns></returns>
		public static string GetCanonicalUrl(this ISeo seo, string canonicalDomain)
		{
			if (seo.CanonicalLink != null) return seo.CanonicalLink.Url;

			if (canonicalDomain.IsNullOrWhiteSpace())
			{
				return seo.Url(mode: UrlMode.Absolute);
			}

			try
			{
				return $"{new Uri(seo.Url(mode: UrlMode.Absolute)).Scheme}://{canonicalDomain}{seo.Url}";
			}
			catch (Exception)
			{
				//ignore
				//this check is because of the preview option in the CMS
			}

			return string.Empty;
		}
	}
}
