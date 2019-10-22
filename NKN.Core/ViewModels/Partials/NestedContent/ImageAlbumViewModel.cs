using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class ImageAlbumViewModel
    {
        public ImageAlbumViewModel(ImageAlbum model)
        {
            Title = model.Title;
            Images = model.Images?.Select(image => (image as Image).ToViewModel());
        }

        public string Title { get; set; }
        public IEnumerable<ImageViewModel> Images { get; set; }
    }
}
