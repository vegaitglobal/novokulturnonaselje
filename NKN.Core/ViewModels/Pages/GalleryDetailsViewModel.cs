using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Partials.Layout;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.ViewModels.Pages
{
	public class GalleryDetailsViewModel : PageViewModel
	{
		public GalleryDetailsViewModel(IPageContext<GalleryDetails> context) : base(context)
		{
			Banner = new BannerViewModel(context.WithComposition(context.Page));
			Images = context.Page.Images?.Select(i => i as Image).ToViewModel<ImageViewModel>().ToList();
			PageTitle = context.Page.PageTitle;
		}
		public BannerViewModel Banner { get; }
		public IEnumerable<ImageViewModel> Images { get; }
		public string PageTitle { get; }

	}
}
