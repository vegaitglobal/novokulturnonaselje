using NKN.Models.DocumentTypes;
using NKN.Models.Generated;
using System;

namespace NKN.Core.Contexts
{
    public class NestedContentContext<T> : INestedContentContext<T> where T : class, INestedContent
    {
        public NestedContentContext(T nestedContent, ISiteContext siteContext)
        {
            NestedContent = nestedContent ?? throw new ArgumentNullException(nameof(nestedContent));
            SiteContext = siteContext ?? throw new ArgumentNullException(nameof(siteContext));
        }

        public T NestedContent { get; }
        public IPage CurrentPage => SiteContext.CurrentPage;
        public Home Home => SiteContext.Home;
        public ISiteSettings SiteSettings => SiteContext.SiteSettings;
        private ISiteContext SiteContext { get; }
    }
}