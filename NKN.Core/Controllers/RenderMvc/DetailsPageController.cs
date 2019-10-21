using NKN.Core.ViewModels.Pages;
using NKN.Models.Generated;
using System.Web.Mvc;

namespace NKN.Core.Controllers.RenderMvc
{
	public class DetailsPageController : BasePageController<DetailsPage>
	{
		public ActionResult Index(DetailsPage model)
			=> CurrentTemplate(new StandardContentViewModel(CreatePageContext(model)));
	}
}
