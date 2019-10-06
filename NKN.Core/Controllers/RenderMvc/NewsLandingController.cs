using NKN.Core.ViewModels.Pages;
using NKN.Models.Generated;
using System.Web.Mvc;

namespace NKN.Core.Controllers.RenderMvc
{
    public class NewsLandingController : BasePageController<NewsLanding>
    {
        public ActionResult Index(NewsLanding model) 
            => CurrentTemplate(new NewsLandingViewModel(CreatePageContext(model)));
    }
}
