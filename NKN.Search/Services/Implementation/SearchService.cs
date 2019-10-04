using Examine;
using Examine.LuceneEngine.Providers;
using Examine.LuceneEngine.Search;
using Examine.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Umbraco.Core;
using Umbraco.Examine;
using Umbraco.Web;
using NKN.Search.Models;

namespace NKN.Search.Services.Implementation
{
    public class SearchService : DisposableObjectSlim, ISearchService
    {
        private readonly IExamineManager _examineManager;
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;
        private readonly string[] _searchFields;
        private readonly LuceneSearcher _searcher;

        public SearchService(IExamineManager examineManager, IUmbracoContextAccessor umbracoContextAccessor)
        {
            _examineManager = examineManager ?? throw new ArgumentNullException(nameof(examineManager));
            _umbracoContextAccessor =
                umbracoContextAccessor ?? throw new ArgumentNullException(nameof(umbracoContextAccessor));
            _searcher = GetSearcher(Constants.ExamineIndexes.GeneralIndex);
            //TODO: set default values
            _searchFields = new[] {Constants.Fields.PageTitle, Constants.Fields.NodeName};
        }

        public SearchService(IExamineManager examineManager, IUmbracoContextAccessor umbracoContextAccessor,
            string indexName, string[] searchFields)
        {
            if (string.IsNullOrWhiteSpace(indexName)) throw new ArgumentException(nameof(indexName));
            if (searchFields == null || !searchFields.Any()) throw new ArgumentException(nameof(searchFields));

            _examineManager = examineManager ?? throw new ArgumentNullException(nameof(examineManager));
            _umbracoContextAccessor =
                umbracoContextAccessor ?? throw new ArgumentNullException(nameof(umbracoContextAccessor));
            _searcher = GetSearcher(indexName);
            _searchFields = searchFields;
        }

        public SearchResultsPerPage Search(string query)
        {
            return Search(query, default(int), default(int));
        }

        public SearchResultsPerPage Search(string query, int page, int itemsPerPage)
        {
            return Search(query, page, itemsPerPage, new Dictionary<string, string>());
        }

        public SearchResultsPerPage Search(string query, int page, int itemsPerPage,
            Dictionary<string, string> additionalSearchParameters)
        {
            return Search(query, page, itemsPerPage, IndexTypes.Content, BooleanOperation.And,
                additionalSearchParameters);
        }

        public SearchResultsPerPage Search(string query, string searchType, BooleanOperation searchOperation)
        {
            return Search(query, default(int), default(int), searchType, searchOperation);
        }

        public SearchResultsPerPage Search(string query, int page, int itemsPerPage, string searchType,
            BooleanOperation searchOperation)
        {
            return Search(query, page, itemsPerPage, searchType, searchOperation, new Dictionary<string, string>());
        }

        public SearchResultsPerPage Search(string query, int page, int itemsPerPage, string searchType,
            BooleanOperation searchOperation,
            Dictionary<string, string> additionalSearchParameters)
        {
            if (string.IsNullOrWhiteSpace(query)) throw new ArgumentException(nameof(query));
            if (page < 0) throw new ArgumentOutOfRangeException(nameof(page));
            if (itemsPerPage < 0) throw new ArgumentOutOfRangeException(nameof(itemsPerPage));
            if (!Enum.IsDefined(typeof(BooleanOperation), searchOperation))
                throw new InvalidEnumArgumentException(nameof(searchOperation), (int) searchOperation,
                    typeof(BooleanOperation));

            ValidateSearchType(searchType);

            var maxResults = itemsPerPage * page;

            var results = CreateLuceneSearchQuery(searchType, searchOperation)
                .NativeQuery(BuildQuery(query, searchType, searchOperation, additionalSearchParameters))
                .Execute(maxResults > 0 ? maxResults : _searcher.GetLuceneSearcher().MaxDoc);

            var items = results.Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToPublishedSearchResults(_umbracoContextAccessor.UmbracoContext.Content)
                .Select(psr => (ISearchResultItem) psr.Content)
                .ToList();

            return new SearchResultsPerPage(results.TotalItemCount, items);
        }

        protected override void DisposeResources()
        {
            _searcher?.Dispose();
        }

        private static void ValidateSearchType(string searchType)
        {
            if (string.IsNullOrWhiteSpace(searchType)) throw new ArgumentException(nameof(searchType));

            switch (searchType)
            {
                case IndexTypes.Content: return;
                case IndexTypes.Media: return;
                case IndexTypes.Member: return;
                default: throw new ArgumentException($"Not valid search type '{searchType}'.", nameof(searchType));
            }
        }

        private string BuildQuery(string query, string searchType, BooleanOperation searchOperation,
            Dictionary<string, string> additionalSearchParameters)
        {
            const int highBoostValue = 4;

            query = query.Trim('\"', '\'');
            var wholeExamineValue = query.Boost(highBoostValue);
            var words = query.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var wordsExamineValues = words.Select(w => w.Escape()).ToArray();

            var luceneQuery = CreateLuceneSearchQuery(searchType, searchOperation);
            luceneQuery.Field(Constants.Fields.HideFromSiteSearch, "0")
                .And()
                .GroupedOr(_searchFields, wholeExamineValue)
                .Or()
                .GroupedOr(_searchFields, wordsExamineValues);

            if (additionalSearchParameters == null || !additionalSearchParameters.Any())
                return luceneQuery.Query.ToString();

            var additionalLuceneQuery = CreateLuceneSearchQuery(searchType, searchOperation);
            foreach (var key in additionalSearchParameters.Keys)
            {
                if (key == additionalSearchParameters.Keys.Last())
                {
                    additionalLuceneQuery.Field(key, additionalSearchParameters[key].Escape());
                    continue;
                }

                additionalLuceneQuery.Field(key, additionalSearchParameters[key].Escape()).And();
            }

            return $"+({luceneQuery.Query}) {additionalLuceneQuery.Query}";
        }

        private LuceneSearchQuery CreateLuceneSearchQuery(string searchType, BooleanOperation searchOperation)
        {
            return (LuceneSearchQuery) _searcher.CreateQuery(searchType, searchOperation);
        }

        private LuceneSearcher GetSearcher(string indexName)
        {
            if (!_examineManager.TryGetIndex(indexName, out var index))
                throw new InvalidOperationException($"No index found by name {indexName}");

            return (LuceneSearcher) index.GetSearcher();
        }
    }
}