using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class FourHighlightedItemsBlockViewModel : INestedContentViewModel
    {
        public FourHighlightedItemsBlockViewModel(INestedContentContext<FourHighlightedItemsBlock> context)
        {
            HighlightedItems = context.NestedContent.HighlightedItems
                .Select(hi => context.WithNestedContent(hi).AsViewModel<HighlightedItemViewModel>())
                .ToList();
        }

        public string Title { get; private set; }
        public IEnumerable<HighlightedItemViewModel> HighlightedItems { get; private set; }
    }
}