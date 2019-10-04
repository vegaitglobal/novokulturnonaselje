using System;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.Models
{
	public class Pagination : IPagination
	{
		public Pagination(int page, long totalResults, int itemsPerPage, Uri currentUri)
		{
			if (page <= 0) throw new ArgumentOutOfRangeException(nameof(page));
			if (totalResults < 0) throw new ArgumentOutOfRangeException(nameof(totalResults));
			if (itemsPerPage <= 0) throw new ArgumentOutOfRangeException(nameof(itemsPerPage));
			
			Page = page;
			TotalResults = totalResults;
			TotalPages = (int) Math.Ceiling((double) totalResults / itemsPerPage);
			Pages = GetPages(currentUri).ToList();
		}

		public int Page { get; }
		public int TotalPages { get; }
		public long TotalResults { get; }
		public IReadOnlyList<Page> Pages { get; }

		public bool HasPreviousPage()
		{
			return Page > 1;
		}

		public bool HasNextPage()
		{
			return Page < TotalPages;
		}

		private IEnumerable<Page> GetPages(Uri currentUri)
		{
			for (int i = 1; i <= TotalPages; i++)
			{
				yield return new Page(i, i == Page, currentUri);
			}
		}
	}
}
