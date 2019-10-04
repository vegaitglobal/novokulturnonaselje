using Examine.Search;
using System.Collections.Generic;
using NKN.Search.Models;

namespace NKN.Search.Services
{
    public interface ISearchService
    {
        SearchResultsPerPage Search(string query);
        SearchResultsPerPage Search(string query, int page, int itemsPerPage);

        SearchResultsPerPage Search(string query, int page, int itemsPerPage,
            Dictionary<string, string> additionalSearchParameters);

        SearchResultsPerPage Search(string query, string searchType, BooleanOperation searchOperation);

        SearchResultsPerPage Search(string query, int page, int itemsPerPage, string searchType,
            BooleanOperation searchOperation);

        SearchResultsPerPage Search(string query, int page, int itemsPerPage, string searchType,
            BooleanOperation searchOperation, Dictionary<string, string> additionalSearchParameters);
    }
}