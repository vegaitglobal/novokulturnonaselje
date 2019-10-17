using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class GallerySimpleBlockViewModel : INestedContentViewModel
    {
        public GallerySimpleBlockViewModel(INestedContentContext<GallerySimpleBlock> context)
        {
            Images = context.NestedContent.Images?.Select(image => (image as Image).ToViewModel());
        }

        public IEnumerable<ImageViewModel> Images { get; }
    }
}
