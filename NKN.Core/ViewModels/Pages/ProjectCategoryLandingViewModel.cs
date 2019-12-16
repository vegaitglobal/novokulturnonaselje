using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Partials.Layout;
using NKN.Core.ViewModels.Partials.NestedContent;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKN.Core.ViewModels.Pages
{
    public class ProjectCategoryLandingViewModel : PageViewModel
    {
        public ProjectCategoryLandingViewModel(IPageContext<ProjectCategoryLanding> context) : base(context)
        {
			Banner = new BannerViewModel(context.WithComposition(context.Page));
			Image = context.Page.Image?.ToViewModel();
            Text = context.Page.Text;
			SectionOneItems = context.Page.SectionOneItems?.ToViewModel<DetailsPagePreviewViewModel>();
			SectionTwoItems = context.Page.SectionTwoItems?.ToViewModel<DetailsPagePreviewViewModel>();
			SectionOneTitle = context.Page.SectionOneTitle;
			SectionTwoTitle = context.Page.SectionTwoTitle;
		}
		public BannerViewModel Banner { get; set; }
        public ImageViewModel Image { get; private set; }
        public IHtmlString Text { get; private set; }
		public string SectionOneTitle { get; }
		public string SectionTwoTitle { get; }
		public IEnumerable<DetailsPagePreviewViewModel> SectionOneItems { get; }
		public IEnumerable<DetailsPagePreviewViewModel> SectionTwoItems { get; }
	}
}
