using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class EmbeddedVideoBlockViewModel : INestedContentViewModel
    {
        public EmbeddedVideoBlockViewModel(INestedContentContext<EmbeddedVideoBlock> context)
        {
            Link = context.NestedContent.Link;
			Title = context.NestedContent.Title;
			VideoCoverImage = (context.NestedContent.VideoCoverImage as Image)?.ToViewModel();
        }

        public string Link { get; }
		public string Title { get; }
		public ImageViewModel VideoCoverImage { get; }
    }
}
