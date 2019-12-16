using NKN.Models.Extensions;
using System.Collections.Generic;
using System.Linq;
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

		[ImplementPropertyType("sectionOneItems")]
		public IEnumerable<DetailsPage> SectionOneItems => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<DetailsPage>();

		[ImplementPropertyType("sectionTwoItems")]
		public IEnumerable<DetailsPage> SectionTwoItems => this.GetPropertyValue<IEnumerable<IPublishedContent>>()?.OfType<DetailsPage>();
	}
}
