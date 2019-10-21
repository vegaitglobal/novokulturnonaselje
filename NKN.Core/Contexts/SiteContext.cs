using NKN.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Web;

namespace NKN.Core.Contexts
{
	public class SiteContext : ISiteContext
    {
        public SiteContext(UmbracoHelper umbracoHelper)
        {
            UmbracoHelper = umbracoHelper ?? throw new ArgumentNullException(nameof(umbracoHelper));

            LazyCurrentPage = new Lazy<IPage>(() => UmbracoHelper.AssignedContentItem as IPage);
            LazyHome = new Lazy<Home>(() => UmbracoHelper.AssignedContentItem?.AncestorOrSelf<Home>());
            LazySiteSettings = new Lazy<ISiteSettings>(() => LazyHome.Value);
			LazyNews = new Lazy<IEnumerable<DetailsPage>>(() => UmbracoHelper.ContentAtXPath($"//{NewsLanding.ModelTypeAlias}").DescendantsOrSelf<DetailsPage>()?.OrderByDescending(d=>d.ReleaseDate).Take(3));
		}

        protected UmbracoHelper UmbracoHelper { get; }

        private Lazy<IPage> LazyCurrentPage { get; }
        private Lazy<Home> LazyHome { get; }
        private Lazy<ISiteSettings> LazySiteSettings { get; }
		private Lazy<IEnumerable<DetailsPage>> LazyNews { get; }

		public IPage CurrentPage => LazyCurrentPage.Value;
        public Home Home => LazyHome.Value;
        public ISiteSettings SiteSettings => LazySiteSettings.Value;
		public IEnumerable<DetailsPage> LatestNews => LazyNews.Value;
	}
}