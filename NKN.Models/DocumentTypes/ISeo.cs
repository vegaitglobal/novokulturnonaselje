using NKN.Models.Generated;
using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace NKN.Models.DocumentTypes
{
    public interface ISeo : IPublishedContent
    {
        string SeoTitle { get; }
        string SeoDescription { get; }
        string SeoKeywords { get; }
        bool HideFromSearchEngines { get; }
        string SitemapChangeFrequency { get; }
        string SitemapPriority { get; }
        IEnumerable<string> AlternateLanguages { get; }
        Link CanonicalLink { get; }
		
	}
}