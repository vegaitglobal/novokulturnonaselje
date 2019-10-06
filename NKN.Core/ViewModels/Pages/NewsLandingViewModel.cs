using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Pages
{
    public class NewsLandingViewModel : PageViewModel
    {
        public NewsLandingViewModel(IPageContext<NewsLanding> context) : base(context)
        {
            PageTitle = context.Page.PageTitle;
            BannerImage = (context.Page.FullWithBanner as Image).ToViewModel();
        }

        public string PageTitle { get; private set; }
        public ImageViewModel BannerImage { get; private set; }
    }
}
