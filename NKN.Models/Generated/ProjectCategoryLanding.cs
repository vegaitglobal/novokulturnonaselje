using NKN.Models.Extensions;
using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace NKN.Models.Generated
{
    public partial class ProjectCategoryLanding
    {
        public IEnumerable<DetailsPage> AllProjects => this.Descendants<DetailsPage>();

		[ImplementPropertyType("image")]
		public Image Image => this.Value<IPublishedContent>("image") as Image;
	}
}
