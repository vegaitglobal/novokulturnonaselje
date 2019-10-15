using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class BannerSlideViewModel : INestedContentViewModel
    {
        public BannerSlideViewModel(INestedContentContext<BannerSlide> context)
        {
            BackgroundImage = new ImageViewModel(context.NestedContent.BackgroundImage as Image);
            Title = context.NestedContent.Title;
            Text = context.NestedContent.Text;
            Link = context.NestedContent.Link?.ToViewModel();
        }

        public ImageViewModel BackgroundImage { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public LinkViewModel Link { get; private set; }
    }
}