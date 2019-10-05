using System.Web.Mvc;
using NKN.Core.ViewModels.Pages;
using NKN.Models.Generated;

namespace NKN.Core.Controllers.RenderMvc
{
    public class HomeController : BasePageController<Home>
    {
        public ActionResult Index(Home model)
        {
            return CurrentTemplate(new HomeViewModel(CreatePageContext(model)));
        }
    }
}