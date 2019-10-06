using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Partials.NestedContent;
using NKN.Models.Generated;
using System.Collections.Generic;

namespace NKN.Core.ViewModels.Pages
{
    public class GalleryViewModel : PageViewModel
    {
        public GalleryViewModel(IPageContext<Gallery> context) : base(context)
        {
            ImageAlbums = context.Page.AllAlbums.ToViewModel<ImageAlbumViewModel>();
            VideoLinks = context.Page.VideoLinks;
        }

        public IEnumerable<ImageAlbumViewModel> ImageAlbums { get; set; }
        public IEnumerable<string> VideoLinks { get; set; }
    }
}