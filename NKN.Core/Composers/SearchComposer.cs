using Examine;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web;
using NKN.Search.Services;
using NKN.Search.Services.Implementation;

namespace NKN.Core.Composers
{
	public class SearchComposer : IUserComposer
	{
		public void Compose(Composition composition)
		{
			composition.RegisterFor<ISearchService, SearchService>(f => new SearchService(f.GetInstance<IExamineManager>(), f.GetInstance<IUmbracoContextAccessor>()));
		}
	}
}
