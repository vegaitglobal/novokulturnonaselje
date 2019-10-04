using System;
using System.Collections.Generic;

namespace NKN.Core.Models
{
	public class ReadOnlyPagedCollection<T> : IReadOnlyPagedCollection<T> where T : class 
	{
		public ReadOnlyPagedCollection(IReadOnlyList<T> items, IPagination pagination)
		{
			Items = items ?? throw new ArgumentNullException(nameof(items));
			Pagination = pagination ?? throw new ArgumentNullException(nameof(pagination));
		}

		public IReadOnlyList<T> Items { get; }
		public IPagination Pagination { get; }
	}
}
