using NKN.Core.ViewModels.Pages;
using NKN.Models.Generated;
using System.Web.Mvc;

namespace NKN.Core.Controllers.RenderMvc
{
    public class ContactController : BasePageController<Contact>
    {
        public ActionResult Index(Contact model)
        {
            return CurrentTemplate(new ContactViewModel(CreatePageContext(model)));
        }
    }
}