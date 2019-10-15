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

		public static class ProjectLanding
		{
			public static string RealizedProjects => UmbracoHelper.GetDictionaryValue("ProjectLanding.RealizedProjects");
			public static string FutureProjects => UmbracoHelper.GetDictionaryValue("ProjectLanding.FutureProjects");
			public static string ViewMore => UmbracoHelper.GetDictionaryValue("ProjectLanding.ViewMore");
		}

        private static UmbracoHelper UmbracoHelper =>
            (UmbracoHelper)Current.Factory.GetInstance(typeof(UmbracoHelper));
    }
}