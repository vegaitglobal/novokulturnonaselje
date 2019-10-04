using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace NKN.Models.Extensions
{
    /// <summary>
    /// <see cref="IPublishedContent"/> extension methods.
    /// </summary>
    public static class PublishedContentExtensions
    {
        /// <summary>
        /// Checks if <paramref name="source"/> has associated template.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns><c>true</c> if <paramref name="source"/> has associated template, otherwise <c>false</c>.</returns>
        public static bool HasTemplate(this IPublishedContent source)
        {
            return source.TemplateId > 0;
        }

        /// <summary>
        /// Returns children of the <paramref name="source"/>, of the given type <see cref="{T}"/>, that satisfy provided <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="T">Type of the children to return.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate that child has to satisfy.</param>
        /// <returns>Children of given type <see><cref>{T}</cref></see>, that satisfy provided <paramref name="predicate"/>.</returns>
        public static IEnumerable<T> Children<T>(this IPublishedContent source, Func<T, bool> predicate)
            where T : class, IPublishedContent
        {
            return source?.Children<T>().Where(predicate) ?? Enumerable.Empty<T>();
        }

        /// <summary>
        /// Returns descendants of the <paramref name="source"/>, of the given <see cref="{T}"/>, that satisfy provided <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="T">Type of the descendants to return.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate that descendant has to satisfy.</param>
        /// <returns>Descendants of given type <see><cref>{T}</cref></see>, that satisfy provided <paramref name="predicate"/>.</returns>
        public static IEnumerable<T> Descendants<T>(this IPublishedContent source, Func<T, bool> predicate)
            where T : class, IPublishedContent
        {
            return source?.Descendants<T>().Where(predicate) ?? Enumerable.Empty<T>();
        }

        /// <summary>
        /// Returns the <paramref name="source"/> and its descendants, of the given type <see cref="{T}"/>, that satisfy provided <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="T">Type of the descendants to return.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate that descendant has to satisfy.</param>
        /// <returns><paramref name="source"/> and its descendants of given type <see><cref>{T}</cref></see>, that satisfy provided <paramref name="predicate"/>.</returns>
        public static IEnumerable<T> DescendantsOrSelf<T>(this IPublishedContent source, Func<T, bool> predicate)
            where T : class, IPublishedContent
        {
            return source?.DescendantsOrSelf<T>().Where(predicate) ?? Enumerable.Empty<T>();
        }
    }
}