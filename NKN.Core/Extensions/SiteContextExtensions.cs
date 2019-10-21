using System;
using NKN.Core.Contexts;
using NKN.Models.DocumentTypes;
using NKN.Models.DocumentTypes.Compositions;
using NKN.Models.Generated;

namespace NKN.Core.Extensions
{
    public static class SiteContextExtensions
    {
        public static ISeoContext<T> CreateSeoContext<T>(this ISiteContext context, T seo) where T : class, ISeo
        {
            if (seo == null) return default(ISeoContext<T>);

            return (ISeoContext<T>) Activator.CreateInstance(typeof(SeoContext<>).MakeGenericType(seo.GetType()), seo,
                context);
        }

		public static IPageContext<T> CreatePageContext<T>(this ISiteContext context, T page) where T : class, IPage
		{
			if (page == null) return default(IPageContext<T>);

			return (IPageContext<T>)Activator.CreateInstance(typeof(PageContext<>).MakeGenericType(page.GetType()), page,
				context);
		}

		public static INestedContentContext<T> WithNestedContent<T>(this ISiteContext siteContext, T nestedContent) where T : class, INestedContent
        {
            if (nestedContent == null) return default(INestedContentContext<T>);

            return (INestedContentContext<T>)Activator.CreateInstance(typeof(NestedContentContext<>).MakeGenericType(nestedContent.GetType()), nestedContent, siteContext);
        }
		public static ICompositionContext<T> WithComposition<T>(this ISiteContext siteContext, T composition)
		where T : class, ICompositions
		{
			if (composition == null) return default(ICompositionContext<T>);

			return (ICompositionContext<T>)Activator.CreateInstance(typeof(CompositionContext<>).MakeGenericType(composition.GetType()), composition, siteContext);
		}
	
	}
}