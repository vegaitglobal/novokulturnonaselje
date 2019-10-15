using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Partials.Layout
{
	public class BannerViewModel 
	{
		public BannerViewModel(ICompositionContext<IBanner> banner)
		{
			BannerImage = (banner.Composition.BannerImage as Image).ToViewModel();
			PageTitle = banner.CurrentPage.PageTitle;
		}
		public ImageViewModel BannerImage { get; }
		public string PageTitle { get; }
	}
	
}
