using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.ViewModels.Pages
{
    public class ProjectCategoryLandingViewModel : PageViewModel
    {
        public ProjectCategoryLandingViewModel(IPageContext<ProjectCategoryLanding> context) : base(context)
        {
            PageTitle = context.Page.PageTitle;
            BannerImage = (context.Page.BannerImage as Image).ToViewModel();
            Image = (context.Page.Image as Image).ToViewModel();
            Text = context.Page.Text.ToHtmlString();
            AllProjects = context.Page.AllProjects.ToViewModel<ProjectDetailPreviewViewModel>().OrderBy(project => project.ReleaseDate);
        }

        public string PageTitle { get; private set; }
        public ImageViewModel BannerImage { get; private set; }
        public ImageViewModel Image { get; private set; }
        public string Text { get; private set; }
        public IEnumerable<ProjectDetailPreviewViewModel> AllProjects { get; }
    }
}
