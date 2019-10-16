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
    public class HomeViewModel : PageViewModel
    {
        public HomeViewModel(IPageContext<Home> context) : base(context)
        {
            ContentBlocks = context.Page.ContentBlocks?
                .Select(cb => cb as INestedContent)
                .Select(m => context.WithNestedContent(m).ToViewModel<INestedContentViewModel>())
                .ToList();
        }

        public IEnumerable<INestedContentViewModel> ContentBlocks { get; private set; }
    }
}