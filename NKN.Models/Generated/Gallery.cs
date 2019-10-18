using NKN.Models.Extensions;
using System.Collections.Generic;
using Umbraco.Web;

namespace NKN.Models.Generated
{
    public partial class Gallery
    {
        public IEnumerable<GalleryDetails> AllAlbums => this.Descendants<GalleryDetails>();
    }
}
