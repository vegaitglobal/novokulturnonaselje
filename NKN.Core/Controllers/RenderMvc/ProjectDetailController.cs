using NKN.Core.ViewModels.Pages;
using NKN.Models.Generated;
using System.Web.Mvc;

namespace NKN.Core.Controllers.RenderMvc
{
    public class ProjectDetailController : BasePageController<ProjectDetail>
    {
        public ActionResult Index(ProjectDetail model)
            => CurrentTemplate(new StandardContentPageViewModel(CreatePageContext(model)));
    }
}
