using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class HighlightedItemViewModel : INestedContentViewModel
    {
        public HighlightedItemViewModel(INestedContentContext<HighlightedItem> model)
        {
            Image = (model.NestedContent.Image as Image).ToViewModel();
            ImageHover = (model.NestedContent.ImageHover as Image).ToViewModel();
            Link = model.NestedContent.Link?.ToViewModel();
            Text = model.NestedContent.Text;
            Title = model.NestedContent.Title;
			HideLink = model.NestedContent.HideLink;
        }

        public ImageViewModel Image { get; }
        public ImageViewModel ImageHover { get; }
        public LinkViewModel Link { get; }
		public bool HideLink { get; }
        public string Text { get; }
        public string Title { get; }

    }
}