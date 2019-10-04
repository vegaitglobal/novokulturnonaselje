using Examine;
using Lucene.Net.Analysis.Standard;
using System;
using System.Collections.Generic;
using Umbraco.Core.Logging;
using Umbraco.Core.Services;
using Umbraco.Examine;
using Umbraco.Web.Search;

namespace NKN.Search.Indexes
{
    public class GeneralExamineIndexCreator : LuceneIndexCreator, IUmbracoIndexesCreator
    {
        private readonly IProfilingLogger _profilingLogger;
        private readonly ILocalizationService _languageService;

        public GeneralExamineIndexCreator(IProfilingLogger profilingLogger, ILocalizationService languageService)
        {
            _profilingLogger = profilingLogger ?? throw new ArgumentNullException(nameof(profilingLogger));
            _languageService = languageService ?? throw new ArgumentNullException(nameof(languageService));
        }

        public override IEnumerable<IIndex> Create()
        {
            return new[]
            {
                CreateGeneralIndex()
            };
        }

        private IIndex CreateGeneralIndex()
        {
            var index = new UmbracoContentIndex(
                Constants.ExamineIndexes.GeneralIndex,
                CreateFileSystemLuceneDirectory(Constants.ExamineIndexes.GeneralIndexPath),
                new UmbracoFieldDefinitionCollection(),
                new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30),
                _profilingLogger,
                _languageService,
                GetPublishedContentValueSetValidator());
            return index;
        }

        public virtual IContentValueSetValidator GetPublishedContentValueSetValidator()
        {
            return new ContentValueSetValidator(true, includeItemTypes: new[] {"home", "standardContent"});
        }
    }
}