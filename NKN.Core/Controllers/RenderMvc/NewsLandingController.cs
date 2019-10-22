using NKN.Core.ViewModels.Pages;
using NKN.Models.Generated;
using NKN.Common;
using System.Web.Mvc;

namespace NKN.Core.Controllers.RenderMvc
{
    public class NewsLandingController : BasePageController<NewsLanding>
    {
		public ActionResult Index(NewsLanding model)
		{
			bool isArchive = Request.QueryString[Common.Constants.RequestParameters.Query] == "archive";
			NewsLandingViewModel page = new NewsLandingViewModel(CreatePageContext(model));
			page.IsArchive = isArchive;
			return CurrentTemplate(page);
		}
    }
}
