using NKN.Core.Extensions;
using NKN.Core.ViewModels.Partials.NestedContent;
using System.Web.Mvc;

namespace NKN.Core.Controllers.Surface.Partials
{
    public class NestedContentController : BaseSurfaceController
    {
        public ActionResult Index(INestedContentViewModel viewModel)
        {
            string partialView = viewModel.GetType().Name.RemoveViewModelSuffix();

            return PartialView(partialView, viewModel);
        }
		public ActionResult NewsletterBlock(NewsletterBlockViewModel viewModel)
		{
			return PartialView(viewModel);
		}
	}
}