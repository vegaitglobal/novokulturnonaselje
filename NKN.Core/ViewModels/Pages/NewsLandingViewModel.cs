using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Partials.NestedContent;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Extensions;
using NKN.Models.Generated;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.ViewModels.Pages
{
    public class NewsLandingViewModel : PageViewModel
    {
        public NewsLandingViewModel(IPageContext<NewsLanding> context) : base(context)
        {
            PageTitle = context.Page.PageTitle;
            BannerImage = (context.Page.FullWithBanner as Image).ToViewModel();
            NewsPreviews = context.Page.Descendants<NewsDetail>(desc => true)
                .Select(nd => new NewsDetailPreviewViewModel(nd))
                .ToList()
                .OrderByDescending(n => n.ReleaseDate);
        }

        public string PageTitle { get; private set; }
        public ImageViewModel BannerImage { get; private set; }

        public IEnumerable<NewsDetailPreviewViewModel> NewsPreviews { get; private set; }
    }
}
