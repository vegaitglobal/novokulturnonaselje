using NKN.Core.Contexts;
using NKN.Core.ViewModels.Pages;
using NKN.Core.ViewModels.Partials.Listing;
using NKN.Core.ViewModels.Partials.NestedContent;
using NKN.Core.ViewModels.Shared;
using NKN.Models.DocumentTypes;
using NKN.Models.Generated;
using NKN.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NKN.Core.Extensions
{
    public static class ViewModelExtensions
    {
        public static TNestedContentViewModel AsViewModel<TNestedContentViewModel>(this INestedContentContext<INestedContent> nestedContentContext, string classSuffix = "ViewModel")
           where TNestedContentViewModel : INestedContentViewModel
        {
            if (nestedContentContext == null) return default(TNestedContentViewModel);

            Type baseType = typeof(TNestedContentViewModel);
            string modelTypeName = $"{baseType.Namespace}.{nestedContentContext.NestedContent.GetType().Name}{classSuffix}";

            return (TNestedContentViewModel)Activator.CreateInstance(Assembly.GetAssembly(baseType).GetType(modelTypeName), nestedContentContext);
        }

        public static ImageViewModel ToViewModel(this Image image)
        {
            return image != null ? new ImageViewModel(image) : default(ImageViewModel);
        }

        public static XMLSitemapItemViewModel ToViewModel(this ISeo page)
        {
            return page != null ? new XMLSitemapItemViewModel(page) : default(XMLSitemapItemViewModel);
        }

        public static SearchResultsItemViewModel ToViewModel(this ISearchResultItem item)
        {
            return new SearchResultsItemViewModel(item);
        }

        public static IEnumerable<SearchResultsItemViewModel> ToViewModel(this IEnumerable<ISearchResultItem> items)
        {
            if (items == null) return Enumerable.Empty<SearchResultsItemViewModel>();

            return items.Select(ToViewModel);
        }
    }
}