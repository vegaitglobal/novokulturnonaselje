using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
	public class ImageAndVideoBlockViewModel : INestedContentViewModel
	{
		public ImageAndVideoBlockViewModel(INestedContentContext<ImageAndVideoBlock> context)
		{
			SectionTitle = context.NestedContent.SectionTitle;
			BackgroungImage = (context.NestedContent.BackgroundImage as Image).ToViewModel();
			ImageBlockTitle = context.NestedContent.ImageBlockTitle;
			Images = context.NestedContent.Images?.Select(i => i as Image).ToViewModel<ImageViewModel>().ToList();
			VideoSectionTitle = context.NestedContent.VideoSectionTitle;
			VideoItems = context.NestedContent.VideoItems?.Select(i => context.WithNestedContent(i).ToViewModel<VideoGalleryItemViewModel>()).ToList();
		}
		public string SectionTitle { get; }
		public ImageViewModel BackgroungImage { get; }
		public string ImageBlockTitle { get; }
		public IList<ImageViewModel> Images { get; }
		public string VideoSectionTitle { get; }
		public IList<VideoGalleryItemViewModel> VideoItems { get; }
	}
}
