using System;
using NKN.Core.Contexts;
using NKN.Models.DocumentTypes;

namespace NKN.Core.Extensions
{
	public static class SiteContextExtensions
	{
		public static ISeoContext<T> CreateSeoContext<T>(this ISiteContext context, T seo) where T : class, ISeo
		{
			if (seo == null) return default(ISeoContext<T>);

			return (ISeoContext<T>) Activator.CreateInstance(typeof(SeoContext<>).MakeGenericType(seo.GetType()), seo, context);
		}
	}
}
