using NKN.Core.ViewModels.Pages;
using NKN.Models.Generated;
using System.Web.Mvc;

namespace NKN.Core.Controllers.RenderMvc
{
    public class NewsDetailController : BasePageController<NewsDetails>
    {
        public ActionResult Index(NewsDetails model)
            => CurrentTemplate(new StandardContentPageViewModel(CreatePageContext(model)));
    }
}
