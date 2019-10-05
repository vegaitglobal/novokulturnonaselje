using Umbraco.Web.Mvc;
using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Models.Generated;

namespace NKN.Core.Controllers.RenderMvc
{
    public abstract class BasePageController<T> : RenderMvcController where T : class, IPage
    {
        protected IPageContext<T> CreatePageContext(T page)
        {
            return Umbraco.CreatePageContext(page);
        }
    }
}