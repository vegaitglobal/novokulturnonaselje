using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Partials.NestedContent;
using NKN.Core.ViewModels.Shared;
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
            PageTitle = context.Page.PageTitle;
            BannerImage = (context.Page.BannerImage as Image).ToViewModel();
            NewsPreviews = context.Page.Descendants<NewsContainer>(nd => true)
                .Select(nc => nc.Descendants<NewsDetail>(nd => true))
                .SelectMany(nd => nd)
                .Where(nd => nd.Id != context.Page.HighlightedNews.Id)
                .OrderByDescending(nd => nd.ReleaseDate)
                .Select(nd => new NewsDetailPreviewViewModel(nd))
                .ToArray();

            HighlightedNewsPreview = new NewsDetailPreviewViewModel(context.Page.HighlightedNews as NewsDetail);
          
        }

        public string PageTitle { get; private set; }
        public ImageViewModel BannerImage { get; private set; }

        public IEnumerable<NewsDetailPreviewViewModel> NewsPreviews { get; private set; }
        public NewsDetailPreviewViewModel HighlightedNewsPreview { get; private set; }
    }
}