using NKN.Core.ViewModels.Pages;
using NKN.Models.Generated;
using System.Web.Mvc;

namespace NKN.Core.Controllers.RenderMvc
{
    class ProjectCategoryLandingController : BasePageController<ProjectCategoryLanding>
    {
        public ActionResult Index(ProjectCategoryLanding model) => 
            CurrentTemplate(new ProjectCategoryLandingViewModel(CreatePageContext(model)));
    }
}
