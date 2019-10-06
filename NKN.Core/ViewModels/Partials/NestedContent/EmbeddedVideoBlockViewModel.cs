using NKN.Core.Contexts;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class EmbeddedVideoBlockViewModel : INestedContentViewModel
    {
        public EmbeddedVideoBlockViewModel(INestedContentContext<EmbeddedVideoBlock> context)
        {
            Link = context.NestedContent.Link;
        }

        public string Link { get; }
    }
}
