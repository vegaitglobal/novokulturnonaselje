using NKN.Core.ViewModels.Pages;
using System.Web.Mvc;

namespace NKN.Core.Controllers.Surface.Partials
{
	public class NewsArchiveController : BaseSurfaceController
	{

		public ActionResult NewsArchive()
		{
			TempData[Constants.Constants.TempDataArchiveNews] = "true";

		
			return RedirectToCurrentUmbracoPage();
		}
	}
}
