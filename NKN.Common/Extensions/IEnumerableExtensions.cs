using System.Collections.Generic;
using System.Linq;

namespace NKN.Common.Extensions
{
	public static class IEnumerableExtensions
	{
		/// <summary>
		/// Flattens <paramref name="source"/> tree hierarchy to linear sequence based on provided <paramref name="childSelector"/>.
		/// </summary>
		/// <typeparam name="T">Sequence elements type.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="childSelector">Child elements selector.</param>
		/// <returns>Whole <paramref name="source"/> tree hierarchy as linear sequence.</returns>
		public static IReadOnlyList<T> AsList<T>(this IEnumerable<T> source)
		{
			if (source == null) return new List<T>();

			return source as List<T> ?? source.ToList();
		}

		/// <summary>
		/// Return empty enumerable collection if source is null.
		/// </summary>
		/// <typeparam name="T">The type.</typeparam>
		/// <param name="source">The source.</param>
		/// <returns></returns>
		public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
		{
			return source ?? Enumerable.Empty<T>();
		}
	}
}
