using NKN.Core.ViewModels.Pages;
using NKN.Models.Generated;
using System.Web.Mvc;

namespace NKN.Core.Controllers.RenderMvc
{
    public class StandardContentPageController : BasePageController<StandardContentPage>
    {
        public ActionResult Index(StandardContentPage model)
            => CurrentTemplate(new StandardContentPageViewModel(CreatePageContext(model)));
    }
}
