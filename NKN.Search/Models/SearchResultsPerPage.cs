using System;
using System.Collections.Generic;

namespace NKN.Search.Models
{
	public class SearchResultsPerPage
	{
		public SearchResultsPerPage(long totalResults, IEnumerable<ISearchResultItem> items)
		{
			if (totalResults < 0) throw new ArgumentOutOfRangeException(nameof(totalResults));

			TotalResults = totalResults;
			Items = items ?? throw new ArgumentNullException(nameof(items));
		}

		public long TotalResults { get; }
		public IEnumerable<ISearchResultItem> Items { get; }
	}
}
