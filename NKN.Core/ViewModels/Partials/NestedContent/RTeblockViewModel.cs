using NKN.Core.Contexts;
using NKN.Models.Generated;
using System.Web;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class RTeblockViewModel : INestedContentViewModel
    {
        public RTeblockViewModel(INestedContentContext<RTeblock> context)
        {
            Text = context.NestedContent.Text;
        }

        public IHtmlString Text { get; }
    }
}
