using NKN.Core.Contexts;
using NKN.Models.Generated;
using System.Web;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class RCeblockViewModel : INestedContentViewModel
    {
        public RCeblockViewModel(INestedContentContext<RCeblock> context)
        {
            Text = context.NestedContent.Text;
        }

        public IHtmlString Text { get; }
    }
}
