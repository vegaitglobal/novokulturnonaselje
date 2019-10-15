using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using System.Web;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class ImageWithRtetextViewModel : INestedContentViewModel
    {
        public ImageWithRtetextViewModel(INestedContentContext<ImageWithRtetext> context)
        {
            Image = (context.NestedContent.Image as Image).ToViewModel();
			IsImageRight = context.NestedContent.IsImageRight;
            Text = context.NestedContent.Text;
        }

        public ImageViewModel Image { get; private set; }
		public bool IsImageRight { get; }
        public IHtmlString Text { get; private set; }
    }
}
