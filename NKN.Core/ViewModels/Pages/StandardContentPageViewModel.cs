using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Partials.NestedContent;
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
            //Banner = new BannerViewModel(context.WithComposition(context.Page));
            Items = context.Page.ContentBlocks?.OfType<INestedContent>().Select(m => context.WithNestedContent(m).AsViewModel<INestedContentViewModel>()).ToList();
        }

        //public BannerViewModel Banner { get; }
        public IList<INestedContentViewModel> Items { get; }
    }
}
