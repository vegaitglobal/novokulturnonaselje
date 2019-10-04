using System;
using NKN.Core.Models;

namespace NKN.Core.ViewModels.Partials.Listing
{
	public class PaginationViewModel
	{
		public PaginationViewModel(IPagination pagination)
		{
			Pagination = pagination ?? throw new ArgumentNullException(nameof(pagination));
		}

		public IPagination Pagination { get; }
	}
}
