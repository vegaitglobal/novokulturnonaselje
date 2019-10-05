using NKN.Core.Contexts;
using NKN.Core.Extensions;
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
            PageTitle = context.Page.PageTitle;
            BannerImage = new ImageViewModel(context.Page.BannerImage as Image);
            Image = new ImageViewModel(context.Page.Image as Image);
            ContactInfo = HttpUtility.HtmlDecode(context.Page.ContactInfo);
            WriteUs = context.WithNestedContent(context.Page.WriteUs?.First()).AsViewModel<WriteUsViewModel>();
        }

        public string PageTitle { get; private set; }
        public ImageViewModel BannerImage { get; private set; }
        public ImageViewModel Image { get; private set; }
        public string ContactInfo { get; private set; }
        public WriteUsViewModel WriteUs { get; private set; }
    }
}