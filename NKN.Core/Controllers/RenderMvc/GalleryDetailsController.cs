using NKN.Core.ViewModels.Pages;
using NKN.Models.Generated;
using System.Web.Mvc;

namespace NKN.Core.Controllers.RenderMvc
{
	public class GalleryDetailsController : BasePageController<GalleryDetails>
	{
		public ActionResult Index(GalleryDetails model)
		{
			return CurrentTemplate(new GalleryDetailsViewModel(CreatePageContext(model)));
		}
	}
}
