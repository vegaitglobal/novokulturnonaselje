using System.Web.Mvc;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Pages;
using NKN.Models.Generated;

namespace NKN.Core.Controllers.RenderMvc
{
	public class SearchResultsController : BasePageController<SearchResults>
	{
		public ActionResult Index(SearchResults model)
			=> CurrentTemplate(
				new SearchResultsViewModel(CreatePageContext(model), 
				Request.GetQueryParameter(),
				Request.GetPageParameter()));
	}
}
