using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Partials.Layout;
using NKN.Core.ViewModels.Partials.NestedContent;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using System.Linq;
using System.Web;

namespace NKN.Core.ViewModels.Pages
{
    public class ContactViewModel : PageViewModel
    {
        public ContactViewModel(IPageContext<Contact> context) : base(context)
		{

			Banner = new BannerViewModel(context.WithComposition(context.Page));
            Image = (context.Page.Image as Image).ToViewModel();
            ContactInfo = HttpUtility.HtmlDecode(context.Page.ContactInfo?.ToHtmlString());
            WriteUs = context.WithNestedContent(context.Page.WriteUs?.FirstOrDefault()).AsViewModel<WriteUsViewModel>();
        }

        public ImageViewModel Image { get; private set; }
        public string ContactInfo { get; private set; }
        public WriteUsViewModel WriteUs { get; private set; }

		public BannerViewModel Banner { get; }
    }
}