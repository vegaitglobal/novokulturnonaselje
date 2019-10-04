using System.Web.Mvc;
using Umbraco.Web.Mvc;
using NKN.Core.ViewModels.Pages;
using NKN.Models.DocumentTypes;

namespace NKN.Core.Controllers.RenderMvc
{
	public class XMLSitemapController : RenderMvcController
	{
		public ActionResult XMLSitemap(IDomainRoot model)
			=> CurrentTemplate(new XMLSitemapViewModel(model));
	}
}
