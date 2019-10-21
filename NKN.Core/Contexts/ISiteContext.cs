using NKN.Models.Generated;
using System.Collections.Generic;

namespace NKN.Core.Contexts
{
    public interface ISiteContext
    {
        IPage CurrentPage { get; }
        Home Home { get; }
        ISiteSettings SiteSettings { get; }
		IEnumerable<NewsDetails> LatestNews { get; }
	}
}