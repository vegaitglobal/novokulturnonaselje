using NKN.Models.DocumentTypes;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace NKN.Models.Generated
{
    public partial class EmbeddedVideoBlock : PublishedElementModel, INestedContent
    {
		[ImplementPropertyType("videoCoverImage")]
		public Image VideoCoverImage => this.Value<IPublishedContent>("videoCoverImage") as Image;
	}
}
