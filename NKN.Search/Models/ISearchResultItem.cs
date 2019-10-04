using Umbraco.Core.Models.PublishedContent;

namespace NKN.Search.Models
{
    public interface ISearchResultItem : IPublishedContent
    {
        /// <summary>
        /// Returns search item title.
        /// </summary>
        /// <returns></returns>
        string GetTitle();

        /// <summary>
        /// Returns search item summary text.
        /// </summary>
        /// <returns></returns>
        string GetSummaryText();

        /// <summary>
        /// Returns search item url.
        /// </summary>
        /// <returns></returns>
        string GetUrl();
    }
}