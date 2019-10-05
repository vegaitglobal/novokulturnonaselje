using System.Collections.Generic;
using NKN.Models.DocumentTypes;

namespace NKN.Models.Extensions
{
    /// <summary>
    /// <see cref="IDomainRoot"/> extension methods.
    /// </summary>
    public static class DomainRootExtensions
    {
        /// <summary>
        /// Returns Search Engines Sitemap i.e. Sitemap XML items from the provided <paramref name="domain"/> node.
        /// </summary>
        /// <typeparam name="T">Type of sitemap pages to return.</typeparam>
        /// <param name="domain">Domain root node.</param>
        /// <param name="maxLevel">The max level of pages to include in sitemap.</param>
        /// <returns>Sitemap XML items.</returns>
        public static IEnumerable<T> GetSitemapXMLItems<T>(this IDomainRoot domain, int maxLevel = 100)
            where T : class, ISeo
        {
            return domain.DescendantsOrSelf<T>(d => d.Level <= maxLevel && !d.HideFromSearchEngines);
        }
    }
}