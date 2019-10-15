using NKN.Models.DocumentTypes.Compositions;
using NKN.Models.Generated;
using System;

namespace NKN.Core.Contexts
{
	public class CompositionContext<T> : ICompositionContext<T> where T : class, ICompositions
	{
		public CompositionContext(T composition, ISiteContext siteContext)
		{
			Composition = composition ?? throw new ArgumentNullException(nameof(composition));
			SiteContext = siteContext ?? throw new ArgumentNullException(nameof(siteContext));
		}

		public T Composition { get; }
		public IPage CurrentPage => SiteContext.CurrentPage;
		public Home Home => SiteContext.Home;
		public ISiteSettings SiteSettings => SiteContext.SiteSettings;

		private ISiteContext SiteContext { get; }
	}
}
