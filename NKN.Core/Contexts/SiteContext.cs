using System;
using NKN.Models.Generated;
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
        }

        protected UmbracoHelper UmbracoHelper { get; }

        private Lazy<IPage> LazyCurrentPage { get; }
        private Lazy<Home> LazyHome { get; }
        private Lazy<ISiteSettings> LazySiteSettings { get; }

        public IPage CurrentPage => LazyCurrentPage.Value;
        public Home Home => LazyHome.Value;
        public ISiteSettings SiteSettings => LazySiteSettings.Value;
    }
}