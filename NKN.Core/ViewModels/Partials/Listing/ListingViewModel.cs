using System;
using System.Collections.Generic;
using NKN.Core.Models;

namespace NKN.Core.ViewModels.Partials.Listing
{
	public class ListingViewModel<T>
	{
		public ListingViewModel(IReadOnlyPagedCollection<T> pagedCollection)
		{
			if (pagedCollection == null) throw new ArgumentNullException(nameof(pagedCollection));

			Items = pagedCollection.Items;
			Pagination = new PaginationViewModel(pagedCollection.Pagination);
		}

		public IReadOnlyList<T> Items { get; }
		public PaginationViewModel Pagination { get; }
	}
}
