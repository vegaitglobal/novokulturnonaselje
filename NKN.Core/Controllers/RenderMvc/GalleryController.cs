using NKN.Core.ViewModels.Pages;
using NKN.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NKN.Core.Controllers.RenderMvc
{
    public class GalleryController : BasePageController<Gallery>
    {
        public ActionResult Index(Gallery model)
        {
            return CurrentTemplate(new GalleryViewModel(CreatePageContext(model)));
        }
    }
}
