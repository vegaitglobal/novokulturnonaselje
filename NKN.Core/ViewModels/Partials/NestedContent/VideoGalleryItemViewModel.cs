using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
	public class VideoGalleryItemViewModel : INestedContentViewModel
	{
		public VideoGalleryItemViewModel(INestedContentContext<VideoGalleryItem> context)
		{
			Title = context.NestedContent.Title;
			VideoUrl = context.NestedContent.VideoUrl;
			CoverImage = (context.NestedContent.VideoCoverImage as Image).ToViewModel();
		}
		public string Title { get; }
		public string VideoUrl { get; }
		public ImageViewModel CoverImage { get; }
	}
}
