using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Partials.NestedContent;
using NKN.Core.ViewModels.Shared;
using NKN.Models.DocumentTypes;
using NKN.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.ViewModels.Pages
{
    public class StandardContentPageViewModel : PageViewModel
    {
        public StandardContentPageViewModel(IPageContext<StandardContentPage> context) : base(context)
        {
            PageTitle = context.Page.PageTitle;
            BannerImage = (context.Page.BannerImage as Image).ToViewModel();
            //Banner = new BannerViewModel(context.WithComposition(context.Page));
            Items = context.Page.ContentBlocks?.OfType<INestedContent>().Select(m => context.WithNestedContent(m).AsViewModel<INestedContentViewModel>()).ToList();
        }

        public string PageTitle { get; private set; }
        public ImageViewModel BannerImage { get; private set; }
        public IList<INestedContentViewModel> Items { get; }
    }
}
