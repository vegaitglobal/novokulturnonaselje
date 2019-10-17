using NKN.Core.Contexts;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class WriteUsViewModel : INestedContentViewModel
    {
        public WriteUsViewModel(INestedContentContext<WriteUs> context)
        {
            Title = context.NestedContent.Title;
            BackgroundImage = context.NestedContent.BackgroundImage != null
                ? new ImageViewModel(context.NestedContent.BackgroundImage as Image)
                : null;
        }

        public string Title { get; private set; }
        public ImageViewModel BackgroundImage { get; private set; }
 
    }
}