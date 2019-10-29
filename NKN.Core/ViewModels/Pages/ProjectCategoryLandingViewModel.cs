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
            AllProjects = context.Page.AllProjects?.ToViewModel<DetailsPagePreviewViewModel>().OrderBy(project => project.ReleaseDate);
			FutureProjects = context.Page.Items?.Select(fp => context.WithNestedContent(fp).ToViewModel<FutureProjectItemViewModel>()).ToList();
		}
		public BannerViewModel Banner { get; set; }
        public ImageViewModel Image { get; private set; }
        public IHtmlString Text { get; private set; }
        public IEnumerable<DetailsPagePreviewViewModel> AllProjects { get; }
		public IEnumerable<FutureProjectItemViewModel> FutureProjects { get; }
    }
}
