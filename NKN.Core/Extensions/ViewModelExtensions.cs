﻿using System.Collections.Generic;
using System.Linq;
using NKN.Core.ViewModels.Pages;
using NKN.Core.ViewModels.Partials.Listing;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using NKN.Models.DocumentTypes;
using NKN.Search.Models;

namespace NKN.Core.Extensions
{
	public static class ViewModelExtensions
	{
		public static ImageViewModel ToViewModel(this Image image)
			=> image != null ? new ImageViewModel(image) : default(ImageViewModel);

		public static XMLSitemapItemViewModel ToViewModel(this ISeo page)
			=> page != null ? new XMLSitemapItemViewModel(page) : default(XMLSitemapItemViewModel);

		public static SearchResultsItemViewModel ToViewModel(this ISearchResultItem item)
			=> new SearchResultsItemViewModel(item);

		public static IEnumerable<SearchResultsItemViewModel> ToViewModel(this IEnumerable<ISearchResultItem> items)
		{
			if (items == null) return Enumerable.Empty<SearchResultsItemViewModel>();

			return items.Select(ToViewModel);
		}
	}
}
