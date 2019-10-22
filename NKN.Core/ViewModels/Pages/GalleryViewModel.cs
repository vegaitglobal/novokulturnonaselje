using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Partials.Layout;
using NKN.Core.ViewModels.Partials.NestedContent;
using NKN.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.ViewModels.Pages
{
    public class GalleryViewModel : PageViewModel
    {
        public GalleryViewModel(IPageContext<Gallery> context) : base(context)
        {
			ImageAlbums = context.Page.AllAlbums?.ToList();
			Banner = new BannerViewModel(context.WithComposition((context.Page)));
			VideoItems = context.Page.VideoItems?.Select(i => context.WithNestedContent(i).ToViewModel<VideoGalleryItemViewModel>()).ToList();
			VideoGalleryTitle = context.Page.VideoGalleryTitle;
			ImageGalleryTitle = context.Page.ImageGalleryTitle;
			ContactBlock = context.WithNestedContent(context.Page.ContactUs?.FirstOrDefault()).AsViewModel<WriteUsViewModel>();

		}

		public BannerViewModel Banner { get; }
		public WriteUsViewModel ContactBlock { get; }
		#region Albums
		public string ImageGalleryTitle { get; }
		public IEnumerable<GalleryDetails> ImageAlbums { get; }
		#endregion

		#region VideoSection
		public string VideoGalleryTitle { get; }
		public IEnumerable<VideoGalleryItemViewModel> VideoItems { get; }
		#endregion

		
    }
}