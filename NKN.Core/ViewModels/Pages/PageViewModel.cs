using System;
using System.Globalization;
using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Partials.Layout;
using NKN.Models.Generated;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace NKN.Core.ViewModels.Pages
{
    public class PageViewModel
    {
        public PageViewModel(IPageContext<IPage> context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            MetaTagsLazy = new Lazy<MetaTagsViewModel>(() => new MetaTagsViewModel(context.CreateSeoContext(context.Page)));
            HeaderLazy = new Lazy<HeaderViewModel>(() => new HeaderViewModel(context.WithComposition(context.Home)));
            FooterLazy = new Lazy<FooterViewModel>(() => new FooterViewModel(context.WithComposition(context.Home)));
			//HomeLazy = context.Home.ToViewModel<HomeViewModel>();
			Home = context.Home;
			PageUrl = context.Page.Url;
			CurrentCulture = context.Home.GetCultureFromDomains();
			GoogleTagManagerScriptCodeLazy = new Lazy<string>(() => context.Home.GoogleTagManagerScriptCode);
            GoogleTagManagerNonScriptCodeLazy = new Lazy<string>(() => context.Home.GoogleTagManagerNonScriptCode);
            GoogleAnalyticsCodeLazy = new Lazy<string>(() => context.Home.GoogleAnalyticsScriptCode);
        }

        public MetaTagsViewModel MetaTags => MetaTagsLazy.Value;
        public HeaderViewModel Header => HeaderLazy.Value;
        public FooterViewModel Footer => FooterLazy.Value;

		public Home Home { get; }
		public string PageUrl { get; }
		public string CurrentCulture { get; }

		public string GoogleTagManagerScriptCode => GoogleTagManagerScriptCodeLazy.Value;
        public string GoogleTagManagerNonScriptCode => GoogleTagManagerNonScriptCodeLazy.Value;
        public string GoogleAnalyticsCode => GoogleAnalyticsCodeLazy.Value;

        private Lazy<MetaTagsViewModel> MetaTagsLazy { get; }
        private Lazy<HeaderViewModel> HeaderLazy { get; }
        private Lazy<FooterViewModel> FooterLazy { get; }
		//private Lazy<HomeViewModel> HomeLazy { get; }

		private Lazy<string> GoogleTagManagerScriptCodeLazy { get; }
        private Lazy<string> GoogleTagManagerNonScriptCodeLazy { get; }
        private Lazy<string> GoogleAnalyticsCodeLazy { get; }

	}
}