using Umbraco.Core.Composing;
using Umbraco.Web;

namespace NKN.Core
{
    public static class UmbracoDictionary
    {
        public static class Forms
        {
            public static class Labels
            {
                public static string FullName => UmbracoHelper.GetDictionaryValue("Forms.Labels.FullName");
            }
        }

        private static UmbracoHelper UmbracoHelper =>
            (UmbracoHelper)Current.Factory.GetInstance(typeof(UmbracoHelper));
    }
}