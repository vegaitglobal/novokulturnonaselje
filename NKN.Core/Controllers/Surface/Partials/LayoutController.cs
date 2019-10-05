using System.Web.Mvc;
using NKN.Core.ViewModels.Partials.Layout;

namespace NKN.Core.Controllers.Surface.Partials
{
    public class LayoutController : BaseSurfaceController
    {
        [ChildActionOnly]
        public ActionResult MetaTags(MetaTagsViewModel viewModel)
        {
            return PartialView(viewModel);
        }

        [ChildActionOnly]
        public ActionResult Header(HeaderViewModel viewModel)
        {
            return PartialView(viewModel);
        }

        [ChildActionOnly]
        public ActionResult Footer(FooterViewModel viewModel)
        {
            return PartialView(viewModel);
        }
    }
}