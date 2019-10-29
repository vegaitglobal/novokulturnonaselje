using Umbraco.Core.Models.PublishedContent;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace NKN.Models.Generated
{
	public partial class DetailsPage
	{
		[ImplementPropertyType("smallImage")]
		public Image SmallImage => this.Value<IPublishedContent>("smallImage") as Image;
	}
}
