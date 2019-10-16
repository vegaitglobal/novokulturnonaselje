using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Partials.Layout;
using NKN.Core.ViewModels.Partials.NestedContent;
using NKN.Models.Extensions;
using NKN.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.ViewModels.Pages
{
    public class NewsLandingViewModel : PageViewModel
    {
        public NewsLandingViewModel(IPageContext<NewsLanding> context) : base(context)
        {
			Banner = new BannerViewModel(context.WithComposition(context.Page));
            NewsPreviews = context.Page.Descendants<NewsContainer>(nd => true)
                .Select(nc => nc.Descendants<NewsDetails>(nd => true))
                .SelectMany(nd => nd)
                .Where(nd => nd.Id != context.Page.HighlightedNews.Id)
                .OrderByDescending(nd => nd.ReleaseDate)
                .Select(nd => new NewsDetailPreviewViewModel(nd))
                .ToArray();

            HighlightedNewsPreview = new NewsDetailPreviewViewModel(context.Page.HighlightedNews as NewsDetails);
          
        }
		
		public BannerViewModel Banner { get; set; }

        public IEnumerable<NewsDetailPreviewViewModel> NewsPreviews { get; private set; }
        public NewsDetailPreviewViewModel HighlightedNewsPreview { get; private set; }
    }
}