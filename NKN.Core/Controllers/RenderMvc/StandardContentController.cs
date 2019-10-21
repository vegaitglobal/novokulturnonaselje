using NKN.Core.ViewModels.Pages;
using NKN.Models.Generated;
using System.Web.Mvc;

namespace NKN.Core.Controllers.RenderMvc
{
	public class StandardContentController : BasePageController<StandardContent>
	{
		public ActionResult Index(StandardContent model)
			=> CurrentTemplate(new StandardContentViewModel(CreatePageContext(model)));
	}
}
