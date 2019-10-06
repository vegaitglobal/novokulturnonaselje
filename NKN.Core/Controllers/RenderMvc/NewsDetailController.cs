using NKN.Core.ViewModels.Pages;
using NKN.Models.Generated;
using System.Web.Mvc;

namespace NKN.Core.Controllers.RenderMvc
{
    public class NewsDetailController : BasePageController<NewsDetail>
    {
        public ActionResult Index(NewsDetail model)
            => CurrentTemplate(new StandardContentPageViewModel(CreatePageContext(model)));
    }
}
